/*
	FluorineFx open source library 
	Copyright (C) 2010 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
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
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.InteropServices;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Xml;
using System.ServiceModel.Security;
using System.ServiceModel.Description;
using FluorineFx;
using FluorineFx.IO;

namespace FluorineFx.WCF.Channels
{
    /// <summary>
    /// This class is used to create the custom encoder (FluorineMessageEncoder)
    /// </summary>
    class FluorineLegacyMessageEncoderFactory : MessageEncoderFactory
    {
        MessageEncoder encoder;

        public FluorineLegacyMessageEncoderFactory()
        {
            encoder = new FluorineLegacyMessageEncoder();

        }

        /// <summary>
        /// The service framework uses this property to obtain an encoder from this encoder factory.
        /// </summary>
        public override MessageEncoder Encoder
        {
            get { return encoder; }
        }

        public override MessageVersion MessageVersion
        {
            get { return encoder.MessageVersion; }
        }

        //This is the actual Amf encoder
        class FluorineLegacyMessageEncoder : MessageEncoder
        {
            static string AmfContentType = "application/x-amf";

            internal FluorineLegacyMessageEncoder()
                : base()
            {
            }

            public override string ContentType
            {
                get { return AmfContentType; }
            }

            public override string MediaType
            {
                get { return AmfContentType; }
            }

            //SOAP version to use - we delegate to the inner encoder for this
            public override MessageVersion MessageVersion
            {
                get { return MessageVersion.None; }
            }

            //One of the two main entry points into the encoder. Called by WCF to decode a buffered byte array into a Message.
            public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
            {
                MemoryStream memoryStream = new MemoryStream(buffer.Array, buffer.Offset, buffer.Count - buffer.Offset);
                AMFDeserializer amfDeserializer = new AMFDeserializer(memoryStream);
                AMFMessage amfMessage = amfDeserializer.ReadAMFMessage();
                Message returnMessage = Message.CreateMessage(MessageVersion.None, null);
                returnMessage.Properties.Add("amf", amfMessage);
                return returnMessage;
            }

            //One of the two main entry points into the encoder. Called by WCF to encode a Message into a buffered byte array.
            public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
            {
                MemoryStream memoryStream = new MemoryStream();
                AMFMessage amfMessage = message.Properties["amf"] as AMFMessage;
                AMFSerializer serializer = new AMFSerializer(memoryStream);
                serializer.WriteMessage(amfMessage);
                serializer.Flush();
                byte[] buffer = memoryStream.ToArray();
                ArraySegment<byte> byteArray = new ArraySegment<byte>(buffer);
                return byteArray;
            }

            public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
            {
                /*
                GZipStream gzStream = new GZipStream(stream, CompressionMode.Decompress, true);
                return innerEncoder.ReadMessage(gzStream, maxSizeOfHeaders);
                 */
                return null;
            }

            public override void WriteMessage(Message message, System.IO.Stream stream)
            {
                /*
                using (GZipStream gzStream = new GZipStream(stream, CompressionMode.Compress, true))
                {
                    innerEncoder.WriteMessage(message, gzStream);
                }

                // innerEncoder.WriteMessage(message, gzStream) depends on that it can flush data by flushing 
                // the stream passed in, but the implementation of GZipStream.Flush will not flush underlying
                // stream, so we need to flush here.
                stream.Flush();
                 */
            }
        }
    }
}
