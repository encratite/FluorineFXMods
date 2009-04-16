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
using System.Reflection;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
#if !SILVERLIGHT
using log4net;
#endif
using FluorineFx.AMF3;
using FluorineFx.Configuration;
using FluorineFx.Util;
using FluorineFx.Exceptions;

namespace FluorineFx.IO
{
    class ASObjectProxy : IObjectProxy
    {
#if !SILVERLIGHT
        private static readonly ILog log = LogManager.GetLogger(typeof(ASObjectProxy));
#endif

        #region IObjectProxy Members

        public bool GetIsExternalizable(object instance)
        {
            return false;
        }

        public bool GetIsDynamic(object instance)
        {
            return (instance as ASObject).IsTypedObject;
        }

        public ClassDefinition GetClassDefinition(object instance)
        {
            ClassDefinition classDefinition = null;
            ASObject aso = instance as ASObject;
            if (aso.IsTypedObject)
            {
                ClassMember[] classMemberList = new ClassMember[aso.Count];
                int i = 0;
#if !(NET_1_1)
                foreach (KeyValuePair<string, object> entry in aso)
#else
				foreach(DictionaryEntry entry in aso)
#endif
                {
                    ClassMember classMember = new ClassMember(entry.Key as string, BindingFlags.Default, MemberTypes.Custom, null);
                    classMemberList[i] = classMember;
                    i++;
                }
                string customClassName = aso.TypeName;
                classDefinition = new ClassDefinition(customClassName, classMemberList, false, false);
            }
            else
            {
                string customClassName = string.Empty;
                classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, false, true);
            }
            return classDefinition;
        }

        public object GetValue(object instance, ClassMember member)
        {
            ASObject aso = instance as ASObject;
            if (aso.ContainsKey(member.Name))
                return aso[member.Name];
            string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("ASObject[{0}]", member.Name));
            throw new FluorineException(msg);
        }

        public void SetValue(object instance, ClassMember member, object value)
        {
            ASObject aso = instance as ASObject;
            aso[member.Name] = value;
        }

        #endregion
    }
}
