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
#if (NET_1_1)
#else
using System.Collections.Generic;
#endif

namespace FluorineFx.Util
{
    public abstract class ValidationUtils
    {
        protected ValidationUtils() { }

        public static void ArgumentNotNullOrEmpty(string value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);

            if (value.Length == 0)
                throw new ArgumentException(string.Format("'{0}' cannot be empty.", parameterName), parameterName);
        }

        public static void ArgumentNotNullOrEmptyOrWhitespace(string value, string parameterName)
        {
            ArgumentNotNullOrEmpty(value, parameterName);

            if (StringUtils.IsWhiteSpace(value))
                throw new ArgumentException(string.Format("'{0}' cannot only be whitespace.", parameterName), parameterName);
        }

        public static void ArgumentTypeIsEnum(Type enumType, string parameterName)
        {
            ArgumentNotNull(enumType, "enumType");

            if (!enumType.IsEnum)
                throw new ArgumentException(string.Format("Type {0} is not an Enum.", enumType), parameterName);
        }

        public static void ArgumentNotNullOrEmpty(ICollection collection, string parameterName)
        {
            ArgumentNotNullOrEmpty(collection, parameterName, string.Format("Collection '{0}' cannot be empty.", parameterName));
        }

        public static void ArgumentNotNullOrEmpty(ICollection collection, string parameterName, string message)
        {
            if (collection == null)
                throw new ArgumentNullException(parameterName);

            if (collection.Count == 0)
                throw new ArgumentException(message, parameterName);
        }
#if (NET_1_1)

#else

        public static void ArgumentNotNullOrEmpty<T>(ICollection<T> collection, string parameterName)
        {
            ArgumentNotNullOrEmpty<T>(collection, parameterName, string.Format("Collection '{0}' cannot be empty.", parameterName));
        }

        public static void ArgumentNotNullOrEmpty<T>(ICollection<T> collection, string parameterName, string message)
        {
            if (collection == null)
                throw new ArgumentNullException(parameterName);

            if (collection.Count == 0)
                throw new ArgumentException(message, parameterName);
        }

        public static void ArgumentIsPositive<T>(T value, string parameterName) where T : struct, IComparable<T>
        {
            if (value.CompareTo(default(T)) != 1)
                throw new ArgumentOutOfRangeException(parameterName, value, "Positive number required.");
        }

#endif

        public static void ArgumentNotNull(object value, string parameterName)
        {
            if (value == null)
                throw new ArgumentNullException(parameterName);
        }

        public static void ArgumentNotNegative(int value, string parameterName)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(parameterName, value, "Argument cannot be negative.");
        }

        public static void ArgumentNotNegative(int value, string parameterName, string message)
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(parameterName, value, message);
        }

        public static void ArgumentNotZero(int value, string parameterName)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException(parameterName, value, "Argument cannot be zero.");
        }

        public static void ArgumentNotZero(int value, string parameterName, string message)
        {
            if (value == 0)
                throw new ArgumentOutOfRangeException(parameterName, value, message);
        }

        public static void ArgumentIsPositive(int value, string parameterName, string message)
        {
            if (value > 0)
                throw new ArgumentOutOfRangeException(parameterName, value, message);
        }

        public static void ObjectNotDisposed(bool disposed, Type objectType)
        {
            if (disposed)
                throw new ObjectDisposedException(objectType.Name);
        }

        public static void ArgumentConditionTrue(bool condition, string parameterName, string message)
        {
            if (!condition)
                throw new ArgumentException(message, parameterName);
        }

		public static void ObjectNotNull(object value, string variableName)
		{
			if (value == null)
				throw new NullReferenceException(string.Format("{0} cannot be null.", variableName));
		}
    }
}