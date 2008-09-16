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
using FluorineFx.Util;
using FluorineFx.IO;

namespace FluorineFx.IO.FLV
{
    /// <summary>
    /// MetaData service.
    /// </summary>
    [CLSCompliant(false)]
    public class MetaService
    {
        private FileInfo _file;
        private Stream _input;

        public Stream Input
        {
            get { return _input; }
            set { _input = value; }
        }

        private Stream _output;

        public Stream Output
        {
            get { return _output; }
            set { _output = value; }
        }

        private AMFReader _deserializer;

        public AMFReader Deserializer
        {
            get { return _deserializer; }
            set { _deserializer = value; }
        }
        private AMFWriter _serializer;

        public AMFWriter Serializer
        {
            get { return _serializer; }
            set { _serializer = value; }
        }

        public MetaService()
        {
        }

        public MetaService(FileInfo file)
        {
            _file = file;
        }

        public void Write(MetaData meta)
        {
            // Get cue points, FLV reader and writer
            MetaCue[] metaArr = meta.MetaCue;
            FlvReader reader = new FlvReader(_file, false);
            FlvWriter writer = new FlvWriter(_output, false);
            ITag tag = null;

            // Read first tag
            if (reader.HasMoreTags())
            {
                tag = reader.ReadTag();
                if (tag.DataType == IOConstants.TYPE_METADATA)
                {
                    if (!reader.HasMoreTags())
                        throw new IOException("File we're writing is metadata only?");
                }
            }

            meta.Duration = (double)reader.Duration / 1000;
            meta.VideoCodecId = reader.VideoCodecId;
            meta.AudioCodecId = reader.AudioCodecId;

            ITag injectedTag = InjectMetaData(meta, tag);
            injectedTag.PreviousTagSize = 0;
            tag.PreviousTagSize = injectedTag.BodySize;

            writer.WriteHeader();
            writer.WriteTag(injectedTag);
            writer.WriteTag(tag);

            int cuePointTimeStamp = 0;
            int counter = 0;

            if (metaArr != null)
            {
                Array.Sort(metaArr);
                cuePointTimeStamp = GetTimeInMilliseconds(metaArr[0]);
            }

            while (reader.HasMoreTags())
            {
                tag = reader.ReadTag();

                // if there are cuePoints in the array 
                if (counter < metaArr.Length)
                {

                    // If the tag has a greater timestamp than the
                    // cuePointTimeStamp, then inject the tag
                    while (tag.Timestamp > cuePointTimeStamp)
                    {

                        injectedTag = InjectMetaCue(metaArr[counter], tag);
                        writer.WriteTag(injectedTag);

                        tag.PreviousTagSize = injectedTag.BodySize;

                        // Advance to the next CuePoint
                        counter++;

                        if (counter > (metaArr.Length - 1))
                        {
                            break;
                        }

                        cuePointTimeStamp = GetTimeInMilliseconds(metaArr[counter]);

                    }
                }

                if (tag.DataType != IOConstants.TYPE_METADATA)
                {
                    writer.WriteTag(tag);
                }

            }
            writer.Close();
        }

        /// <summary>
        /// Injects metadata (other than Cue points) into a tag.
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private ITag InjectMetaData(MetaData meta, ITag tag)
        {
            MemoryStream ms = new MemoryStream();
            AMFWriter writer = new AMFWriter(ms);
            writer.WriteData(ObjectEncoding.AMF0, "onMetaData");
            writer.WriteData(ObjectEncoding.AMF0, meta);
            byte[] buffer = ms.ToArray();
            return new Tag(IOConstants.TYPE_METADATA, 0, buffer.Length, buffer, tag.PreviousTagSize);
        }

        /// <summary>
        /// Injects metadata (Cue Points) into a tag.
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        private ITag InjectMetaCue(MetaCue meta, ITag tag)
        {
            MemoryStream ms = new MemoryStream();
            AMFWriter writer = new AMFWriter(ms);
            writer.WriteData(ObjectEncoding.AMF0, "onCuePoint");
            writer.WriteData(ObjectEncoding.AMF0, meta);
            byte[] buffer = ms.ToArray();
            return new Tag(IOConstants.TYPE_METADATA, GetTimeInMilliseconds(meta), buffer.Length, buffer, tag.PreviousTagSize);
        }

        /// <summary>
        /// Returns a timestamp of cue point in milliseconds.
        /// </summary>
        /// <param name="metaCue"></param>
        /// <returns></returns>
        private int GetTimeInMilliseconds(MetaCue metaCue)
        {
            return (int)(metaCue.Time * 1000.00);
        }

        public void WriteMetaData(MetaData metaData)
        {
        }

	    public MetaData ReadMetaData(byte[] buffer) 
        {
		    MetaData retMeta = new MetaData();
            MemoryStream ms = new MemoryStream(buffer);
            AMFReader reader = new AMFReader(ms);
            string metaType = reader.ReadData() as string;
            IDictionary data = reader.ReadData() as IDictionary;
		    retMeta.PutAll(data);
		    return retMeta;
	    }

        public MetaCue[] ReadMetaCue()
        {
            return null;
        }
    }
}
