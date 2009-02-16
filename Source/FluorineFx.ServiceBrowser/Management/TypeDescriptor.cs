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
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Reflection;

namespace FluorineFx.Management
{
	/// <summary>
	/// Summary description for TypeDescriptor.
	/// </summary>
	[Serializable]
	public class TypeDescriptor : NamedObject
	{
		string _fullName;
		string _namespace;
        bool _isArray;
		MethodDescriptor[] _methods;
		string[]	_namespacePath;
        AttributeCollection _attributeCollection;
        PropertyDescriptor[] _properties;
        FieldDescriptor[] _fields;
        ActionScriptType _actionScriptType;
        TypeDescriptor[] _interfaces;

		public TypeDescriptor()
		{
            _attributeCollection = new AttributeCollection();
            _interfaces = new TypeDescriptor[0];
            _methods = new MethodDescriptor[0];
            _properties = new PropertyDescriptor[0];
            _fields = new FieldDescriptor[0];
            _isArray = false;
		}

        public TypeDescriptor(Type type):this()
        {
            _fullName = type.FullName;
            _name = type.Name;
            _isArray = type.IsArray;
            this.Namespace = type.Namespace;
        }

        public void Build(Type type, Hashtable typeDescriptorDictionary)
		{
            _attributeCollection.Clear();
			_fullName = type.FullName;
			_name = type.Name;
            _isArray = type.IsArray;
			this.Namespace = type.Namespace;

            ArrayList interfaces = new ArrayList();
            foreach (Type typeInterface in type.GetInterfaces())
            {
                if (!typeDescriptorDictionary.Contains(typeInterface))
                {
                    TypeDescriptor typeDescriptorTmp = new TypeDescriptor(typeInterface);
                    typeDescriptorDictionary.Add(typeInterface, typeDescriptorTmp);
                    typeDescriptorTmp.Build(typeInterface, typeDescriptorDictionary);
                }
                TypeDescriptor typeDescriptor = typeDescriptorDictionary[typeInterface] as TypeDescriptor;
                interfaces.Add(typeDescriptor);
            }
            _interfaces = interfaces.ToArray(typeof(TypeDescriptor)) as TypeDescriptor[];

			ArrayList methods = new ArrayList();
			foreach(MethodInfo methodInfo in type.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly))
			{
				if( SkipMethod(methodInfo) )
					continue;

				MethodDescriptor methodDescriptor = new MethodDescriptor();
				methodDescriptor.Build(methodInfo);
				methods.Add(methodDescriptor);
			}
			_methods = methods.ToArray(typeof(MethodDescriptor)) as MethodDescriptor[];

            PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            ArrayList properties = new ArrayList(propertyInfos);
            int i = 0;
            for (i = properties.Count - 1; i >= 0; i--)
            {
                PropertyInfo propertyInfo = properties[i] as PropertyInfo;
                if (propertyInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0)
                    properties.RemoveAt(i);
                if (propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                    properties.RemoveAt(i);
                if (propertyInfo.GetGetMethod() == null || propertyInfo.GetGetMethod().GetParameters().Length > 0)
                    properties.RemoveAt(i);
            }
            ArrayList tmp = new ArrayList(properties.Count);
            foreach (PropertyInfo propertyInfo in properties)
            {
                if (!typeDescriptorDictionary.Contains(propertyInfo.PropertyType))
                {
                    TypeDescriptor typeDescriptorTmp = new TypeDescriptor(propertyInfo.PropertyType);
                    typeDescriptorDictionary.Add(propertyInfo.PropertyType, typeDescriptorTmp);
                    typeDescriptorTmp.Build(propertyInfo.PropertyType, typeDescriptorDictionary);
                }
                TypeDescriptor typeDescriptor = typeDescriptorDictionary[propertyInfo.PropertyType] as TypeDescriptor;
                PropertyDescriptor propertyDescriptor = new PropertyDescriptor(propertyInfo.Name, typeDescriptor);
                tmp.Add(propertyDescriptor);
            }
            _properties = tmp.ToArray(typeof(PropertyDescriptor)) as PropertyDescriptor[];

            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            ArrayList fields = new ArrayList(fieldInfos);
            for (i = fields.Count - 1; i >= 0; i--)
            {
                FieldInfo fieldInfo = fields[i] as FieldInfo;
                if (fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0)
                    fields.RemoveAt(i);
                if (fieldInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                    fields.RemoveAt(i);
            }
            tmp = new ArrayList(fields.Count);
            foreach (FieldInfo fieldInfo in fields)
            {
                if (!typeDescriptorDictionary.Contains(fieldInfo.FieldType))
                {
                    TypeDescriptor typeDescriptorTmp = new TypeDescriptor(fieldInfo.FieldType);
                    typeDescriptorDictionary.Add(fieldInfo.FieldType, typeDescriptorTmp);
                    typeDescriptorTmp.Build(fieldInfo.FieldType, typeDescriptorDictionary);
                }
                TypeDescriptor typeDescriptor = typeDescriptorDictionary[fieldInfo.FieldType] as TypeDescriptor;
                FieldDescriptor fieldDescriptor = new FieldDescriptor(fieldInfo.Name, typeDescriptor);
                tmp.Add(fieldDescriptor);
            }
            _fields = tmp.ToArray(typeof(FieldDescriptor)) as FieldDescriptor[];


			object[] attrs = type.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
			if( attrs.Length > 0 )
			{
				System.ComponentModel.DescriptionAttribute descriptionAttribute = attrs[0] as System.ComponentModel.DescriptionAttribute;
				_description = descriptionAttribute.Description;
			}

			attrs = type.GetCustomAttributes(true);
            if (attrs != null && attrs.Length > 0)
            {
                for (i = 0; i < attrs.Length; i++)
                {
                    Attribute attribute = attrs[i] as Attribute;
                    if (attribute is System.ComponentModel.DescriptionAttribute)
                        continue;
                    AttributeDescriptor attributeDescriptor = new AttributeDescriptor(attribute.GetType().Name);
                    if( !_attributeCollection.Contains(attributeDescriptor.Name) )
                        _attributeCollection.Add(attributeDescriptor);
                }
            }
		}

		public static bool SkipMethod(MethodInfo methodInfo)
		{
			if (methodInfo.ReturnType == typeof(System.IAsyncResult))
				return true;
			foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
			{
				if (parameterInfo.ParameterType == typeof(System.IAsyncResult))
					return true;
			}
			return false;
		}

		public MethodDescriptor GetMethod(object method)
		{
			string methodName = method.ToString();
			foreach(MethodDescriptor methodDescriptor in _methods)
				if( methodDescriptor.Name == methodName )
					return methodDescriptor;
			return null;
		}

		public string FullName
		{
			get{ return _fullName; }
			set{ _fullName = value; }
		}

		public string Namespace
		{
			get{ return _namespace; }
			set
			{ 
				if( value != null )
				{
					_namespace = value;
					_namespacePath = _namespace.Split(new char[] {'.'});
				}
				else
				{
					_namespace = string.Empty;
					_namespacePath = new string[0];
				}
			}
		}

		public MethodDescriptor[] Methods
		{
			get{ return _methods; }
			set{ _methods = value; }
		}

		public string[] NamespacePath
		{
			get{ return _namespacePath; }
			set{ _namespacePath = value; }
		}

        public AttributeCollection Attributes
        {
            get { return _attributeCollection; }
            set { _attributeCollection = value; }
        }

        public PropertyDescriptor[] Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        public FieldDescriptor[] Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public TypeDescriptor[] Interfaces
        {
            get { return _interfaces; }
            set { _interfaces = value; }
        }

        public ActionScriptType ActionScriptType
        {
            get { return _actionScriptType; }
            set { _actionScriptType = value; }
        }

        public bool IsArray
        {
            get { return _isArray; }
            set { _isArray = value; }
        }

        public bool Implements(string itf)
        {
            foreach (TypeDescriptor typeDescriptor in _interfaces)
            {
                if (typeDescriptor.FullName == itf)
                    return true;
            }
            return false;
        }
	}
}
