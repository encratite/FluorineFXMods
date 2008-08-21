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
	/// <summary>
	/// Summary description for Namespace.
	/// </summary>
	[Serializable]
	public class Namespace
	{
		string _name;
		string[]	_namespacePath;
		TypeDescriptor[] _types;

		public Namespace()
		{
			_types = new TypeDescriptor[0];
		}

		public string Name
		{
			get{ return _name; }
			set
			{ 
				if( value != null )
				{
					_name = value;
					_namespacePath = _name.Split(new char[] {'.'});
				}
				else
				{
					_name = string.Empty;
					_namespacePath = new string[0];
				}
			}
		}

		public string[] NamespacePath
		{
			get{ return _namespacePath; }
			set{ _namespacePath = value; }
		}

		public TypeDescriptor[] Types
		{
			get{ return _types; }
			set{ _types = value; }
		}

		public void AddTypeDescriptor(TypeDescriptor typeDescriptor)
		{
			TypeDescriptor[] tmpArray = new TypeDescriptor[_types.Length+1];
			if(_types.Length > 0)
				Array.Copy(_types, 0, tmpArray, 0, _types.Length);
			tmpArray[tmpArray.Length-1] = typeDescriptor;
			_types = tmpArray;
		}

        public bool Contains(TypeDescriptor typeDescriptor)
        {
            foreach (TypeDescriptor tmp in _types)
            {
                if (tmp.FullName == typeDescriptor.FullName)
                    return true;
            }
            return false;
        }

        //FluorineFx specific type access

        public TypeDescriptor[] RemotingServices
        {
            get
            {
                ArrayList result = new ArrayList();
                foreach (TypeDescriptor typeDescriptor in _types)
                {
                    if (typeDescriptor.Attributes.Contains(typeof(FluorineFx.RemotingServiceAttribute).Name))
                        result.Add(typeDescriptor);
                }
                return result.ToArray(typeof(TypeDescriptor)) as TypeDescriptor[];
            }
        }

        public TypeDescriptor[] TransferObjects
        {
            get
            {
                ArrayList result = new ArrayList();
                foreach (TypeDescriptor typeDescriptor in _types)
                {
                    if (typeDescriptor.Attributes.Contains(typeof(FluorineFx.TransferObjectAttribute).Name))
                        result.Add(typeDescriptor);
                }
                return result.ToArray(typeof(TypeDescriptor)) as TypeDescriptor[];
            }
        }
	}
}
