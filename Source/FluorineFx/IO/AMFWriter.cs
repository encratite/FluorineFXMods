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
using System.Xml;
using System.IO;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using FluorineFx.Exceptions;
using FluorineFx.AMF3;
using FluorineFx.Configuration;
using FluorineFx.IO.Writers;
using FluorineFx.Collections;
using FluorineFx.Util;
#if !(NET_1_1)
using System.Collections.Generic;
#endif
#if !(NET_1_1) && !(NET_2_0)
using System.Xml.Linq;
#endif
#if SILVERLIGHT
using System.Xml.Linq;
#else
using System.Data;
using log4net;
#endif

namespace FluorineFx.IO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFWriter : BinaryWriter
	{
#if !SILVERLIGHT
		private static readonly ILog log = LogManager.GetLogger(typeof(AMFWriter));
#endif

		bool _useLegacyCollection = true;
#if !(NET_1_1)
        Dictionary<Object, int> _amf0ObjectReferences;
        Dictionary<Object, int> _objectReferences;
        Dictionary<Object, int> _stringReferences;
        Dictionary<ClassDefinition, int> _classDefinitionReferences;
        static Dictionary<string, ClassDefinition> classDefinitions;
        static Dictionary<Type, IAMFWriter>[] AmfWriterTable;
#else
        Hashtable	_amf0ObjectReferences;
		Hashtable	_objectReferences;
		Hashtable	_stringReferences;
		Hashtable	_classDefinitionReferences;
        static Hashtable classDefinitions;
        static Hashtable[] AmfWriterTable;
#endif

        static AMFWriter()
		{
#if !(NET_1_1)
            Dictionary<Type, IAMFWriter> amf0Writers = new Dictionary<Type, IAMFWriter>();
#else
			Hashtable amf0Writers = new Hashtable();
#endif
			AMF0NumberWriter amf0NumberWriter = new AMF0NumberWriter();
			amf0Writers.Add(typeof(System.SByte), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Byte), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Int16), amf0NumberWriter);
			amf0Writers.Add(typeof(System.UInt16), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Int32), amf0NumberWriter);
			amf0Writers.Add(typeof(System.UInt32), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Int64), amf0NumberWriter);
			amf0Writers.Add(typeof(System.UInt64), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Single), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Double), amf0NumberWriter);
			amf0Writers.Add(typeof(System.Decimal), amf0NumberWriter);
			amf0Writers.Add(typeof(System.DBNull), new AMF0NullWriter());
#if !SILVERLIGHT
			AMF0SqlTypesWriter amf0SqlTypesWriter = new AMF0SqlTypesWriter();
			amf0Writers.Add(typeof(System.Data.SqlTypes.INullable), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlByte), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlInt16), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlInt32), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlInt64), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlSingle), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlDouble), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlDecimal), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlMoney), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlDateTime), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlString), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlGuid), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlBinary), amf0SqlTypesWriter);
			amf0Writers.Add(typeof(System.Data.SqlTypes.SqlBoolean), amf0SqlTypesWriter);

            amf0Writers.Add(typeof(CacheableObject), new AMF0CacheableObjectWriter());
			amf0Writers.Add(typeof(XmlDocument), new AMF0XmlDocumentWriter());
			amf0Writers.Add(typeof(DataTable), new AMF0DataTableWriter());
			amf0Writers.Add(typeof(DataSet), new AMF0DataSetWriter());
            amf0Writers.Add(typeof(RawBinary), new RawBinaryWriter());
            amf0Writers.Add(typeof(System.Collections.Specialized.NameObjectCollectionBase), new AMF0NameObjectCollectionWriter());
#endif
#if !(NET_1_1) && !(NET_2_0)
            amf0Writers.Add(typeof(XDocument), new AMF0XDocumentWriter());
            amf0Writers.Add(typeof(XElement), new AMF0XElementWriter());
#endif
            amf0Writers.Add(typeof(Guid), new AMF0GuidWriter());
			amf0Writers.Add(typeof(string), new AMF0StringWriter());
			amf0Writers.Add(typeof(bool), new AMF0BooleanWriter());
			amf0Writers.Add(typeof(Enum), new AMF0EnumWriter());
			amf0Writers.Add(typeof(Char), new AMF0CharWriter());
            amf0Writers.Add(typeof(DateTime), new AMF0DateTimeWriter());
			amf0Writers.Add(typeof(Array), new AMF0ArrayWriter());
			amf0Writers.Add(typeof(ASObject), new AMF0ASObjectWriter());

#if !(NET_1_1)
            Dictionary<Type, IAMFWriter> amf3Writers = new Dictionary<Type, IAMFWriter>();
#else
			Hashtable amf3Writers = new Hashtable();
#endif
			AMF3IntWriter amf3IntWriter = new AMF3IntWriter();
			AMF3DoubleWriter amf3DoubleWriter = new AMF3DoubleWriter();
			amf3Writers.Add(typeof(System.SByte), amf3IntWriter);
			amf3Writers.Add(typeof(System.Byte), amf3IntWriter);
			amf3Writers.Add(typeof(System.Int16), amf3IntWriter);
			amf3Writers.Add(typeof(System.UInt16), amf3IntWriter);
			amf3Writers.Add(typeof(System.Int32), amf3IntWriter);
			amf3Writers.Add(typeof(System.UInt32), amf3IntWriter);
			amf3Writers.Add(typeof(System.Int64), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.UInt64), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.Single), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.Double), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.Decimal), amf3DoubleWriter);
			amf3Writers.Add(typeof(System.DBNull), new AMF3DBNullWriter());
#if !SILVERLIGHT
            AMF3SqlTypesWriter amf3SqlTypesWriter = new AMF3SqlTypesWriter();
			amf3Writers.Add(typeof(System.Data.SqlTypes.INullable), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlByte), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlInt16), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlInt32), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlInt64), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlSingle), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlDouble), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlDecimal), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlMoney), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlDateTime), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlString), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlGuid), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlBinary), amf3SqlTypesWriter);
			amf3Writers.Add(typeof(System.Data.SqlTypes.SqlBoolean), amf3SqlTypesWriter);

            amf3Writers.Add(typeof(CacheableObject), new AMF3CacheableObjectWriter());
			amf3Writers.Add(typeof(XmlDocument), new AMF3XmlDocumentWriter());
			amf3Writers.Add(typeof(DataTable), new AMF3DataTableWriter());
			amf3Writers.Add(typeof(DataSet), new AMF3DataSetWriter());
            amf3Writers.Add(typeof(RawBinary), new RawBinaryWriter());            
            amf3Writers.Add(typeof(System.Collections.Specialized.NameObjectCollectionBase), new AMF3NameObjectCollectionWriter());
#endif
#if !(NET_1_1) && !(NET_2_0)
            amf3Writers.Add(typeof(XDocument), new AMF3XDocumentWriter());
            amf3Writers.Add(typeof(XElement), new AMF3XElementWriter());
#endif
            amf3Writers.Add(typeof(Guid), new AMF3GuidWriter());
			amf3Writers.Add(typeof(string), new AMF3StringWriter());
			amf3Writers.Add(typeof(bool), new AMF3BooleanWriter());
			amf3Writers.Add(typeof(Enum), new AMF3EnumWriter());
			amf3Writers.Add(typeof(Char), new AMF3CharWriter());
            amf3Writers.Add(typeof(DateTime), new AMF3DateTimeWriter());
			amf3Writers.Add(typeof(Array), new AMF3ArrayWriter());
			amf3Writers.Add(typeof(ASObject), new AMF3ASObjectWriter());
			amf3Writers.Add(typeof(ByteArray), new AMF3ByteArrayWriter());
			//amf3Writers.Add(typeof(byte[]), new AMF3ByteArrayWriter());

#if !(NET_1_1)
            AmfWriterTable = new Dictionary<Type, IAMFWriter>[4] { amf0Writers, null, null, amf3Writers };
            classDefinitions = new Dictionary<string, ClassDefinition>();
#else
			AmfWriterTable = new Hashtable[4]{amf0Writers, null, null, amf3Writers};
            classDefinitions = new Hashtable();
#endif
        }

		/// <summary>
		/// Initializes a new instance of the AMFReader class based on the supplied stream and using UTF8Encoding.
		/// </summary>
		/// <param name="stream"></param>
		public AMFWriter(Stream stream) : base(stream)
		{
			Reset();
		}

        internal AMFWriter(AMFWriter writer, Stream stream)
            : base(stream)
        {
            _amf0ObjectReferences = writer._amf0ObjectReferences;
            _objectReferences = writer._objectReferences;
            _stringReferences = writer._stringReferences;
            _classDefinitionReferences = writer._classDefinitionReferences;
            _useLegacyCollection = writer._useLegacyCollection;
        }

		public void Reset()
		{
#if !(NET_1_1)
            _amf0ObjectReferences = new Dictionary<Object, int>(5);
            _objectReferences = new Dictionary<Object, int>(5);
            _stringReferences = new Dictionary<Object, int>(5);
            _classDefinitionReferences = new Dictionary<ClassDefinition, int>();
#else
			_amf0ObjectReferences = new Hashtable(5);
			_objectReferences = new Hashtable(5);
			_stringReferences = new Hashtable(5);
			_classDefinitionReferences = new Hashtable();
#endif
        }

		public bool UseLegacyCollection
		{
			get{ return _useLegacyCollection; }
			set{ _useLegacyCollection = value; }
		}

		public void WriteByte(byte value)
		{
			this.BaseStream.WriteByte(value);
		}

		public void WriteByte(int value)
		{
			this.BaseStream.WriteByte((byte)value);
		}

		public void WriteBytes(byte[] buffer)
		{
			for(int i = 0; buffer != null && i < buffer.Length; i++)
				this.BaseStream.WriteByte(buffer[i]);
		}

		public void WriteShort(int n)
		{
			byte[] bytes = BitConverter.GetBytes((ushort)n);
			WriteBigEndian(bytes);
		}

		public void WriteString(string str)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding(true, true);
			int byteCount = utf8Encoding.GetByteCount(str);
			if( byteCount < 65536 )
			{
				WriteByte(AMF0TypeCode.String);
				WriteUTF(str);
			}
			else
			{
				WriteByte(AMF0TypeCode.LongString);
				WriteLongUTF(str);
			}
		}

		public void WriteUTF(string str)
		{
			//null string is not accepted
			//in case of custom serialization TypeError: Error #2007: Parameter value must be non-null.  at flash.utils::ObjectOutput/writeUTF()

			//Length - max 65536.
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			int byteCount = utf8Encoding.GetByteCount(str);
			byte[] buffer = utf8Encoding.GetBytes(str);
			this.WriteShort(byteCount);
			if (buffer.Length > 0)
				base.Write(buffer);
		}

		public void WriteUTFBytes(string value)
		{
			//Length - max 65536.
			UTF8Encoding utf8Encoding = new UTF8Encoding();
			byte[] buffer = utf8Encoding.GetBytes(value);
			if (buffer.Length > 0)
				base.Write(buffer);
		}

		protected void WriteLongUTF(string str)
		{
			UTF8Encoding utf8Encoding = new UTF8Encoding(true, true);
			uint byteCount = (uint)utf8Encoding.GetByteCount(str);
			byte[] buffer = new Byte[byteCount+4];
			//unsigned long (always 32 bit, big endian byte order)
			buffer[0] = (byte)((byteCount >> 0x18) & 0xff);
			buffer[1] = (byte)((byteCount >> 0x10) & 0xff);
			buffer[2] = (byte)((byteCount >> 8) & 0xff);
			buffer[3] = (byte)((byteCount & 0xff));
			int bytesEncodedCount = utf8Encoding.GetBytes(str, 0, str.Length, buffer, 4);

            if (buffer.Length > 0)
                base.BaseStream.Write(buffer, 0, buffer.Length);
		}

		
		public void WriteData(ObjectEncoding objectEncoding, object data)
		{
			//If we have ObjectEncoding.AMF3 anything that serializes to String, Number, Boolean, Date will use AMF0 encoding
			//For other types we have to switch the encoding to AMF3
			if( data == null )
			{
				WriteNull();
				return;
			}
			Type type = data.GetType();
            if (FluorineConfiguration.Instance.AcceptNullValueTypes && FluorineConfiguration.Instance.NullableValues != null)
			{
				if( FluorineConfiguration.Instance.NullableValues.ContainsKey(type) && data.Equals(FluorineConfiguration.Instance.NullableValues[type]) )
				{
					WriteNull();
					return;
				}
			}
			if( _amf0ObjectReferences.ContainsKey( data ) )
			{
				WriteReference( data );
				return;
			}

            IAMFWriter amfWriter = null;
            if( AmfWriterTable[0].ContainsKey(type) )
                amfWriter = AmfWriterTable[0][type] as IAMFWriter;
			//Second try with basetype (enums and arrays for example)
            if (amfWriter == null && AmfWriterTable[0].ContainsKey(type.BaseType))
                amfWriter = AmfWriterTable[0][type.BaseType] as IAMFWriter;

			if( amfWriter == null )
			{
				lock(AmfWriterTable)
				{
                    if (!AmfWriterTable[0].ContainsKey(type))
					{
						amfWriter = new AMF0ObjectWriter();
						AmfWriterTable[0].Add(type, amfWriter);
					}
					else
						amfWriter = AmfWriterTable[0][type] as IAMFWriter;
				}
			}

			if( amfWriter != null )
			{
				if( objectEncoding == ObjectEncoding.AMF0 )
					amfWriter.WriteData(this, data);
				else
				{
					if( amfWriter.IsPrimitive )
						amfWriter.WriteData(this, data);
					else
					{
						WriteByte(AMF0TypeCode.AMF3Tag);
						WriteAMF3Data(data);
					}
				}
			}
			else
			{
                string msg = __Res.GetString(__Res.TypeSerializer_NotFound, type.FullName);
				throw new FluorineException(msg);
			}
		}

		internal void AddReference(object value)
		{
			_amf0ObjectReferences.Add( value, _amf0ObjectReferences.Count);
		}

		internal void WriteReference(object value)
		{
			//Circular references
			WriteByte(AMF0TypeCode.Reference);
			WriteShort((int)_amf0ObjectReferences[value]);
		}

		public void WriteNull()
		{
			//Write the null code (0x05) to the output stream.
			WriteByte(AMF0TypeCode.Null);
		}

		public void WriteDouble(double value)
		{
			//long tmp = BitConverter.DoubleToInt64Bits( value );
			//this.WriteLong(tmp);
            byte[] bytes = BitConverter.GetBytes(value);
            WriteBigEndian(bytes);
		}

		public void WriteFloat(float value)
		{
			byte[] bytes = BitConverter.GetBytes(value);			
			WriteBigEndian(bytes);
		}

		public void WriteInt32(int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			WriteBigEndian(bytes);
		}

        public void WriteUInt24(int value)
        {
            byte[] bytes = new byte[3];
            bytes[0] = (byte)(0xFF & (value >> 16));
            bytes[1] = (byte)(0xFF & (value >> 8));
            bytes[2] = (byte)(0xFF & (value >> 0));
            this.BaseStream.Write(bytes, 0, bytes.Length);
        }

		public void WriteBoolean(bool b)
		{
			this.BaseStream.WriteByte(b ? ((byte) 1) : ((byte) 0));
		}

		public void WriteLong(long number)
		{
			byte[] bytes = BitConverter.GetBytes(number);
			WriteBigEndian(bytes);
		}

		private void WriteBigEndian(byte[] bytes)
		{
			if( bytes == null )
				return;
			for(int i = bytes.Length-1; i >= 0; i--)
			{
				base.BaseStream.WriteByte( bytes[i] );
			}
		}

		public void WriteDateTime(DateTime date)
		{
#if !SILVERLIGHT
			if( FluorineConfiguration.Instance.TimezoneCompensation == TimezoneCompensation.Auto )
				date = date.Subtract( DateWrapper.ClientTimeZone );
#endif

			// Write date (milliseconds from 1970).
			DateTime timeStart = new DateTime(1970, 1, 1);
			TimeSpan span = date.Subtract(timeStart);
			long milliSeconds = (long)span.TotalMilliseconds;
			//long value = BitConverter.DoubleToInt64Bits((double)milliSeconds);
			//this.WriteLong(value);
            WriteDouble((double)milliSeconds);

#if !SILVERLIGHT
			span = TimeZone.CurrentTimeZone.GetUtcOffset(date);
			//whatever we write back, is ignored
			//this.WriteLong(span.TotalMinutes);
			//this.WriteShort((int)span.TotalHours);
			//this.WriteShort(65236);
			if( FluorineConfiguration.Instance.TimezoneCompensation == TimezoneCompensation.None )
				this.WriteShort(0);
			else
				this.WriteShort((int)(span.TotalMilliseconds/60000));
#else
            this.WriteShort(0);
#endif
        }

#if !SILVERLIGHT
		public void WriteXmlDocument(XmlDocument xmlDocument)
		{
			if(xmlDocument != null)
			{
				AddReference(xmlDocument);
				this.BaseStream.WriteByte((byte)15);//xml code (0x0F)
				string xml = xmlDocument.DocumentElement.OuterXml;
				this.WriteLongUTF(xml);
			}
			else
				this.WriteNull();
		}
#endif
#if !(NET_1_1) && !(NET_2_0)
        public void WriteXDocument(XDocument xDocument)
        {
            if (xDocument != null)
            {
                AddReference(xDocument);
                this.BaseStream.WriteByte((byte)15);//xml code (0x0F)
                string xml = xDocument.ToString();
                this.WriteLongUTF(xml);
            }
            else
                this.WriteNull();
        }

        public void WriteXElement(XElement xElement)
        {
            if (xElement != null)
            {
                AddReference(xElement);
                this.BaseStream.WriteByte((byte)15);//xml code (0x0F)
                string xml = xElement.ToString();
                this.WriteLongUTF(xml);
            }
            else
                this.WriteNull();
        }

#endif

		public void WriteArray(ObjectEncoding objectEcoding, Array array)
		{
			if(array == null)
				this.WriteNull();
			else
			{
				AddReference(array);
				WriteByte(10);
				WriteInt32(array.Length);
				for(int i = 0; i < array.Length; i++)
				{
					WriteData(objectEcoding, array.GetValue(i));
				}
			}
		}

		public void WriteAssociativeArray(ObjectEncoding objectEncoding, IDictionary dictionary)
		{
			if(dictionary == null)
				this.WriteNull();
			else
			{
				AddReference(dictionary);
				WriteByte(AMF0TypeCode.AssociativeArray);
				WriteInt32(dictionary.Count);
				foreach(DictionaryEntry entry in dictionary)
				{
					this.WriteUTF(entry.Key.ToString());
					this.WriteData(objectEncoding, entry.Value);
				}
				this.WriteEndMarkup();
			}
		}

		public void WriteObject(ObjectEncoding objectEncoding, object obj)
		{
			if( obj == null )
			{
				WriteNull();
				return;
			}
			AddReference(obj);

			Type type = obj.GetType();

			WriteByte(16);
			string customClass = type.FullName;
			customClass = FluorineConfiguration.Instance.GetCustomClass(customClass);

#if !SILVERLIGHT
            if( log.IsDebugEnabled )
				log.Debug(__Res.GetString(__Res.TypeMapping_Write, type.FullName, customClass));
#endif
			WriteUTF( customClass );

			PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
#if !(NET_1_1)
            List<PropertyInfo> properties = new List<PropertyInfo>(propertyInfos);
#else
            ArrayList properties = new ArrayList(propertyInfos);
#endif
            for (int i = properties.Count - 1; i >=0 ; i--)
			{
				PropertyInfo propertyInfo = properties[i] as PropertyInfo;
#if !SILVERLIGHT
                if( propertyInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0 )
					properties.RemoveAt(i);
#endif
				if( propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0 )
					properties.RemoveAt(i);
			}
			foreach(PropertyInfo propertyInfo in properties)
			{
				WriteUTF(propertyInfo.Name);
				object value = propertyInfo.GetValue(obj, null);
				WriteData( objectEncoding, value);
			}

			FieldInfo[] fieldInfos = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
#if !(NET_1_1)
            List<FieldInfo> fields = new List<FieldInfo>(fieldInfos);
#else
            ArrayList fields = new ArrayList(fieldInfos);
#endif
			for(int i = fields.Count - 1; i >=0 ; i--)
			{
				FieldInfo fieldInfo = fields[i] as FieldInfo;
#if !SILVERLIGHT
                if( fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0 )
					fields.RemoveAt(i);
#endif
				if( fieldInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0 )
					fields.RemoveAt(i);
			}
			for(int i = 0; i < fields.Count; i++)
			{
                FieldInfo fieldInfo = fields[i] as FieldInfo;
				WriteUTF(fieldInfo.Name);
				WriteData( objectEncoding, fieldInfo.GetValue(obj));
			}

			WriteEndMarkup();
		}

		public void WriteEndMarkup()
		{
			//Write the end object flag 0x00, 0x00, 0x09
			base.BaseStream.WriteByte(0);
			base.BaseStream.WriteByte(0);
			base.BaseStream.WriteByte(AMF0TypeCode.EndOfObject);
		}

		public void WriteASO(ObjectEncoding objectEncoding, ASObject asObject)
		{
			if( asObject != null )
			{
				AddReference(asObject);
				if(asObject.TypeName == null)
				{
					// Object "Object"
					this.BaseStream.WriteByte(3);
				}
				else
				{
					this.BaseStream.WriteByte(16);
					this.WriteUTF(asObject.TypeName);
				}
#if !(NET_1_1)
                foreach (KeyValuePair<string, object> entry in asObject)
#else
				foreach(DictionaryEntry entry in asObject)
#endif
                {
					this.WriteUTF(entry.Key.ToString());
					this.WriteData(objectEncoding, entry.Value);
				}
				WriteEndMarkup();
			}
			else
				WriteNull();
		}

		#region AMF3


		public void WriteAMF3Data(object data)
		{
			if( data == null )
			{
				WriteAMF3Null();
				return;
			}
			if(data is DBNull )
			{
				WriteAMF3Null();
				return;
			}
            if (FluorineConfiguration.Instance.AcceptNullValueTypes && FluorineConfiguration.Instance.NullableValues != null)
			{
				Type type = data.GetType();
				if( FluorineConfiguration.Instance.NullableValues.ContainsKey(type) && data.Equals(FluorineConfiguration.Instance.NullableValues[type]) )
				{
					WriteAMF3Null();
					return;
				}
			}

            IAMFWriter amfWriter = null;
            if( AmfWriterTable[3].ContainsKey(data.GetType()) )
                amfWriter = AmfWriterTable[3][data.GetType()] as IAMFWriter;
			//Second try with basetype (Enums for example)
            if (amfWriter == null && AmfWriterTable[3].ContainsKey(data.GetType().BaseType) )
				amfWriter = AmfWriterTable[3][data.GetType().BaseType] as IAMFWriter;

			if( amfWriter == null )
			{
				lock(AmfWriterTable)
				{
                    if (!AmfWriterTable[3].ContainsKey(data.GetType()))
                    {
                        amfWriter = new AMF3ObjectWriter();
                        AmfWriterTable[3].Add(data.GetType(), amfWriter);
                    }
                    else
                        amfWriter = AmfWriterTable[3][data.GetType()] as IAMFWriter;
				}
			}

			if( amfWriter != null )
			{
				amfWriter.WriteData(this, data);
			}
			else
			{
				string msg = string.Format("Could not find serializer for type {0}", data.GetType().FullName);
				throw new FluorineException(msg);
			}
			//WriteByte(AMF3TypeCode.Object);
			//WriteAMF3Object(data);
		}

		public void WriteAMF3Null()
		{
			//Write the null code (0x1) to the output stream.
			WriteByte(AMF3TypeCode.Null);
		}

		public void WriteAMF3Bool(bool value)
		{
			WriteByte( (byte)(value ? AMF3TypeCode.BooleanTrue : AMF3TypeCode.BooleanFalse));
		}

		public void WriteAMF3Array(Array array)
		{
            if (_amf0ObjectReferences.ContainsKey(array))
			{
				WriteReference(array);
				return;
			}

            if (!_objectReferences.ContainsKey(array))
			{
				_objectReferences.Add(array, _objectReferences.Count);
				int handle = array.Length;
				handle = handle << 1;
				handle = handle | 1;
				WriteAMF3IntegerData(handle);
				WriteAMF3UTF(string.Empty);//hash name
				for(int i = 0; i < array.Length; i++)
				{
					WriteAMF3Data(array.GetValue(i));
				}
			}
			else
			{
				int handle = (int)_objectReferences[array];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		public void WriteAMF3Array(IList value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);
				int handle = value.Count;
				handle = handle << 1;
				handle = handle | 1;
				WriteAMF3IntegerData(handle);
				WriteAMF3UTF(string.Empty);//hash name
				for(int i = 0; i < value.Count; i++)
				{
					WriteAMF3Data(value[i]);
				}
			}
			else
			{
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		public void WriteAMF3AssociativeArray(IDictionary value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);
				WriteAMF3IntegerData(1);
				foreach(DictionaryEntry entry in value)
				{
					WriteAMF3UTF(entry.Key.ToString());
					WriteAMF3Data(entry.Value);
				}
				WriteAMF3UTF(string.Empty);
			}
			else
			{
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		internal void WriteByteArray(ByteArray byteArray)
		{
			_objectReferences.Add(byteArray, _objectReferences.Count);
			WriteByte(AMF3TypeCode.ByteArray);
			int handle = (int)byteArray.Length;
			handle = handle << 1;
			handle = handle | 1;
			WriteAMF3IntegerData(handle);
			WriteBytes( byteArray.MemoryStream.ToArray() );
		}

		public void WriteAMF3UTF(string value)
		{
			if( value == string.Empty )
			{
				WriteAMF3IntegerData(1);
			}
			else
			{
                if (!_stringReferences.ContainsKey(value))
				{
					_stringReferences.Add(value, _stringReferences.Count);
					UTF8Encoding utf8Encoding = new UTF8Encoding();
					int byteCount = utf8Encoding.GetByteCount(value);
					int handle = byteCount;
					handle = handle << 1;
					handle = handle | 1;
					WriteAMF3IntegerData(handle);
					byte[] buffer = utf8Encoding.GetBytes(value);
					if (buffer.Length > 0)
						Write(buffer);
				}
				else
				{
					int handle = (int)_stringReferences[value];
					handle = handle << 1;
					WriteAMF3IntegerData(handle);
				}
			}
		}

		public void WriteAMF3String(string value)
		{
			WriteByte(AMF3TypeCode.String);
			WriteAMF3UTF(value);
		}


		public void WriteAMF3DateTime(DateTime value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);
				int handle = 1;
				WriteAMF3IntegerData(handle);

				// Write date (milliseconds from 1970).
				DateTime timeStart = new DateTime(1970, 1, 1, 0, 0, 0);

				if( FluorineConfiguration.Instance.TimezoneCompensation == TimezoneCompensation.Auto )
				{
					value = value.ToUniversalTime();
				}

				TimeSpan span = value.Subtract(timeStart);
				long milliSeconds = (long)span.TotalMilliseconds;
				//long date = BitConverter.DoubleToInt64Bits((double)milliSeconds);
				//this.WriteLong(date);
                WriteDouble((double)milliSeconds);
			}
			else
			{
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		private void WriteAMF3IntegerData(int value)
		{
			//Sign contraction - the high order bit of the resulting value must match every bit removed from the number
			//Clear 3 bits 
			value &= 0x1fffffff;
			if(value < 0x80)
				this.WriteByte(value);
			else
				if(value < 0x4000)
			{
					this.WriteByte(value >> 7 & 0x7f | 0x80);
					this.WriteByte(value & 0x7f);
			}
			else
				if(value < 0x200000)
			{
				this.WriteByte(value >> 14 & 0x7f | 0x80);
				this.WriteByte(value >> 7 & 0x7f | 0x80);
				this.WriteByte(value & 0x7f);
			} 
			else
			{
				this.WriteByte(value >> 22 & 0x7f | 0x80);
				this.WriteByte(value >> 15 & 0x7f | 0x80);
				this.WriteByte(value >> 8 & 0x7f | 0x80);
				this.WriteByte(value & 0xff);
			}
		}

		public void WriteAMF3Int(int value)
		{
			if(value >= -268435456 && value <= 268435455)//check valid range for 29bits
			{
				WriteByte(AMF3TypeCode.Integer);
				WriteAMF3IntegerData(value);
			}
			else
			{
				//overflow condition would occur upon int conversion
				WriteAMF3Double((double)value);
			}
		}

		public void WriteAMF3Double(double value)
		{
			WriteByte(AMF3TypeCode.Number);
			//long tmp = BitConverter.DoubleToInt64Bits( double.Parse(value.ToString()) );
            WriteDouble(value);
		}

#if !SILVERLIGHT
        public void WriteAMF3XmlDocument(XmlDocument xmlDocument)
		{
			WriteByte(AMF3TypeCode.Xml);
            string value = string.Empty;
            if (xmlDocument.DocumentElement != null && xmlDocument.DocumentElement.OuterXml != null )
                value = xmlDocument.DocumentElement.OuterXml;
            if (value == string.Empty)
            {
                WriteAMF3IntegerData(1);
            }
            else
            {
                if (!_objectReferences.ContainsKey(value))
                {
                    _objectReferences.Add(value, _objectReferences.Count);
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    int byteCount = utf8Encoding.GetByteCount(value);
                    int handle = byteCount;
                    handle = handle << 1;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                    byte[] buffer = utf8Encoding.GetBytes(value);
                    if (buffer.Length > 0)
                        Write(buffer);
                }
                else
                {
                    int handle = (int)_objectReferences[value];
                    handle = handle << 1;
                    WriteAMF3IntegerData(handle);
                }
            }
		}
#endif
#if !(NET_1_1) && !(NET_2_0)
        public void WriteAMF3XDocument(XDocument xDocument)
        {
            WriteByte(AMF3TypeCode.Xml);
            string value = string.Empty;
            if (xDocument != null)
                value = xDocument.ToString();
            if (value == string.Empty)
            {
                WriteAMF3IntegerData(1);
            }
            else
            {
                if (!_objectReferences.ContainsKey(value))
                {
                    _objectReferences.Add(value, _objectReferences.Count);
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    int byteCount = utf8Encoding.GetByteCount(value);
                    int handle = byteCount;
                    handle = handle << 1;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                    byte[] buffer = utf8Encoding.GetBytes(value);
                    if (buffer.Length > 0)
                        Write(buffer);
                }
                else
                {
                    int handle = (int)_objectReferences[value];
                    handle = handle << 1;
                    WriteAMF3IntegerData(handle);
                }
            }
        }

        public void WriteAMF3XElement(XElement xElement)
        {
            WriteByte(AMF3TypeCode.Xml);
            string value = string.Empty;
            if (xElement != null)
                value = xElement.ToString();
            if (value == string.Empty)
            {
                WriteAMF3IntegerData(1);
            }
            else
            {
                if (!_objectReferences.ContainsKey(value))
                {
                    _objectReferences.Add(value, _objectReferences.Count);
                    UTF8Encoding utf8Encoding = new UTF8Encoding();
                    int byteCount = utf8Encoding.GetByteCount(value);
                    int handle = byteCount;
                    handle = handle << 1;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                    byte[] buffer = utf8Encoding.GetBytes(value);
                    if (buffer.Length > 0)
                        Write(buffer);
                }
                else
                {
                    int handle = (int)_objectReferences[value];
                    handle = handle << 1;
                    WriteAMF3IntegerData(handle);
                }
            }
        }
#endif

		public void WriteAMF3Object(object value)
		{
            if (!_objectReferences.ContainsKey(value))
			{
				_objectReferences.Add(value, _objectReferences.Count);

				ClassDefinition classDefinition = GetClassDefinition(value);
                if (classDefinition != null && _classDefinitionReferences.ContainsKey(classDefinition))
                {
                    //Existing class-def
                    int handle = (int)_classDefinitionReferences[classDefinition];//handle = classRef 0 1
                    handle = handle << 2;
                    handle = handle | 1;
                    WriteAMF3IntegerData(handle);
                }
                else
				{//inline class-def
					
					classDefinition = CreateClassDefinition(value);
                    _classDefinitionReferences.Add(classDefinition, _classDefinitionReferences.Count);
					//handle = memberCount dynamic externalizable 1 1
					int handle = classDefinition.MemberCount;
					handle = handle << 1;
					handle = handle | (classDefinition.IsDynamic ? 1 : 0);
					handle = handle << 1;
					handle = handle | (classDefinition.IsExternalizable ? 1 : 0);
					handle = handle << 2;
					handle = handle | 3;
					WriteAMF3IntegerData(handle);
					WriteAMF3UTF(classDefinition.ClassName);
					for(int i = 0; i < classDefinition.MemberCount; i++)
					{
						string key = classDefinition.Members[i].Name;
						WriteAMF3UTF(key);
					}
				}
				//write inline object
				if( classDefinition.IsExternalizable )
				{
					if( value is IExternalizable )
					{
						IExternalizable externalizable = value as IExternalizable;
						DataOutput dataOutput = new DataOutput(this);
						externalizable.WriteExternal(dataOutput);
					}
					else
						throw new FluorineException(__Res.GetString(__Res.Externalizable_CastFail,classDefinition.ClassName));
				}
				else
				{
					for(int i = 0; i < classDefinition.MemberCount; i++)
					{
                        object memberValue = GetMember(value, classDefinition.Members[i]);
                        WriteAMF3Data(memberValue);
					}

					if(classDefinition.IsDynamic)
					{
						IDictionary dictionary = value as IDictionary;
						foreach(DictionaryEntry entry in dictionary)
						{
							WriteAMF3UTF(entry.Key.ToString());
							WriteAMF3Data(entry.Value);
						}
						WriteAMF3UTF(string.Empty);
					}
				}
			}
			else
			{
				//handle = objectRef 0
				int handle = (int)_objectReferences[value];
				handle = handle << 1;
				WriteAMF3IntegerData(handle);
			}
		}

		private ClassDefinition GetClassDefinition(object obj)
		{
            if (obj is ASObject)
            {
                ASObject asObject = obj as ASObject;
                if (asObject.IsTypedObject && classDefinitions.ContainsKey(asObject.TypeName))
                    return classDefinitions[asObject.TypeName] as ClassDefinition;
                else
                    return null;
            }
            else
            {
                if (classDefinitions.ContainsKey(obj.GetType().FullName))
                    return classDefinitions[obj.GetType().FullName] as ClassDefinition;
                else
                    return null;
            }
		}

#if WCF
        static bool IsDataContract(Type type)
        {
            object[] attributes = type.GetCustomAttributes(typeof(System.Runtime.Serialization.DataContractAttribute), false);
            return attributes.Length == 1;
        }
#endif

		private ClassDefinition CreateClassDefinition(object obj)
		{
			ClassDefinition classDefinition = null;
            Type type = obj.GetType();
            bool externalizable = type.GetInterface(typeof(FluorineFx.AMF3.IExternalizable).FullName, true) != null;
			bool dynamic = false;
			string customClassName = null;
			if( obj is IDictionary )//ASObject, ObjectProxy
			{
				if( obj is ASObject && (obj as ASObject).IsTypedObject)//ASObject
				{
					ASObject asObject = obj as ASObject;
                    ClassMember[] classMemberList = new ClassMember[asObject.Count];
					int i = 0;
#if !(NET_1_1)
                    foreach (KeyValuePair<string, object> entry in asObject)
#else
					foreach(DictionaryEntry entry in asObject)
#endif
                    {
                        ClassMember classMember = new ClassMember(entry.Key as string, BindingFlags.Default, MemberTypes.Custom);
                        classMemberList[i] = classMember;
						i++;
					}
					customClassName = asObject.TypeName;
                    classDefinition = new ClassDefinition(customClassName, classMemberList, externalizable, dynamic);
                    classDefinitions[customClassName] = classDefinition;
                }
				else
				{
					dynamic = true;
					customClassName = string.Empty;
                    classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, externalizable, dynamic);
				}
			}			
			else if( obj is IExternalizable )
			{
				customClassName = type.FullName;
				customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);

				classDefinition = new ClassDefinition(customClassName, ClassDefinition.EmptyClassMembers, true, false);
                classDefinitions[type.FullName] = classDefinition;
			}
			else
			{
#if WCF
                //Verify [DataContract] or [Serializable] on type
                bool serializable = IsDataContract(type) || type.IsSerializable;
                if (!serializable && type.Assembly != typeof(AMFWriter).Assembly)
                    throw new FluorineException(string.Format("Type {0} was not marked as a data contract.", type.FullName));
                List<string> memberNames = new List<string>();
                List<ClassMember> classMemberList = new List<ClassMember>();
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    PropertyInfo propertyInfo = propertyInfos[i] as PropertyInfo;
                    string name = propertyInfo.Name;
                    if (propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                        continue;
                    if (propertyInfo.GetGetMethod() == null || propertyInfo.GetGetMethod().GetParameters().Length > 0)
                    {
                        //The gateway will not be able to access this property
                        string msg = __Res.GetString(__Res.Reflection_PropertyIndexFail, string.Format("{0}.{1}", type.FullName, propertyInfo.Name));
                        if (log.IsWarnEnabled)
                            log.Warn(msg);
                        continue;
                    }
                    object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(System.Runtime.Serialization.DataMemberAttribute), false);
                    if ((customAttributes != null) && (customAttributes.Length > 0))
                    {
                        System.Runtime.Serialization.DataMemberAttribute attribute = (System.Runtime.Serialization.DataMemberAttribute)customAttributes[0];
                        if (attribute.Name != null && attribute.Name.Length != 0)
                            name = attribute.Name;
                    }
                    else
                    {
                        if (!type.IsSerializable && type.Assembly != typeof(AMFWriter).Assembly)
                            continue;
                    }
                    if (memberNames.Contains(name))
                        continue;
                    memberNames.Add(name);
                    BindingFlags bf = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
                    try
                    {
                        PropertyInfo propertyInfoTmp = obj.GetType().GetProperty(name);
                    }
                    catch (AmbiguousMatchException)
                    {
                        bf = BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance;
                    }
                    ClassMember classMember = new ClassMember(name, bf, propertyInfo.MemberType);
                    classMemberList.Add(classMember);
                }
                FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < fieldInfos.Length; i++)
                {
                    FieldInfo fieldInfo = fieldInfos[i] as FieldInfo;
                    if (fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0)
                        continue;
                    if (fieldInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                        continue;
                    string name = fieldInfo.Name;
                    object[] customAttributes = fieldInfo.GetCustomAttributes(typeof(System.Runtime.Serialization.DataMemberAttribute), false);
                    if ((customAttributes != null) && (customAttributes.Length > 0))
                    {
                        System.Runtime.Serialization.DataMemberAttribute attribute = (System.Runtime.Serialization.DataMemberAttribute)customAttributes[0];
                        if (attribute.Name != null && attribute.Name.Length != 0)
                            name = attribute.Name;
                    }
                    else
                    {
                        if (!type.IsSerializable && type.Assembly != typeof(AMFWriter).Assembly)
                            continue;
                    }
                    ClassMember classMember = new ClassMember(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, fieldInfo.MemberType);
                    classMemberList.Add(classMember);
                }
                ClassMember[] classMembers = classMemberList.ToArray();
                customClassName = type.FullName;
                customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);
                classDefinition = new ClassDefinition(customClassName, classMembers, externalizable, dynamic);
                classDefinitions[type.FullName] = classDefinition;
#else
#if !(NET_1_1)
                List<string> memberNames = new List<string>();
                List<ClassMember> classMemberList = new List<ClassMember>();
#else
                ArrayList memberNames = new ArrayList();
                ArrayList classMemberList = new ArrayList();
#endif
                PropertyInfo[] propertyInfos = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    PropertyInfo propertyInfo = propertyInfos[i] as PropertyInfo;
                    string name = propertyInfo.Name;
                    if (propertyInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                        continue;
                    if (propertyInfo.GetGetMethod() == null || propertyInfo.GetGetMethod().GetParameters().Length > 0)
                    {
                        //The gateway will not be able to access this property
                        string msg = __Res.GetString(__Res.Reflection_PropertyIndexFail, string.Format("{0}.{1}", type.FullName, propertyInfo.Name));
#if !SILVERLIGHT
                        if (log.IsWarnEnabled)
                            log.Warn(msg);
#endif
                        continue;
                    }
                    if (memberNames.Contains(name))
                        continue;
                    memberNames.Add(name);
                    BindingFlags bf = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;
                    try
                    {
                        PropertyInfo propertyInfoTmp = obj.GetType().GetProperty(name);
                    }
                    catch (AmbiguousMatchException)
                    {
                        bf = BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.Instance;
                    }
                    ClassMember classMember = new ClassMember(name, bf, propertyInfo.MemberType);
                    classMemberList.Add(classMember);
                }
                FieldInfo[] fieldInfos = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                for (int i = 0; i < fieldInfos.Length; i++)
                {
                    FieldInfo fieldInfo = fieldInfos[i] as FieldInfo;
#if !SILVERLIGHT
                    if (fieldInfo.GetCustomAttributes(typeof(NonSerializedAttribute), true).Length > 0)
                        continue;
#endif
                    if (fieldInfo.GetCustomAttributes(typeof(TransientAttribute), true).Length > 0)
                        continue;
                    string name = fieldInfo.Name;
                    ClassMember classMember = new ClassMember(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance, fieldInfo.MemberType);
                    classMemberList.Add(classMember);
                }
#if !(NET_1_1)
                ClassMember[] classMembers = classMemberList.ToArray();
#else
                ClassMember[] classMembers = classMemberList.ToArray(typeof(ClassMember)) as ClassMember[];
#endif
                customClassName = type.FullName;
				customClassName = FluorineConfiguration.Instance.GetCustomClass(customClassName);
                classDefinition = new ClassDefinition(customClassName, classMembers, externalizable, dynamic);
				classDefinitions[type.FullName] = classDefinition;
#endif
			}
			return classDefinition;
		}

		#endregion AMF3

        internal object GetMember(object instance, ClassMember member)
        {
            if (instance is ASObject)
            {
                ASObject aso = instance as ASObject;
                if (aso.ContainsKey(member.Name))
                    return aso[member.Name];
            }
            Type type = instance.GetType();
            if (member.MemberType == MemberTypes.Property)
            {
                PropertyInfo propertyInfo = type.GetProperty(member.Name, member.BindingFlags);
                return propertyInfo.GetValue(instance, null);
            }
            if (member.MemberType == MemberTypes.Field)
            {
                FieldInfo fieldInfo = type.GetField(member.Name, member.BindingFlags);
                return fieldInfo.GetValue(instance);
            }
            string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("{0}.{1}", type.FullName, member.Name));
            throw new FluorineException(msg);
        }
	}
}
