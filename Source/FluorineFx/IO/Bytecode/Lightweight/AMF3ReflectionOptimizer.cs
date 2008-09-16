/*
	FluorineFx open source library 
	Copyright (C) 2007 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
	This library is free software; you can redistribute it and/or
	modify it under the terms of the GNU Lesser General Public
	License as published by the Free Software Foundation; either
	version 2.1 of the License, or (at your option) any later version.
	
	This library is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
	Lesser General Public License for more details.
	
	You should have received a copy of the GNU Lesser General Public
	License along with this library; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
*/
using System;
using System.Collections;
using System.Xml;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;
using System.Security.Permissions;
using log4net;

using FluorineFx.AMF3;
using FluorineFx.Configuration;
using FluorineFx.Exceptions;

#if !(NET_1_1)

namespace FluorineFx.IO.Bytecode.Lightweight
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    class AMF3ReflectionOptimizer : IReflectionOptimizer
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(AMF3ReflectionOptimizer));

        CreateInstanceInvoker _createInstanceMethod;
        ReadDataInvoker _readDataMethod;
        ClassDefinition _classDefinition;

        public AMF3ReflectionOptimizer(Type type, ClassDefinition classDefinition, AMFReader reader, object instance)
		{
            _classDefinition = classDefinition;
            _createInstanceMethod = CreateCreateInstanceMethod(type);
            _readDataMethod = CreateReadDataMethod(type, reader, instance);
        }

        private CreateInstanceInvoker CreateCreateInstanceMethod(System.Type type)
        {
            DynamicMethod method = new DynamicMethod(string.Empty, typeof(object), null, type, true);
            ILGenerator il = method.GetILGenerator();

            ConstructorInfo constructor = type.GetConstructor(EmitHelper.AnyVisibilityInstance, null, CallingConventions.HasThis, System.Type.EmptyTypes, null);
            il.Emit(OpCodes.Newobj, constructor);
            il.Emit(OpCodes.Ret);
            return (CreateInstanceInvoker)method.CreateDelegate(typeof(CreateInstanceInvoker));
        }

        protected virtual ReadDataInvoker CreateReadDataMethod(Type type, AMFReader reader, object instance)
        {
            //DynamicMethod method = new DynamicMethod(string.Empty, typeof(object), new Type[] { typeof(AMFReader) }, type, true);
            bool canSkipChecks = SecurityManager.IsGranted(new ReflectionPermission(ReflectionPermissionFlag.MemberAccess));
            DynamicMethod method = new DynamicMethod(string.Empty, typeof(object), new Type[] { typeof(AMFReader), typeof(ClassDefinition) }, this.GetType(), canSkipChecks);
            ILGenerator il = method.GetILGenerator();

            LocalBuilder instanceLocal = il.DeclareLocal(type);//[0] instance
            LocalBuilder typeCodeLocal = il.DeclareLocal(typeof(byte));//[1] uint8 typeCode
            LocalBuilder keyLocal = il.DeclareLocal(typeof(string));//[2] string key
            LocalBuilder objTmp = il.DeclareLocal(typeof(object));//[3] temp object store
            LocalBuilder intTmp1 = il.DeclareLocal(typeof(int));//[4] temp int store, length
            LocalBuilder intTmp2 = il.DeclareLocal(typeof(int));//[5] temp int store, index
            LocalBuilder objTmp2 = il.DeclareLocal(typeof(object));//[6] temp object store
            LocalBuilder typeTmp = il.DeclareLocal(typeof(Type));//[7] temp Type store

            EmitHelper emit = new EmitHelper(il);
            ConstructorInfo typeConstructor = type.GetConstructor(EmitHelper.AnyVisibilityInstance, null, CallingConventions.HasThis, System.Type.EmptyTypes, null);
            MethodInfo miAddReference = typeof(AMFReader).GetMethod("AddAMF3ObjectReference");
            MethodInfo miReadByte = typeof(AMFReader).GetMethod("ReadByte");
            emit
                //object instance = new object();
                .newobj(typeConstructor) //Create the new instance and push the object reference onto the evaluation stack
                .stloc_0 //Pop from the top of the evaluation stack and store it in a the local variable list at index 0
                //reader.AddReference(instance);
                .ldarg_0 //Push the argument indexed at 1 onto the evaluation stack 'reader'
                .ldloc_0 //Loads the local variable at index 0 onto the evaluation stack 'instance'
                .callvirt(miAddReference) //Arguments are popped from the stack, the method call is performed, return value is pushed onto the stack
                //typeCode = 0;
                .ldc_i4_0 //Push the integer value of 0 onto the evaluation stack as an int32
                .stloc_1 //Pop and store it in a the local variable list at index 1
                //string key = null;
                .ldnull //Push a null reference onto the evaluation stack
                .stloc_2 //Pop and store it in a the local variable list at index 2 'key'
                .end()
            ;

            for (int i = 0; i < _classDefinition.MemberCount; i++)
            {
                string key = _classDefinition.Members[i].Name;
                byte typeCode = reader.ReadByte();
                object value = reader.ReadAMF3Data(typeCode);
                reader.SetMember(instance, key, value);

                emit
                    //.ldarg_1
                    //.callvirt(typeof(ClassDefinition).GetMethod("get_Members"))
                    //.ldc_i4(i)
                    //.conv_ovf_i
                    //.ldelem_ref
                    //.stloc_2
                    .ldarg_0
                    .callvirt(miReadByte)
                    .stloc_1
                    .end()
                ;
                
                MemberInfo[] memberInfos = type.GetMember(key);
                if (memberInfos != null && memberInfos.Length > 0)
                    GeneratePropertySet(emit, typeCode, memberInfos[0]);
                else
                    throw new MissingMemberException(type.FullName, key);                
            }
            Label labelExit = emit.DefineLabel();
            emit
                .MarkLabel(labelExit)
                //return instance;
                .ldloc_0 //Load the local variable at index 0 onto the evaluation stack
                .ret() //Return
            ;

            return (ReadDataInvoker)method.CreateDelegate(typeof(ReadDataInvoker));
        }

        private void GeneratePropertySet(EmitHelper emit, int typeCode, MemberInfo memberInfo)
        {
            Type memberType = null;
            if (memberInfo.MemberType ==  MemberTypes.Property)
            {
                PropertyInfo propertyInfo = memberInfo.DeclaringType.GetProperty(memberInfo.Name);
                memberType = propertyInfo.PropertyType;
            }
            if (memberInfo is FieldInfo)
            {
                FieldInfo fieldInfo = memberInfo.DeclaringType.GetField(memberInfo.Name);
                memberType = fieldInfo.FieldType;
            }
            if (memberType == null)
                throw new ArgumentNullException(memberInfo.Name);

            //instance.member = (type)TypeHelper.ChangeType(reader.ReadAMF3Data(typeCode), typeof(member));
            emit
                .ldloc_0 //Push 'instance'
                .ldarg_0 //Push 'reader'
                .ldloc_1 //Push 'typeCode'
                .callvirt(typeof(AMFReader).GetMethod("ReadAMF3Data", new Type[] { typeof(byte) }))
                .ldtoken(memberType)
                .call(typeof(Type).GetMethod("GetTypeFromHandle", new Type[] { typeof(RuntimeTypeHandle) }))
                .call(typeof(TypeHelper).GetMethod("ChangeType", new Type[] { typeof(object), typeof(Type) }))
                .CastFromObject(memberType)
                .GenerateSetMember(memberInfo)
                .end()
            ;
        }


        #region IReflectionOptimizer Members

        public object CreateInstance()
        {
            return _createInstanceMethod();
        }

        public object ReadData(AMFReader reader, ClassDefinition classDefinition)
        {
            return _readDataMethod(reader, classDefinition);
        }

        #endregion
    }
}

#endif