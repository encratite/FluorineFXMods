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
using System.Reflection;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
#if !SILVERLIGHT
using log4net;
#endif
using FluorineFx.AMF3;
using FluorineFx.Configuration;
using FluorineFx.Util;
using FluorineFx.Exceptions;

namespace FluorineFx.IO
{
    class ObjectProxy : IObjectProxy
    {
#if !SILVERLIGHT
        private static readonly ILog log = LogManager.GetLogger(typeof(ObjectProxy));
#endif

        public ObjectProxy()
        {
        }

        #region IObjectProxy Members

        public bool GetIsExternalizable(object instance)
        {
            return instance is IExternalizable;
        }

        public bool GetIsDynamic(object instance)
        {
            return instance is ASObject;
        }

        public virtual ClassDefinition GetClassDefinition(object instance)
        {
            ValidationUtils.ArgumentNotNull(instance, "instance");
            Type type = instance.GetType();
            ClassDefinition classDefinition = null;

#if !(NET_1_1)
            List<string> memberNames = new List<string>();
            List<ClassMember> classMemberList = new List<ClassMember>();
#else
            ArrayList memberNames = new ArrayList();
            ArrayList classMemberList = new ArrayList();
#endif

            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                PropertyInfo propertyInfo = propertyInfos[i] as PropertyInfo;
                string name = propertyInfo.Name;
                if (propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                    continue;
                if (propertyInfo.GetGetMethod() == null || propertyInfo.GetGetMethod().GetParameters().Length > 0)
                {
                    //The gateway will not be able to access this property
                    string msg = __Res.GetString(__Res.Reflection_PropertyIndexFail, string.Format("{0}.{1}", type.FullName, propertyInfo.Name));
#if !SILVERLIGHT
                    if (log.IsWarnEnabled)
                        log.Warn(msg);
#endif
                    continue;
                }
                if (memberNames.Contains(name))
                    continue;
                memberNames.Add(name);
                BindingFlags bf = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
                try
                {
                    PropertyInfo propertyInfoTmp = type.GetProperty(name);
                }
                catch (AmbiguousMatchException)
                {
                    bf = BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance;
                }
                ClassMember classMember = new ClassMember(name, bf, propertyInfo.MemberType);
                classMemberList.Add(classMember);
            }
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                FieldInfo fieldInfo = fieldInfos[i] as FieldInfo;
#if !SILVERLIGHT
                if (fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0)
                    continue;
#endif
                if (fieldInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                    continue;
                string name = fieldInfo.Name;
                ClassMember classMember = new ClassMember(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, fieldInfo.MemberType);
                classMemberList.Add(classMember);
            }
#if !(NET_1_1)
            ClassMember[] classMembers = classMemberList.ToArray();
#else
            ClassMember[] classMembers = classMemberList.ToArray(typeof(ClassMember)) as ClassMember[];
#endif
            string customClassName = type.FullName;
            customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);
            classDefinition = new ClassDefinition(customClassName, classMembers, GetIsExternalizable(instance), GetIsDynamic(instance));
            return classDefinition;
        }

        public virtual object GetValue(object instance, ClassMember member)
        {
            ValidationUtils.ArgumentNotNull(instance, "instance");
            Type type = instance.GetType();
            if (member.MemberType == MemberTypes.Property)
            {
                PropertyInfo propertyInfo = type.GetProperty(member.Name, member.BindingFlags);
                return propertyInfo.GetValue(instance, null);
            }
            if (member.MemberType == MemberTypes.Field)
            {
                FieldInfo fieldInfo = type.GetField(member.Name, member.BindingFlags);
                return fieldInfo.GetValue(instance);
            }
            string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("{0}.{1}", type.FullName, member.Name));
            throw new FluorineException(msg);
        }

        public virtual void SetValue(object instance, ClassMember member, object value)
        {
            ValidationUtils.ArgumentNotNull(instance, "instance");
            Type type = instance.GetType();
            if (member.MemberType == MemberTypes.Property)
            {
                PropertyInfo propertyInfo = type.GetProperty(member.Name, member.BindingFlags);
                propertyInfo.SetValue(instance, value, null);
            }
            if (member.MemberType == MemberTypes.Field)
            {
                FieldInfo fieldInfo = type.GetField(member.Name, member.BindingFlags);
                fieldInfo.SetValue(instance, value);
            }
            string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("{0}.{1}", type.FullName, member.Name));
            throw new FluorineException(msg);
        }

        #endregion

    }
}
