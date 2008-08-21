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

namespace FluorineFx.Messaging.Rtmp.SO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	class SharedObjectTypeMapping
	{
		private static SharedObjectEventType[] _typeMap = new SharedObjectEventType[] 
			{
				SharedObjectEventType.Unknown,
				SharedObjectEventType.SERVER_CONNECT, // 01
				SharedObjectEventType.SERVER_DISCONNECT, // 02
				SharedObjectEventType.SERVER_SET_ATTRIBUTE, // 03
				SharedObjectEventType.CLIENT_UPDATE_DATA, // 04 
				SharedObjectEventType.CLIENT_UPDATE_ATTRIBUTE, // 05
				SharedObjectEventType.SERVER_SEND_MESSAGE, // 06
				SharedObjectEventType.CLIENT_STATUS, // 07
				SharedObjectEventType.CLIENT_CLEAR_DATA, // 08
				SharedObjectEventType.CLIENT_DELETE_DATA, // 09
				SharedObjectEventType.SERVER_DELETE_ATTRIBUTE, // 0A
				SharedObjectEventType.CLIENT_INITIAL_DATA, // 0B
			};

		public static SharedObjectEventType ToType(byte rtmpType) 
		{
			return _typeMap[rtmpType];
		}

		public static byte ToByte(SharedObjectEventType type) 
		{
			switch (type) 
			{
				case SharedObjectEventType.SERVER_CONNECT:
					return 0x01;
				case SharedObjectEventType.SERVER_DISCONNECT:
					return 0x02;
				case SharedObjectEventType.SERVER_SET_ATTRIBUTE:
					return 0x03;
				case SharedObjectEventType.CLIENT_UPDATE_DATA:
					return 0x04;
				case SharedObjectEventType.CLIENT_UPDATE_ATTRIBUTE:
					return 0x05;
				case SharedObjectEventType.SERVER_SEND_MESSAGE:
					return 0x06;
				case SharedObjectEventType.CLIENT_SEND_MESSAGE:
					return 0x06;
				case SharedObjectEventType.CLIENT_STATUS:
					return 0x07;
				case SharedObjectEventType.CLIENT_CLEAR_DATA:
					return 0x08;
				case SharedObjectEventType.CLIENT_DELETE_DATA:
					return 0x09;
				case SharedObjectEventType.SERVER_DELETE_ATTRIBUTE:
					return 0x0A;
				case SharedObjectEventType.CLIENT_INITIAL_DATA:
					return 0x0B;
				default:
					//log.error("Unknown type " + type);
					return 0x00;
			}
		}

		public static string ToString(SharedObjectEventType type) 
		{
			switch (type) 
			{
				case SharedObjectEventType.SERVER_CONNECT:
					return "server connect";
				case SharedObjectEventType.SERVER_DISCONNECT:
					return "server disconnect";
				case SharedObjectEventType.SERVER_SET_ATTRIBUTE:
					return "server_set_attribute";
				case SharedObjectEventType.CLIENT_UPDATE_DATA:
					return "client_update_data";
				case SharedObjectEventType.CLIENT_UPDATE_ATTRIBUTE:
					return "client_update_attribute";
				case SharedObjectEventType.SERVER_SEND_MESSAGE:
					return "server_send_message";
				case SharedObjectEventType.CLIENT_SEND_MESSAGE:
					return "client_send_message";
				case SharedObjectEventType.CLIENT_STATUS:
					return "client_status";
				case SharedObjectEventType.CLIENT_CLEAR_DATA:
					return "client_clear_data";
				case SharedObjectEventType.CLIENT_DELETE_DATA:
					return "client_delete_data";
				case SharedObjectEventType.SERVER_DELETE_ATTRIBUTE:
					return "server_delete_attribute";
				case SharedObjectEventType.CLIENT_INITIAL_DATA:
					return "client_initial_data";
				default:
					//log.error("Unknown type " + type);
					return "unknown";
			}
		}
	}
}
