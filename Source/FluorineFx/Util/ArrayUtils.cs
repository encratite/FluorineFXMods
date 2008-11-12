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

namespace FluorineFx.Util
{
    /// <summary>
    /// Array utility class.
    /// </summary>
    public abstract class ArrayUtils
    {
        private ArrayUtils() { }

        /// <summary>
        /// Changes the size of an array to the specified new size.
        /// </summary>
        /// <param name="array">The one-dimensional, zero-based array to resize.</param>
        /// <param name="newSize">The size of the new array.</param>
        /// <returns>The resized array.</returns>
        public static Array Resize(Array array, int newSize)
        {
            Type type = array.GetType();
            Array newArray = Array.CreateInstance(type.GetElementType(), newSize);
            Array.Copy(array, 0, newArray, 0, Math.Min(array.Length, newSize));
            return newArray;
        }
    }
}
