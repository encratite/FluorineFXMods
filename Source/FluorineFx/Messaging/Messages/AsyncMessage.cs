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

namespace FluorineFx.Messaging.Messages
{
	/// <summary>
	/// AsyncMessage contains information necessary to perform point-to-point or publish-subscribe messaging.
	/// </summary>
    [CLSCompliant(false)]
    public class AsyncMessage : MessageBase
	{
		/// <summary>
		/// Messages sent by a MessageAgent with a defined subtopic property indicate their target subtopic in this header.
		/// </summary>
		public const string SubtopicHeader = "DSSubtopic";
        /// <summary>
        /// Correlation id for the AsyncMessage.
        /// </summary>
		protected string _correlationId;
		/// <summary>
		/// Initializes a new instance of the AsyncMessage class.
		/// </summary>
		public AsyncMessage()
		{
		}
		/// <summary>
		/// Gets or sets the correlation id of the message.
		/// </summary>
		/// <remarks>
		/// Used for acknowledgement and for segmentation of messages. The correlationId contains the messageId of the previous message that this message refers to.
		/// </remarks>
		public string correlationId
		{
			get{ return _correlationId; }
			set{ _correlationId = value; }
		}
	}
}
