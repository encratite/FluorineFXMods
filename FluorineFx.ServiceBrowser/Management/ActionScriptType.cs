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

namespace FluorineFx.Management
{
    /// <summary>
    /// Summary description for TypeDescriptor.
    /// </summary>
    [Serializable]
    public class ActionScriptType : NamedObject
    {
        string _namespace;
        bool _intrinsic;

        public ActionScriptType()
        {
        }

        public ActionScriptType(string type)
            : base(type)
        {
            _namespace = string.Empty;
            _intrinsic = false;
        }

        public ActionScriptType(string ns, string type)
            : base(type)
        {
            _namespace = ns;
            _intrinsic = false;
        }

        public ActionScriptType(string ns, string type, bool intrinsic)
            : base(type)
        {
            _namespace = ns;
            _intrinsic = intrinsic;
        }

        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }

        public bool Intrinsic
        {
            get { return _intrinsic; }
            set { _intrinsic = value; }
        }

        public override string ToString()
        {
            if( _namespace != null && _namespace != string.Empty )
                return _namespace + "." + this.Name;
            return this.Name;
        }
    }
}
