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

namespace FluorineFx.Net
{
    /// <summary>
    /// Base event arguments for connection events.
    /// </summary>
    public class NetStatusEventArgs : EventArgs
    {
        Exception _exception;
        ASObject _info;

        internal NetStatusEventArgs(Exception exception)
        {
            _exception = exception;
            _info = new ASObject();
            _info["level"] = "error";
            _info["code"] = "NetConnection.Call.BadVersion";
            _info["description"] = exception.Message;
        }

        internal NetStatusEventArgs(string message)
        {
            _info = new ASObject();
            _info["level"] = "error";
            _info["code"] = "NetConnection.Call.BadVersion";
            _info["description"] = message;
        }

        internal NetStatusEventArgs(ASObject info)
        {
            _info = info;
        }

        #region Properties

        public Exception Exception
        {
            get { return _exception; }
        }

        public ASObject Info
        {
            get { return _info; }
        }

        #endregion
    }
}
