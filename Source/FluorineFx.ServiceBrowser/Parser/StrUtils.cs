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
using System.Globalization;
using System.Text;

namespace FluorineFx.CodeGenerator.Parser
{
	internal sealed class StrUtils 
	{
		static CultureInfo invariant = CultureInfo.InvariantCulture;
		private StrUtils () { }
		
		public static bool StartsWith (string str1, string str2)
		{
			return StartsWith (str1, str2, false);
		}

		public static bool StartsWith (string str1, string str2, bool ignore_case)
		{
			int l2 = str2.Length;
			if (l2 == 0)
				return true;

			int l1 = str1.Length;
			if (l2 > l1)
				return false;

			return (0 == String.Compare (str1, 0, str2, 0, l2, ignore_case, invariant));
		}

		public static bool EndsWith (string str1, string str2)
		{
			return EndsWith (str1, str2, false);
		}

		public static bool EndsWith (string str1, string str2, bool ignore_case)
		{
			int l2 = str2.Length;
			if (l2 == 0)
				return true;

			int l1 = str1.Length;
			if (l2 > l1)
				return false;

			return (0 == String.Compare (str1, l1 - l2, str2, 0, l2, ignore_case, invariant));
		}
	}
}