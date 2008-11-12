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
using System.Collections.ObjectModel;
#endif
using System.Reflection;
using System.Text;
using System.Collections;

namespace FluorineFx.Util
{
    /// <summary>
    /// Collection utility class.
    /// </summary>
	public abstract class CollectionUtils
	{
        protected CollectionUtils() { }

		/// <summary>
		/// Determines whether the collection is null or empty.
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <returns>
		/// 	<c>true</c> if the collection is null or empty; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrEmpty(ICollection collection)
		{
			if (collection != null)
			{
				return (collection.Count == 0);
			}
			return true;
		}

		public static IList CreateList(Type listType)
		{
			ValidationUtils.ArgumentNotNull(listType, "listType");

			IList list;
#if !(NET_1_1)
			Type readOnlyCollectionType;
#endif
			bool isReadOnlyOrFixedSize = false;

			if (listType.IsArray)
			{
				// have to use an arraylist when creating array
				// there is no way to know the size until it is finised
#if !(NET_1_1)
                list = new List<object>();
#else
				list = new ArrayList();
#endif
				isReadOnlyOrFixedSize = true;
			}
#if !(NET_1_1)
            else if (ReflectionUtils.IsSubClass(listType, typeof(ReadOnlyCollection<>), out readOnlyCollectionType))
            {
                Type readOnlyCollectionContentsType = readOnlyCollectionType.GetGenericArguments()[0];
                Type genericEnumerable = ReflectionUtils.MakeGenericType(typeof(IEnumerable<>), readOnlyCollectionContentsType);
                bool suitableConstructor = false;

                foreach (ConstructorInfo constructor in listType.GetConstructors())
                {
                    IList<ParameterInfo> parameters = constructor.GetParameters();

                    if (parameters.Count == 1)
                    {
                        if (genericEnumerable.IsAssignableFrom(parameters[0].ParameterType))
                        {
                            suitableConstructor = true;
                            break;
                        }
                    }
                }

                if (!suitableConstructor)
                    throw new Exception(string.Format("Readonly type {0} does not have a public constructor that takes a type that implements {1}.", listType, genericEnumerable));

                // can't add or modify a readonly list
                // use List<T> and convert once populated
                list = (IList)CreateGenericList(readOnlyCollectionContentsType);
                isReadOnlyOrFixedSize = true;
            }
#endif
			else if (typeof(IList).IsAssignableFrom(listType) && ReflectionUtils.IsInstantiatableType(listType))
			{
				list = (IList)Activator.CreateInstance(listType);
			}
			else
			{
				throw new Exception(string.Format("Cannot create and populate list type {0}.", listType));
			}

			// create readonly and fixed sized collections using the temporary list
			if (isReadOnlyOrFixedSize)
			{
				if (listType.IsArray)
#if !(NET_1_1)
                    list = ((List<object>)list).ToArray();
#else
					list = ((ArrayList)list).ToArray(ReflectionUtils.GetListItemType(listType));
#endif

#if !(NET_1_1)
				else if (ReflectionUtils.IsSubClass(listType, typeof(ReadOnlyCollection<>)))
					list = (IList)Activator.CreateInstance(listType, list);
#endif
			}

			return list;
		}

		public static Array CreateArray(Type type, ICollection collection)
		{
			ValidationUtils.ArgumentNotNull(collection, "collection");

			if (collection is Array)
				return collection as Array;

#if !(NET_1_1)
            List<object> tempList = new List<object>();
            foreach (object obj in collection)
                tempList.Add(obj);
            return tempList.ToArray();
#else
			ArrayList tempList = new ArrayList(collection);
			return tempList.ToArray(type);
#endif
		}

		#region GetSingleItem

		public static object GetSingleItem(IList list)
        {
            return GetSingleItem(list, false);
        }

        public static object GetSingleItem(IList list, bool returnDefaultIfEmpty)
        {
            if (list.Count == 1)
                return list[0];
            else if (returnDefaultIfEmpty && list.Count == 0)
                return null;
            else
                throw new Exception(string.Format("Expected single item in list but got {1}.", list.Count));
        }
		#endregion


#if !(NET_1_1)
		public static List<T> CreateList<T>(params T[] values)
		{
			return new List<T>(values);
		}

        /// <summary>
        /// Determines whether the collection is null or empty.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>
        /// 	<c>true</c> if the collection is null or empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(ICollection<T> collection)
        {
            if (collection != null)
            {
                return (collection.Count == 0);
            }
            return true;
        }

        /// <summary>
        /// Determines whether the collection is null, empty or its contents are uninitialized values.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>
        /// 	<c>true</c> if the collection is null or empty or its contents are uninitialized values; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmptyOrDefault<T>(IList<T> list)
        {
            if (IsNullOrEmpty<T>(list))
                return true;

            return ReflectionUtils.ItemsUnitializedValue<T>(list);
        }

        /// <summary>
        /// Makes a slice of the specified list in between the start and end indexes.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        /// <returns>A slice of the list.</returns>
        public static IList<T> Slice<T>(IList<T> list, int? start, int? end)
        {
            return Slice<T>(list, start, end, null);
        }

        /// <summary>
        /// Makes a slice of the specified list in between the start and end indexes,
        /// getting every so many items based upon the step.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="start">The start index.</param>
        /// <param name="end">The end index.</param>
        /// <param name="step">The step.</param>
        /// <returns>A slice of the list.</returns>
        public static IList<T> Slice<T>(IList<T> list, int? start, int? end, int? step)
        {
            if (list == null)
                throw new ArgumentNullException("list");

            if (step == 0)
                throw new ArgumentException("Step cannot be zero.", "step");

            List<T> slicedList = new List<T>();

            // nothing to slice
            if (list.Count == 0)
                return slicedList;

            // set defaults for null arguments
            int s = step ?? 1;
            int startIndex = start ?? 0;
            int endIndex = end ?? list.Count;

            // start from the end of the list if start is negitive
            startIndex = (startIndex < 0) ? list.Count + startIndex : startIndex;

            // end from the start of the list if end is negitive
            endIndex = (endIndex < 0) ? list.Count + endIndex : endIndex;

            // ensure indexes keep within collection bounds
            startIndex = Math.Max(startIndex, 0);
            endIndex = Math.Min(endIndex, list.Count - 1);

            // loop between start and end indexes, incrementing by the step
            for (int i = startIndex; i < endIndex; i += s)
            {
                slicedList.Add(list[i]);
            }

            return slicedList;
        }


        /// <summary>
        /// Adds the elements of the specified collection to the specified generic IList.
        /// </summary>
        /// <param name="initial">The list to add to.</param>
        /// <param name="collection">The collection of elements to add.</param>
        public static void AddRange<T>(IList<T> initial, IEnumerable<T> collection)
        {
            if (initial == null)
                throw new ArgumentNullException("initial");

            if (collection == null)
                return;

            foreach (T value in collection)
            {
                initial.Add(value);
            }
        }

        public static List<T> Distinct<T>(List<T> collection)
        {
            List<T> distinctList = new List<T>();

            foreach (T value in collection)
            {
                if (!distinctList.Contains(value))
                    distinctList.Add(value);
            }

            return distinctList;
        }

        public static List<List<T>> Flatten<T>(params IList<T>[] lists)
        {
            List<List<T>> flattened = new List<List<T>>();
            Dictionary<int, T> currentList = new Dictionary<int, T>();

            Recurse<T>(new List<IList<T>>(lists), 0, currentList, flattened);

            return flattened;
        }

        private static void Recurse<T>(IList<IList<T>> global, int current, Dictionary<int, T> currentSet, List<List<T>> flattenedResult)
        {
            IList<T> currentArray = global[current];

            for (int i = 0; i < currentArray.Count; i++)
            {
                currentSet[current] = currentArray[i];

                if (current == global.Count - 1)
                {
                    List<T> items = new List<T>();

                    for (int k = 0; k < currentSet.Count; k++)
                    {
                        items.Add(currentSet[k]);
                    }

                    flattenedResult.Add(items);
                }
                else
                {
                    Recurse(global, current + 1, currentSet, flattenedResult);
                }
            }
        }

        public static List<T> CreateList<T>(ICollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException("collection");

            T[] array = new T[collection.Count];
            collection.CopyTo(array, 0);

            return new List<T>(array);
        }

        public static bool ListEquals<T>(IList<T> a, IList<T> b)
        {
            if (a == null || b == null)
                return (a == null && b == null);

            if (a.Count != b.Count)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;

            for (int i = 0; i < a.Count; i++)
            {
                if (!comparer.Equals(a[i], b[i]))
                    return false;
            }

            return true;
        }


        public static IList<T> Minus<T>(IList<T> list, IList<T> minus)
        {
            ValidationUtils.ArgumentNotNull(list, "list");

            List<T> result = new List<T>(list.Count);
            foreach (T t in list)
            {
                if (minus == null || !minus.Contains(t))
                    result.Add(t);
            }

            return result;
        }


        public static object CreateGenericList(Type listType)
        {
            ValidationUtils.ArgumentNotNull(listType, "listType");

            return ReflectionUtils.CreateGeneric(typeof(List<>), listType);
        }

        public static bool IsListType(Type type)
        {
            ValidationUtils.ArgumentNotNull(type, "listType");

            if (type.IsArray)
                return true;
            else if (typeof(IList).IsAssignableFrom(type))
                return true;
            else if (ReflectionUtils.IsSubClass(type, typeof(IList<>)))
                return true;
            else
                return false;
        }
#endif
	}
}