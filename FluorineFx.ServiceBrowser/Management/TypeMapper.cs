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

namespace FluorineFx.Management
{
    public class TypeMapper
    {
        static Hashtable TypeMappingDictionary;
        public static ActionScriptType Object = new ActionScriptType(string.Empty, "Object", true);
        public static ActionScriptType Number = new ActionScriptType(string.Empty, "Number", true);
        public static ActionScriptType String = new ActionScriptType(string.Empty, "String", true);
        public static ActionScriptType Boolean = new ActionScriptType(string.Empty, "Boolean", true);
        public static ActionScriptType Date = new ActionScriptType(string.Empty, "Date", true);
        public static ActionScriptType Array = new ActionScriptType(string.Empty, "Array", true);
        public static ActionScriptType Xml = new ActionScriptType(string.Empty, "Xml", true);

        static TypeMapper()
        {
            TypeMappingDictionary = new Hashtable();
            TypeMappingDictionary.Add(typeof(System.SByte).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Byte).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Int16).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.UInt16).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Int32).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.UInt32).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Int64).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.UInt64).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Single).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Double).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Decimal).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.DBNull).FullName, TypeMapper.Object);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlByte).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlInt16).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlInt32).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlInt64).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlSingle).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlDouble).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlDecimal).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlMoney).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlDateTime).FullName, TypeMapper.Date);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlString).FullName, TypeMapper.String);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlGuid).FullName, TypeMapper.Date);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlBoolean).FullName, TypeMapper.Boolean);
            TypeMappingDictionary.Add(typeof(System.Data.SqlTypes.SqlBinary).FullName, new ActionScriptType("flash.utils", "ByteArray", true));

            TypeMappingDictionary.Add(typeof(System.String).FullName, TypeMapper.String);
            TypeMappingDictionary.Add(typeof(System.Guid).FullName, TypeMapper.String);
            TypeMappingDictionary.Add(typeof(System.Char).FullName, TypeMapper.String);
            TypeMappingDictionary.Add(typeof(System.Boolean).FullName, TypeMapper.Boolean);
            TypeMappingDictionary.Add(typeof(System.Enum).FullName, TypeMapper.Number);
            TypeMappingDictionary.Add(typeof(System.DateTime).FullName, TypeMapper.Date);
            TypeMappingDictionary.Add(typeof(System.Array).FullName, TypeMapper.Array);
            TypeMappingDictionary.Add(typeof(System.Xml.XmlDocument).FullName, TypeMapper.Xml);
            TypeMappingDictionary.Add(typeof(ASObject).FullName, TypeMapper.Object);
            TypeMappingDictionary.Add(typeof(Hashtable).FullName, TypeMapper.Object);
            TypeMappingDictionary.Add(typeof(System.Data.DataTable).FullName, TypeMapper.Object);
            TypeMappingDictionary.Add(typeof(System.Data.DataSet).FullName, TypeMapper.Object);

            TypeMappingDictionary.Add(typeof(FluorineFx.AMF3.ByteArray).FullName, new ActionScriptType("flash.utils", "ByteArray", true));
            TypeMappingDictionary.Add(typeof(FluorineFx.AMF3.ArrayCollection).FullName, new ActionScriptType("mx.collections", "ArrayCollection", true));
        }

        public static ActionScriptType GetActionScriptType(TypeDescriptor typeDescriptor, Project project)
        {
            if (TypeMappingDictionary.Contains(typeDescriptor.FullName))
                return TypeMappingDictionary[typeDescriptor.FullName] as ActionScriptType;

            if (typeDescriptor.IsArray)
                return TypeMapper.Array;
            if (typeDescriptor.FullName == typeof(IList).FullName)
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (typeDescriptor.FullName.StartsWith("System.Collections.Generic.IList`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (typeDescriptor.FullName.StartsWith("System.Collections.Generic.ICollection`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (typeDescriptor.FullName.StartsWith(typeof(IDictionary).FullName))
                return TypeMapper.Object;
            if (typeDescriptor.Implements(typeof(IList).FullName))
            {
                //TODO: add legacy collection support
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            }
            //Generic IList
            if (typeDescriptor.Implements("System.Collections.Generic.IList`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (typeDescriptor.Implements("System.Collections.Generic.ICollection`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (typeDescriptor.Implements(typeof(IDictionary).FullName))
                return TypeMapper.Object;

            foreach (AssemblyDescriptor assemblyDescriptor in project.Assemblies)
            {
                foreach (TypeDescriptor typeDescriptorTmp in assemblyDescriptor.Types)
                {
                    if (typeDescriptor.FullName == typeDescriptorTmp.FullName)
                        return new ActionScriptType(typeDescriptor.Namespace, typeDescriptor.Name, false);
                }
            }
            return TypeMapper.Object;
        }

        public static ActionScriptType GetActionScriptType(Type type)
        {
            if (TypeMappingDictionary.Contains(type.FullName))
                return TypeMappingDictionary[type.FullName] as ActionScriptType;

            if (type.IsArray)
                return TypeMapper.Array;
            if (type.FullName == typeof(IList).FullName)
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (type.FullName.StartsWith("System.Collections.Generic.IList`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (type.FullName.StartsWith("System.Collections.Generic.ICollection`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (type.FullName.StartsWith(typeof(IDictionary).FullName))
                return TypeMapper.Object;
            if (Implements(type, typeof(IList).FullName))
            {
                //TODO: add legacy collection support
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            }
            //Generic IList
            if (Implements(type, "System.Collections.Generic.IList`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (Implements(type, "System.Collections.Generic.ICollection`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (Implements(type, typeof(IDictionary).FullName))
                return TypeMapper.Object;

            return TypeMapper.Object;
        }

        public static ActionScriptType GetActionScriptType(string type)
        {
            if (TypeMappingDictionary.Contains(type))
                return TypeMappingDictionary[type] as ActionScriptType;

            if (type == typeof(IList).FullName)
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (type.StartsWith("System.Collections.Generic.IList`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (type.StartsWith("System.Collections.Generic.ICollection`1"))
                return new ActionScriptType("mx.collections", "ArrayCollection", true);
            if (type.StartsWith(typeof(IDictionary).FullName))
                return TypeMapper.Object;
            return TypeMapper.Object;
        }

        private static bool Implements(Type type, string itf)
        {
            foreach (Type typeInterface in type.GetInterfaces())
            {
                if (typeInterface.FullName == itf)
                    return true;
            }
            return false;
        }
        /*
        public static ActionScriptType GetActionScriptType(TypeDescriptor typeDescriptor, AssemblyDescriptor assemblyDescriptor)
        {
            if (TypeMappingDictionary.Contains(typeDescriptor.FullName))
                return TypeMappingDictionary[typeDescriptor.FullName] as ActionScriptType;
            foreach (TypeDescriptor typeDescriptorTmp in assemblyDescriptor.Types)
            {
                if (typeDescriptor.FullName == typeDescriptorTmp.FullName)
                    return new ActionScriptType(typeDescriptor.Namespace, typeDescriptor.Name, false);
            }
            if (typeDescriptor.IsArray)
                return TypeMapper.Array;
            if (typeDescriptor.Implements(typeof(IList).FullName))
            {
                //TODO: add legacy collection support
                return new ActionScriptType("mx.collection", "ArrayCollection", true);
            }
            if (typeDescriptor.Implements("System.Collections.Generic.IList`1"))
                return new ActionScriptType("mx.collection", "ArrayCollection", true);
            if (typeDescriptor.Implements("System.Collections.Generic.ICollection`1"))
                return new ActionScriptType("mx.collection", "ArrayCollection", true);
            if (typeDescriptor.Implements(typeof(IDictionary).FullName))
                return TypeMapper.Object;
            return TypeMapper.Object;
        }
        */
    }
}
