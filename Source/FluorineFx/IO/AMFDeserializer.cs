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
using System.IO;
using log4net;
using FluorineFx.Configuration;
using FluorineFx.Context;

namespace FluorineFx.IO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFDeserializer : AMFReader
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(AMFDeserializer));

		ArrayList _failedAMFBodies;

		/// <summary>
		/// Initializes a new instance of the AMFDeserializer class.
		/// </summary>
		/// <param name="stream"></param>
		public AMFDeserializer(Stream stream) : base(stream)
		{
			_failedAMFBodies = new ArrayList(1);
            this.FaultTolerancy = true;
		}
        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        /// <returns></returns>
        [CLSCompliant(false)]
        public AMFMessage ReadAMFMessage()
		{
			// Version stored in the first two bytes.
			ushort version = base.ReadUInt16();
			AMFMessage message = new AMFMessage(version);
			// Read header count.
			int headerCount = base.ReadUInt16();
			for (int i = 0; i < headerCount; i++)
			{
				message.AddHeader(this.ReadHeader());
			}
			// Read header count.
			int bodyCount = base.ReadUInt16();
			for (int i = 0; i < bodyCount; i++)
			{
                AMFBody amfBody = this.ReadBody();
				if( amfBody != null )//not failed
					message.AddBody(amfBody);
			}
			return message;
		}

		private AMFHeader ReadHeader()
		{
            this.Reset();
			// Read name.
			string name = base.ReadString();
			// Read must understand flag.
			bool mustUnderstand = base.ReadBoolean();
			// Read the length of the header.
			int length = base.ReadInt32();
			// Read content.
			object content = base.ReadData();
			return new AMFHeader(name, mustUnderstand, content);
		}

		private AMFBody ReadBody()
		{
			this.Reset();
			string target = base.ReadString();

			// Response that the client understands.
			string response = base.ReadString();
			int length = base.ReadInt32();
			if( base.BaseStream.CanSeek )
			{
				long position = base.BaseStream.Position;
				// Read content.
				try
				{
					object content = base.ReadData();
                    AMFBody amfBody = new AMFBody(target, response, content);
                    Exception exception = this.GetLastError();
                    if (exception != null)
                    {
                        ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                        _failedAMFBodies.Add(errorResponseBody);
                        if (log.IsFatalEnabled)
                            log.Fatal(__Res.GetString(__Res.Amf_ReadBodyFail), exception);
                        return null;
                    }
                    return amfBody;
				}
				catch(Exception exception)
				{
					base.BaseStream.Position = position + length;
					//FluorineContext.Current.Fail( new AMFBody(target, response, null), exception);

                    //Try to build a valid response from partialy deserialized amf body
                    AMFBody amfBody = new AMFBody(target, response, null);
                    ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                    _failedAMFBodies.Add(errorResponseBody);
					if( log.IsFatalEnabled )
						log.Fatal(__Res.GetString(__Res.Amf_ReadBodyFail), exception);
					return null;
				}
			}
			else
			{
				try
				{
					object content = base.ReadData();
                    AMFBody amfBody = new AMFBody(target, response, content);
                    Exception exception = this.GetLastError();
                    if (exception != null)
                    {
                        ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                        _failedAMFBodies.Add(errorResponseBody);
                        if (log.IsFatalEnabled)
                            log.Fatal(__Res.GetString(__Res.Amf_ReadBodyFail), exception);
                        return null;
                    }
                    return amfBody;
                }
				catch(Exception exception)
				{
                    //Try to build a valid response from partialy deserialized amf body
                    AMFBody amfBody = new AMFBody(target, response, null);
                    ErrorResponseBody errorResponseBody = GetErrorBody(amfBody, exception);
                    _failedAMFBodies.Add(errorResponseBody);

					if( log.IsFatalEnabled )
                        log.Fatal(__Res.GetString(__Res.Amf_ReadBodyFail), exception);
					throw;
				}
			}
		}

        private ErrorResponseBody GetErrorBody(AMFBody amfBody, Exception exception)
        {
            ErrorResponseBody errorResponseBody = null;
            try
            {
                object content = amfBody.Content;
                if (content is IList)
                    content = (content as IList)[0];
                if (content is FluorineFx.Messaging.Messages.IMessage)
                    errorResponseBody = new ErrorResponseBody(amfBody, content as FluorineFx.Messaging.Messages.IMessage, exception);
                else
                    errorResponseBody = new ErrorResponseBody(amfBody, exception);
            }
            catch
            {
                errorResponseBody = new ErrorResponseBody(amfBody, exception);
            }
            return errorResponseBody;
        }

        /// <summary>
        /// This method supports the Fluorine infrastructure and is not intended to be used directly from your code.
        /// </summary>
        [CLSCompliant(false)]
        public AMFBody[] FailedAMFBodies
		{ 
			get
			{
				return _failedAMFBodies.ToArray(typeof(AMFBody)) as AMFBody[];
			}
		}
	}
}
