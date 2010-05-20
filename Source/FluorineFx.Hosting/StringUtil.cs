/*
	FluorineFx open source library 
	Copyright (C) 2007-2010 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
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

namespace FluorineFx.Hosting
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	static class StringUtil
	{
	    public static bool StringEndsWith(string s, char c)
		{
			int length = s.Length;
			if (length != 0)
			{
				return (s[length - 1] == c);
			}
			return false;
		}

		public static bool IsNullOrEmpty(string value)
		{
			if (value != null)
			{
				return (value.Length == 0);
			}
			return true;
		}

		public static string Replace(string s, char c1, char c2)
		{
		    return s.IndexOf(c1) < 0 ? s : s.Replace(c1, c2);
		}

	    internal static bool EqualsIgnoreCase(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
                return true;
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
                return false;
            if (s2.Length != s1.Length)
                return false;
            return (0 == string.Compare(s1, 0, s2, 0, s2.Length, StringComparison.OrdinalIgnoreCase));
        }
	}
}
