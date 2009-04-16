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
#if !(NET_1_1)
using System.Collections.Generic;
#endif
using System.Text;
using System.Reflection;
using System.Collections;
using System.ComponentModel;

namespace FluorineFx.Util
{
    /// <summary>
    /// Reflection utility class.
    /// </summary>
	internal abstract class ReflectionUtils
	{
        protected ReflectionUtils() { }

		static Type GenericIListType = Type.GetType("System.Collections.Generic.IList`1");
		static Type GenericICollectionType = Type.GetType("System.Collections.Generic.ICollection`1");
		static Type GenericIDictionaryType = Type.GetType("System.Collections.Generic.IDictionary`2");

		public static Type GetObjectType(object v)
		{
			return (v != null) ? v.GetType() : null;
		}

		public static bool IsInstantiatableType(Type t)
		{
			ValidationUtils.ArgumentNotNull(t, "t");

			if (t.IsAbstract || t.IsInterface || t.IsArray || IsGenericTypeDefinition(t) || t == typeof(void))
				return false;

			if (!HasDefaultConstructor(t))
				return false;

			return true;
		}

		public static bool HasDefaultConstructor(Type t)
		{
			ValidationUtils.ArgumentNotNull(t, "t");

			if (t.IsValueType)
				return true;

			return (t.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[0], null) != null);
		}

        /// <summary>
        /// Gets a value indicating whether a type (or type's element type)
        /// instance can be null in the underlying data store.
        /// </summary>
        /// <param name="type">A <see cref="System.Type"/> instance. </param>
        /// <returns> True, if the type parameter is a closed generic nullable type; otherwise, False.</returns>
		public static bool IsNullable(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");

			if (type.IsValueType)
			{
#if (NET_1_1)
				PropertyInfo piIsGenericType = type.GetType().GetProperty("IsGenericType");
				if (piIsGenericType != null)
				{
					//.NET 2 here
					bool isGenericType = (bool)piIsGenericType.GetValue(type, null);
					return isGenericType && type.Name.StartsWith("Nullable");
					//return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
				}
				return false;
#else
                return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
#endif
			}
			return false;
		}

		public static bool IsUnitializedValue(object value)
		{
			if (value == null)
			{
				return true;
			}
			else
			{
				object unitializedValue = CreateUnitializedValue(value.GetType());
				return value.Equals(unitializedValue);
			}
		}

		public static object CreateUnitializedValue(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");

			if (IsGenericTypeDefinition(type))
				throw new ArgumentException(string.Format("Type {0} is a generic type definition and cannot be instantiated.", type), "type");

			if (type.IsClass || type.IsInterface || type == typeof(void))
				return null;
			else if (type.IsValueType)
				return Activator.CreateInstance(type);
			else
				throw new ArgumentException(string.Format("Type {0} cannot be instantiated.", type), "type");
		}

		public static bool IsPropertyIndexed(PropertyInfo property)
		{
			ValidationUtils.ArgumentNotNull(property, "property");

#if (NET_1_1)
			return !CollectionUtils.IsNullOrEmpty(property.GetIndexParameters());
#else
            return !CollectionUtils.IsNullOrEmpty<ParameterInfo>(property.GetIndexParameters());
#endif
		}

		public static bool ImplementsInterface(Type type, string interfaceName)
		{
			return type.GetInterface(interfaceName, true) != null;
		}

		public static bool IsSubClass(Type type, Type check)
		{
			Type implementingType;
			return IsSubClass(type, check, out implementingType);
		}

		public static bool IsSubClass(Type type, Type check, out Type implementingType)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			ValidationUtils.ArgumentNotNull(check, "check");

			return IsSubClassInternal(type, type, check, out implementingType);
		}

		private static bool IsSubClassInternal(Type initialType, Type currentType, Type check, out Type implementingType)
		{
			if (currentType == check)
			{
				implementingType = currentType;
				return true;
			}

			// don't get interfaces for an interface unless the initial type is an interface
			if (check.IsInterface && (initialType.IsInterface || currentType == initialType))
			{
				foreach (Type t in currentType.GetInterfaces())
				{
					if (IsSubClassInternal(initialType, t, check, out implementingType))
					{
						// don't return the interface itself, return it's implementor
						if (check == implementingType)
							implementingType = currentType;

						return true;
					}
				}
			}

			if (IsGenericType(currentType) && !IsGenericTypeDefinition(currentType))
			{
				if (IsSubClassInternal(initialType, GetGenericTypeDefinition(currentType), check, out implementingType))
				{
					implementingType = currentType;
					return true;
				}
			}

			if (currentType.BaseType == null)
			{
				implementingType = null;
				return false;
			}

			return IsSubClassInternal(initialType, currentType.BaseType, check, out implementingType);
		}


		static public bool IsGenericTypeDefinition(Type type)
		{
#if (NET_1_1)
			PropertyInfo piIsGenericTypeDefinition = type.GetType().GetProperty("IsGenericTypeDefinition");
			if (piIsGenericTypeDefinition != null)
			{
				//.NET 2 here
				bool isGenericTypeDefinition = (bool)piIsGenericTypeDefinition.GetValue(type, null);
				return isGenericTypeDefinition;
			}
			return false;
#else
            return type.IsGenericTypeDefinition;
#endif
		}

		static public bool IsGenericType(Type type)
		{
#if (NET_1_1)
			PropertyInfo piIsGenericType = type.GetType().GetProperty("IsGenericType");
			if (piIsGenericType != null)
			{
				//.NET 2 here
				bool isGenericType = (bool)piIsGenericType.GetValue(type, null);
				return isGenericType;
			}
			return false;
#else
            return type.IsGenericType;
#endif
		}

		static public Type GetGenericTypeDefinition(Type type)
		{
#if (NET_1_1)
			MethodInfo miGetGenericTypeDefinition = type.GetType().GetMethod("GetGenericTypeDefinition");
			if (miGetGenericTypeDefinition != null)
			{
				//.NET 2 here
				Type genericTypeDefinition = miGetGenericTypeDefinition.Invoke(type, new object[] { }) as Type;
				return genericTypeDefinition;
			}
			return null;
#else
            return type.GetGenericTypeDefinition();
#endif
		}

		static public Type[] GetGenericArguments(Type type)
		{
#if (NET_1_1)
			MethodInfo miGetGenericArguments = type.GetType().GetMethod("GetGenericArguments");
			if (miGetGenericArguments != null)
			{
				//.NET 2 here
				Type[] genericArguments = miGetGenericArguments.Invoke(type, new object[] { }) as Type[];
				return genericArguments;
			}
			return null;
#else
            return type.GetGenericArguments();
#endif
		}

        internal static Type MakeGenericType(Type genericTypeDefinition, params Type[] typeArguments)
		{
			ValidationUtils.ArgumentNotNull(genericTypeDefinition, "genericTypeDefinition");
#if (NET_1_1)
			ValidationUtils.ArgumentNotNullOrEmpty(typeArguments, "typeArguments");
#else
            ValidationUtils.ArgumentNotNullOrEmpty<Type>(typeArguments, "typeArguments");
#endif
            ValidationUtils.ArgumentConditionTrue(IsGenericTypeDefinition(genericTypeDefinition), "genericTypeDefinition", string.Format("Type {0} is not a generic type definition.", genericTypeDefinition));

#if (NET_1_1)
			MethodInfo miMakeGenericType = genericTypeDefinition.GetType().GetMethod("MakeGenericType");
			if (miMakeGenericType != null)
			{
				//.NET 2 here
				Type constructed = miMakeGenericType.Invoke(genericTypeDefinition, new object[] { typeArguments }) as Type;
				return constructed;
			}
			return null;
#else
            return genericTypeDefinition.MakeGenericType(typeArguments);
#endif
		}

		/// <summary>
		/// Gets the type of the typed list's items.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>The type of the typed list's items.</returns>
		public static Type GetListItemType(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			Type genericListType;

			if (type.IsArray)
			{
				return type.GetElementType();
			}
			else if (IsSubClass(type, ReflectionUtils.GenericIListType, out genericListType))
			{
				if ( IsGenericTypeDefinition(genericListType))
					throw new Exception(string.Format("Type {0} is not a list.", type));

				return GetGenericArguments(genericListType)[0];
			}
			else if (typeof(IList).IsAssignableFrom(type))
			{
				return null;
			}
			else
			{
				throw new Exception(string.Format("Type {0} is not a list.", type));
			}
		}

		public static Type GetDictionaryValueType(Type type)
		{
			ValidationUtils.ArgumentNotNull(type, "type");

			Type genericDictionaryType;
			if (IsSubClass(type, ReflectionUtils.GenericIDictionaryType, out genericDictionaryType))
			{
				if (IsGenericTypeDefinition(genericDictionaryType))
					throw new Exception(string.Format("Type {0} is not a dictionary.", type));

				return GetGenericArguments(genericDictionaryType)[1];
			}
			else if (typeof(IDictionary).IsAssignableFrom(type))
			{
				return null;
			}
			else
			{
				throw new Exception(string.Format("Type {0} is not a dictionary.", type));
			}
		}

#if (NET_1_1)
		/// <summary>
		/// Tests whether the list's items are their unitialized value.
		/// </summary>
		/// <param name="list">The list.</param>
		/// <returns>Whether the list's items are their unitialized value</returns>
		public static bool ItemsUnitializedValue(IList list)
		{
			ValidationUtils.ArgumentNotNull(list, "list");

			Type elementType = GetListItemType(list.GetType());

			if (elementType.IsValueType)
			{
				object unitializedValue = CreateUnitializedValue(elementType);

				for (int i = 0; i < list.Count; i++)
				{
					if (!list[i].Equals(unitializedValue))
						return false;
				}
			}
			else if (elementType.IsClass)
			{
				for (int i = 0; i < list.Count; i++)
				{
					object value = list[i];

					if (value != null)
						return false;
				}
			}
			else
			{
				throw new Exception(string.Format("Type {0} is neither a ValueType or a Class.", elementType));
			}

			return true;
		}
#else
    /// <summary>
    /// Tests whether the list's items are their unitialized value.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>Whether the list's items are their unitialized value</returns>
    public static bool ItemsUnitializedValue<T>(IList<T> list)
    {
      ValidationUtils.ArgumentNotNull(list, "list");

      Type elementType = GetListItemType(list.GetType());

      if (elementType.IsValueType)
      {
        object unitializedValue = CreateUnitializedValue(elementType);

        for (int i = 0; i < list.Count; i++)
        {
          if (!list[i].Equals(unitializedValue))
            return false;
        }
      }
      else if (elementType.IsClass)
      {
        for (int i = 0; i < list.Count; i++)
        {
          object value = list[i];

          if (value != null)
            return false;
        }
      }
      else
      {
        throw new Exception(string.Format("Type {0} is neither a ValueType or a Class.", elementType));
      }

      return true;
    }
#endif

		/// <summary>
		/// Gets the member's underlying type.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <returns>The underlying type of the member.</returns>
		public static Type GetMemberUnderlyingType(MemberInfo member)
		{
			ValidationUtils.ArgumentNotNull(member, "member");

			switch (member.MemberType)
			{
				case MemberTypes.Field:
					return ((FieldInfo)member).FieldType;
				case MemberTypes.Property:
					return ((PropertyInfo)member).PropertyType;
				case MemberTypes.Event:
					return ((EventInfo)member).EventHandlerType;
				default:
					throw new ArgumentException("MemberInfo must be if type FieldInfo, PropertyInfo or EventInfo", "member");
			}
		}

		/// <summary>
		/// Determines whether the member is an indexed property.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <returns>
		/// 	<c>true</c> if the member is an indexed property; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsIndexedProperty(MemberInfo member)
		{
			ValidationUtils.ArgumentNotNull(member, "member");

			PropertyInfo propertyInfo = member as PropertyInfo;

			if (propertyInfo != null)
				return IsIndexedProperty(propertyInfo);
			else
				return false;
		}

		/// <summary>
		/// Determines whether the property is an indexed property.
		/// </summary>
		/// <param name="property">The property.</param>
		/// <returns>
		/// 	<c>true</c> if the property is an indexed property; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsIndexedProperty(PropertyInfo property)
		{
			ValidationUtils.ArgumentNotNull(property, "property");

			return (property.GetIndexParameters().Length > 0);
		}

		public static MemberInfo GetMember(Type type, string name, MemberTypes memberTypes)
		{
			return GetMember(type, name, memberTypes, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
		}

		public static MemberInfo GetMember(Type type, string name, MemberTypes memberTypes, BindingFlags bindingAttr)
		{
			ValidationUtils.ArgumentNotNull(type, "type");
			ValidationUtils.ArgumentNotNull(name, "name");

			MemberInfo[] result = type.GetMember(name, memberTypes, bindingAttr);
			return CollectionUtils.GetSingleItem(result) as MemberInfo;
		}

		/// <summary>
		/// Gets the member's value on the object.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="target">The target object.</param>
		/// <returns>The member's value on the object.</returns>
		public static object GetMemberValue(MemberInfo member, object target)
		{
			ValidationUtils.ArgumentNotNull(member, "member");
			ValidationUtils.ArgumentNotNull(target, "target");

			switch (member.MemberType)
			{
				case MemberTypes.Field:
					return ((FieldInfo)member).GetValue(target);
				case MemberTypes.Property:
					try
					{
						return ((PropertyInfo)member).GetValue(target, null);
					}
					catch (TargetParameterCountException e)
					{
						throw new ArgumentException(string.Format("MemberInfo '{0}' has index parameters", member.Name), e);
					}
				default:
					throw new ArgumentException(string.Format("MemberInfo '{0}' is not of type FieldInfo or PropertyInfo", member.Name), "member");
			}
		}

		/// <summary>
		/// Sets the member's value on the target object.
		/// </summary>
		/// <param name="member">The member.</param>
		/// <param name="target">The target.</param>
		/// <param name="value">The value.</param>
		public static void SetMemberValue(MemberInfo member, object target, object value)
		{
			ValidationUtils.ArgumentNotNull(member, "member");
			ValidationUtils.ArgumentNotNull(target, "target");

			switch (member.MemberType)
			{
				case MemberTypes.Field:
					((FieldInfo)member).SetValue(target, value);
					break;
				case MemberTypes.Property:
					((PropertyInfo)member).SetValue(target, value, null);
					break;
				default:
					throw new ArgumentException(string.Format("MemberInfo '{0}' must be of type FieldInfo or PropertyInfo", member.Name), "member");
			}
		}

		/// <summary>
		/// Determines whether the specified MemberInfo can be read.
		/// </summary>
		/// <param name="member">The MemberInfo to determine whether can be read.</param>
		/// <returns>
		/// 	<c>true</c> if the specified MemberInfo can be read; otherwise, <c>false</c>.
		/// </returns>
		public static bool CanReadMemberValue(MemberInfo member)
		{
			switch (member.MemberType)
			{
				case MemberTypes.Field:
					return true;
				case MemberTypes.Property:
					return ((PropertyInfo)member).CanRead;
				default:
					return false;
			}
		}

		/// <summary>
		/// Determines whether the specified MemberInfo can be set.
		/// </summary>
		/// <param name="member">The MemberInfo to determine whether can be set.</param>
		/// <returns>
		/// 	<c>true</c> if the specified MemberInfo can be set; otherwise, <c>false</c>.
		/// </returns>
		public static bool CanSetMemberValue(MemberInfo member)
		{
			switch (member.MemberType)
			{
				case MemberTypes.Field:
					return true;
				case MemberTypes.Property:
                    return ((PropertyInfo)member).CanWrite && ((PropertyInfo)member).GetSetMethod() != null;
				default:
					return false;
			}
		}

		public static MemberInfo[] GetFieldsAndProperties(Type type, BindingFlags bindingAttr)
		{
#if !(NET_1_1)
            List<MemberInfo> targetMembers = new List<MemberInfo>();
#else
			ArrayList targetMembers = new ArrayList();
#endif

			targetMembers.AddRange(type.GetFields(bindingAttr));
			targetMembers.AddRange(type.GetProperties(bindingAttr));

#if !(NET_1_1)
            return targetMembers.ToArray();
#else
			return targetMembers.ToArray(typeof(MemberInfo)) as MemberInfo[];
#endif
		}

		public static Attribute GetAttribute(Type type, ICustomAttributeProvider attributeProvider)
		{
			return GetAttribute(type, attributeProvider, true);
		}

		public static Attribute GetAttribute(Type type, ICustomAttributeProvider attributeProvider, bool inherit)
		{
			Attribute[] attributes = GetAttributes(type, attributeProvider, inherit);
			return (attributes != null && attributes.Length > 0 ) ? attributes[0] : null;
		}

		public static Attribute[] GetAttributes(Type type, ICustomAttributeProvider attributeProvider, bool inherit)
		{
			ValidationUtils.ArgumentNotNull(attributeProvider, "attributeProvider");
			return attributeProvider.GetCustomAttributes(type, inherit) as Attribute[];
		}

		public static string GetNameAndAssemblyName(Type t)
		{
			ValidationUtils.ArgumentNotNull(t, "t");

			return t.FullName + ", " + t.Assembly.GetName().Name;
		}

		public static MemberInfo[] FindMembers(Type targetType, MemberTypes memberType, BindingFlags bindingAttr, MemberFilter filter, object filterCriteria)
		{
			ValidationUtils.ArgumentNotNull(targetType, "targetType");

#if !(NET_1_1)
            List<MemberInfo> memberInfos = new List<MemberInfo>(targetType.FindMembers(memberType, bindingAttr, filter, filterCriteria));
#else
            ArrayList memberInfos = new ArrayList(targetType.FindMembers(memberType, bindingAttr, filter, filterCriteria));
#endif

			// fix weirdness with FieldInfos only being returned for the current Type
			// find base type fields and add them to result
			if ((memberType & MemberTypes.Field) != 0
				&& (bindingAttr & BindingFlags.NonPublic) != 0)
			{
				// modify flags to not search for public fields
				BindingFlags nonPublicBindingAttr = bindingAttr ^ BindingFlags.Public;

				while ((targetType = targetType.BaseType) != null)
				{
					memberInfos.AddRange(targetType.FindMembers(MemberTypes.Field, nonPublicBindingAttr, filter, filterCriteria));
				}
			}

#if !(NET_1_1)
            return memberInfos.ToArray();
#else
            return memberInfos.ToArray(typeof(MemberInfo)) as MemberInfo[];
#endif
        }

        public static MemberInfo[] FindMembers(Type targetType, MemberTypes memberType, BindingFlags bindingAttr, Type customAttributeType)
        {
            return FindMembers(targetType, memberType, bindingAttr, new MemberFilter(AttributeFilter), customAttributeType);
        }

        public static bool AttributeFilter(MemberInfo candidate, Object part)
        {
            return GetAttribute(part as Type, candidate) != null;
        }

		public static object CreateGeneric(Type genericTypeDefinition, Type innerType, params object[] args)
		{
			return CreateGeneric(genericTypeDefinition, new Type[] { innerType }, args);
		}

		public static object CreateGeneric(Type genericTypeDefinition, IList innerTypes, params object[] args)
		{
			ValidationUtils.ArgumentNotNull(genericTypeDefinition, "genericTypeDefinition");
			ValidationUtils.ArgumentNotNullOrEmpty(innerTypes, "innerTypes");

			Type specificType = MakeGenericType(genericTypeDefinition, CollectionUtils.CreateArray(typeof(Type), innerTypes) as Type[]);

			return Activator.CreateInstance(specificType, args);
		}

        public static TypeConverter GetTypeConverter(object obj)
        {
            if (obj == null)
                return null;
#if !SILVERLIGHT
            TypeConverter typeConverter = TypeDescriptor.GetConverter(obj);
            return typeConverter;
#else
			ICustomAttributeProvider attributeProvider = obj as ICustomAttributeProvider;
			if (attributeProvider == null)
                attributeProvider = obj.GetType();

            TypeConverterAttribute typeConverterAttribute = GetAttribute(typeof(TypeConverterAttribute), attributeProvider, true) as TypeConverterAttribute;
            return ObjectFactory.CreateInstance(typeConverterAttribute.ConverterTypeName) as TypeConverter;
#endif
        }
	}
}
