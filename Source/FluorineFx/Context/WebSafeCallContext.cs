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
#if !FXCLIENT
using System.Web;
#endif
using System.Runtime.Remoting.Messaging;

namespace FluorineFx.Context
{
    sealed class WebSafeCallContext
    {
        private WebSafeCallContext()
        {
        }

        public static object GetData(string name)
        {
#if !FXCLIENT
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
                return CallContext.GetData(name);
            else
                return ctx.Items[name];
#else
            return CallContext.GetData(name);
#endif
        }

        public static void SetData(string name, object value)
        {
#if !FXCLIENT
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
                CallContext.SetData(name, value);
            else
                ctx.Items[name] = value;
#else
            CallContext.SetData(name, value);
#endif
        }

        public static void FreeNamedDataSlot(string name)
        {
#if !FXCLIENT
            HttpContext ctx = HttpContext.Current;
            if (ctx == null)
                CallContext.FreeNamedDataSlot(name);
            else
                ctx.Items.Remove(name);
#else
            CallContext.FreeNamedDataSlot(name);
#endif
        }
    }
}
