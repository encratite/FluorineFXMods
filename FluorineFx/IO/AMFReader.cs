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
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Reflection;
using log4net;
using FluorineFx.Exceptions;
using FluorineFx.AMF3;
using FluorineFx.Configuration;
using FluorineFx.IO.Readers;

namespace FluorineFx.IO
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	public class AMFReader : BinaryReader
	{
        private static readonly ILog log = LogManager.GetLogger(typeof(AMFReader));

		bool _useLegacyCollection = true;
        bool _faultTolerancy = false;
        Exception _lastError;

		ArrayList _amf0ObjectReferences;
        ArrayList _objectReferences;
		ArrayList _stringReferences;
		ArrayList _classDefinitions;

		private static IAMFReader[][] AmfTypeTable;

		static AMFReader()
		{
			IAMFReader[] amf0Readers = new IAMFReader[]
			{
				new AMF0NumberReader(), /*0*/
				new AMF0BooleanReader(), /*1*/
				new AMF0StringReader(), /*2*/
				new AMF0ASObjectReader(), /*3*/
				new AMFUnknownTagReader(), 
				new AMF0NullReader(), /*5*/
				new AMF0NullReader(), /*6*/
				new AMF0ReferenceReader(), /*7*/
				new AMF0AssociativeArrayReader(), /*8*/
				new AMFUnknownTagReader(), 
				new AMF0ArrayReader(), /*10*/
				new AMF0DateTimeReader(), /*11*/
				new AMF0LongStringReader(), /*12*/
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMF0XmlReader(), /*15*/
				(FluorineConfiguration.Instance.OptimizerSettings != null && FluorineConfiguration.Instance.FullTrust) ? (IAMFReader)(new  AMF0OptimizedObjectReader()) : (IAMFReader)(new AMF0ObjectReader()), /*16*/
				new AMF0AMF3TagReader() /*17*/
			};

			IAMFReader[] amf3Readers = new IAMFReader[]
			{
				new AMF3NullReader(), /*0*/
				new AMF3NullReader(), /*1*/
				new AMF3BooleanFalseReader(), /*2*/
				new AMF3BooleanTrueReader(), /*3*/
				new AMF3IntegerReader(), /*4*/
				new AMF3NumberReader(), /*5*/
				new AMF3StringReader(), /*6*/
				new AMF3XmlReader(), /*7*/
				new AMF3DateTimeReader(), /*8*/
				new AMF3ArrayReader(),  /*9*/
				(FluorineConfiguration.Instance.OptimizerSettings != null && FluorineConfiguration.Instance.FullTrust) ? (IAMFReader)(new AMF3OptimizedObjectReader()) : (IAMFReader)(new AMF3ObjectReader()), /*10*/
				new AMF3XmlReader(), /*11*/
				new AMF3ByteArrayReader(), /*12*/
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader(),
				new AMFUnknownTagReader()
			};

			AmfTypeTable = new IAMFReader[4][]{amf0Readers, null, null, amf3Readers};
		}

		/// <summary>
		/// Initializes a new instance of the AMFReader class based on the supplied stream and using UTF8Encoding.
		/// </summary>
		/// <param name="stream"></param>
		public AMFReader(Stream stream) : base(stream)
		{
			Reset();
		}

		public void Reset()
		{
			_amf0ObjectReferences = new ArrayList(5);
            _objectReferences = new ArrayList(15);
			_stringReferences = new ArrayList(15);
			_classDefinitions = new ArrayList(2);
            _lastError = null;
		}

		public bool UseLegacyCollection
		{
			get{ return _useLegacyCollection; }
			set{ _useLegacyCollection = value; }
		}

        public bool FaultTolerancy
        {
            get { return _faultTolerancy; }
            set { _faultTolerancy = value; }
        }

        public Exception GetLastError()
        {
            return _lastError;
        }

		public object ReadData()
		{
			byte typeCode = ReadByte();
			return ReadData(typeCode);
		}

		/// <summary>
		/// Maps a type code to an access method.
		/// </summary>
		/// <param name="typeCode"></param>
		/// <returns></returns>
		public object ReadData(byte typeCode)
		{
			return AmfTypeTable[0][typeCode].ReadData(this);
		}

		public object ReadReference()
		{
			int reference = ReadUInt16();
			//return _amf0ObjectReferences[reference-1];
            return _amf0ObjectReferences[reference];
		}

		/// <summary>
		/// Reads a 2-byte unsigned integer from the current stream using little endian encoding and advances the position of the stream by two bytes.
		/// </summary>
		/// <returns></returns>
        [CLSCompliant(false)]
        public override ushort ReadUInt16()
		{
			//Read the next 2 bytes, shift and add.
			byte[] bytes = ReadBytes(2);
			return (ushort)(((bytes[0] & 0xff) << 8) | (bytes[1] & 0xff));
		}

		public override short ReadInt16()
		{
			//Read the next 2 bytes, shift and add.
			byte[] bytes = ReadBytes(2);
			return (short)((bytes[0] << 8) | bytes[1]);
		}

		public override string ReadString()
		{
			//Get the length of the string (first 2 bytes).
			int length = ReadUInt16();
			return ReadUTF(length);
		}

		public override bool ReadBoolean()
		{
			return base.ReadBoolean();
		}

		public override int ReadInt32()
		{
			// Read the next 4 bytes, shift and add
			byte[] bytes = ReadBytes(4);
			int value = (int)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);
            return value;
		}

        public int ReadUInt24()
        {
            byte[] bytes = this.ReadBytes(3);
            int value = bytes[0] << 16 | bytes[1] << 8 | bytes[2];
            return value;
        }
 
		public override double ReadDouble()
		{			
			byte[] bytes = ReadBytes(8);
			byte[] reverse = new byte[8];
			//Grab the bytes in reverse order 
			for(int i = 7, j = 0 ; i >= 0 ; i--, j++)
			{
				reverse[j] = bytes[i];
			}
			double value = BitConverter.ToDouble(reverse, 0);
			return value;
		}

		public float ReadFloat()
		{			
			byte[] bytes = this.ReadBytes(4);
			byte[] invertedBytes = new byte[4];
			//Grab the bytes in reverse order from the backwards index
			for(int i = 3, j = 0 ; i >= 0 ; i--, j++)
			{
				invertedBytes[j] = bytes[i];
			}
			float value = BitConverter.ToSingle(invertedBytes, 0);
			return value;
		}

		public void AddReference(object instance)
		{
			_amf0ObjectReferences.Add(instance);
		}

		public object ReadObject()
		{
			string typeIdentifier = ReadString();

			if(log.IsDebugEnabled )
				log.Debug(__Res.GetString(__Res.TypeIdentifier_Loaded, typeIdentifier));

			Type type = ObjectFactory.Locate(typeIdentifier);
			if( type != null )
			{
				object instance = ObjectFactory.CreateInstance(type);
                this.AddReference(instance);

				string key = ReadString();
                for (byte typeCode = ReadByte(); typeCode != AMF0TypeCode.EndOfObject; typeCode = ReadByte())
				{
					object value = ReadData(typeCode);
                    SetMember(instance, key, value);
					key = ReadString();
				}
                return instance;
			}
			else
			{
				if( log.IsWarnEnabled )
					log.Warn(__Res.GetString(__Res.TypeLoad_ASO, typeIdentifier));

				ASObject asObject;
				//Reference added in ReadASObject
                asObject = ReadASObject();
				asObject.TypeName = typeIdentifier;
				return asObject;
			}
		}

		public ASObject ReadASObject()
		{
			ASObject asObject = new ASObject();
			AddReference(asObject);
			string key = this.ReadString();
			for(byte typeCode = ReadByte(); typeCode != AMF0TypeCode.EndOfObject; typeCode = ReadByte())
			{
				//asObject.Add(key, ReadData(typeCode));
                asObject[key] = ReadData(typeCode);
				key = ReadString();
			}
			return asObject;
		}

		
		public string ReadUTF(int length)
		{
			if( length == 0 )
                return null;// string.Empty;
			UTF8Encoding utf8 = new UTF8Encoding(false, true);
			byte[] encodedBytes = this.ReadBytes(length);
			string decodedString = utf8.GetString(encodedBytes);
			return decodedString;
		}
		
		public string ReadLongString()
		{
			int length = this.ReadInt32();
			return this.ReadUTF(length);
		}

		internal Hashtable ReadAssociativeArray()
		{
			// Get the length property set by flash.
			int length = this.ReadInt32();
			Hashtable result = new Hashtable(length);
			AddReference(result);
			string key = ReadString();
			for(byte typeCode = ReadByte(); typeCode != AMF0TypeCode.EndOfObject; typeCode = ReadByte())
			{
				object value = ReadData(typeCode);
				result.Add(key, value);
				key = ReadString();
			}
			return result;
		}

		internal IList ReadArray()
		{
			//Get the length of the array.
			int length = ReadInt32();
			object[] array = new object[length];
			//ArrayList array = new ArrayList(length);
			AddReference(array);
			for(int i = 0; i < length; i++)
			{
				array[i] = ReadData();
				//array.Add( ReadData() );
			}
			return array;
		} 

		public DateTime ReadDateTime()
		{
			double milliseconds = this.ReadDouble();
			DateTime start = new DateTime(1970, 1, 1);

			DateTime date = start.AddMilliseconds(milliseconds);
			int tmp = ReadUInt16();
			//Note for the latter than values greater than 720 (12 hours) are 
			//represented as 2^16 - the value.
			//Thus GMT+1 is 60 while GMT-5 is 65236
			if(tmp > 720)
			{
				tmp = (65536 - tmp);
			}
			int tz = tmp / 60;
			
			switch(FluorineConfiguration.Instance.TimezoneCompensation)
			{
				case TimezoneCompensation.None:
					break;
				case TimezoneCompensation.Auto:
					date = date.AddHours(tz);
					
					//if(TimeZone.CurrentTimeZone.IsDaylightSavingTime(date))
					//	date = date.AddMilliseconds(-3600000);
					
					break;
			}

			return date;
		}
 
		public XmlDocument ReadXmlDocument()
		{
			string text = this.ReadLongString();
			XmlDocument document = new XmlDocument();
            if( text != null && text != string.Empty)
			    document.LoadXml(text);
			return document;
		}


		#region AMF3

		public object ReadAMF3Data()
		{
			byte typeCode = this.ReadByte();
			return this.ReadAMF3Data(typeCode);
		}

		/// <summary>
		/// Maps a type code to an access method.
		/// </summary>
		/// <param name="typeCode"></param>
		/// <returns></returns>
		public object ReadAMF3Data(byte typeCode)
		{
			return AmfTypeTable[3][typeCode].ReadData(this);
		}

        public void AddAMF3ObjectReference(object instance)
        {
            _objectReferences.Add(instance);
        }

        public object ReadAMF3ObjectReference(int index)
        {
            return _objectReferences[index];
        }

		/// <summary>
		/// Handle decoding of the variable-length representation
		/// which gives seven bits of value per serialized byte by using the high-order bit 
		/// of each byte as a continuation flag.
		/// </summary>
		/// <returns></returns>
		public int ReadAMF3IntegerData()
		{
			int acc = ReadByte();
			int tmp;
			if(acc < 128)
				return acc;
			else
			{
				acc = (acc & 0x7f) << 7;
				tmp = this.ReadByte();
				if(tmp < 128)
					acc = acc | tmp;
				else
				{
					acc = (acc | tmp & 0x7f) << 7;
					tmp = this.ReadByte();
					if(tmp < 128)
						acc = acc | tmp;
					else
					{
						acc = (acc | tmp & 0x7f) << 8;
						tmp = this.ReadByte();
						acc = acc | tmp;
					}
				}
			}
			//To sign extend a value from some number of bits to a greater number of bits just copy the sign bit into all the additional bits in the new format.
			//convert/sign extend the 29bit two's complement number to 32 bit
			int mask = 1 << 28; // mask
			int r = -(acc & mask) | acc;
			return r;

			//The following variation is not portable, but on architectures that employ an 
			//arithmetic right-shift, maintaining the sign, it should be fast. 
			//s = 32 - 29;
			//r = (x << s) >> s;
		}

		public int ReadAMF3Int()
		{
			int intData = ReadAMF3IntegerData();
			return intData;
		}

		public DateTime ReadAMF3Date()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1)  != 0 );
			handle = handle >> 1;
			if( inline )
			{
				double milliseconds = this.ReadDouble();
				DateTime start = new DateTime(1970, 1, 1, 0, 0, 0);

				DateTime date = start.AddMilliseconds(milliseconds);
				switch(FluorineConfiguration.Instance.TimezoneCompensation)
				{
					case TimezoneCompensation.None:
						break;
					case TimezoneCompensation.Auto:
						date = date.ToLocalTime();
						break;
				}
                AddAMF3ObjectReference(date);
				return date;
			}
			else
			{
				return (DateTime)ReadAMF3ObjectReference(handle);
			}
		}

        internal void AddStringReference(string str)
        {
            _stringReferences.Add(str);
        }

        internal string ReadStringReference(int index)
        {
            return _stringReferences[index] as string;
        }

		public string ReadAMF3String()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1) != 0 );
			handle = handle >> 1;
			if( inline )
			{
				int length = handle;
                if (length == 0)
                    return null;//string.Empty;
				string str = ReadUTF(length);
                AddStringReference(str);
				return str;
			}
			else
			{
				return ReadStringReference(handle);
			}
		}

		public XmlDocument ReadAMF3XmlDocument()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1) != 0 );
			handle = handle >> 1;
			string xml = string.Empty;
			if( inline )
			{
                if (handle > 0)//length
				    xml = this.ReadUTF(handle);
                AddAMF3ObjectReference(xml);
			}
			else
			{
				xml = ReadAMF3ObjectReference(handle) as string;
			}
			XmlDocument xmlDocument = new XmlDocument();
            if (xml != null && xml != string.Empty)
                xmlDocument.LoadXml(xml);
			return xmlDocument;
		}

        [CLSCompliant(false)]
		public ByteArray ReadAMF3ByteArray()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1) != 0 );
			handle = handle >> 1;
			if( inline )
			{
				int length = handle;
				byte[] buffer = ReadBytes(length);
				ByteArray ba = new ByteArray(buffer);
				AddAMF3ObjectReference(ba);
				return ba;
			}
			else
				return ReadAMF3ObjectReference(handle) as ByteArray;
		}

		public object ReadAMF3Array()
		{
			int handle = ReadAMF3IntegerData();
			bool inline = ((handle & 1)  != 0 ); handle = handle >> 1;
			if( inline )
			{
				Hashtable hashtable = null;
				string key = ReadAMF3String();
                while (key != null && key != string.Empty)
				{
					if( hashtable == null )
					{
						hashtable = new Hashtable();
						AddAMF3ObjectReference(hashtable);
					}
					object value = ReadAMF3Data();
					hashtable.Add(key, value);
					key = ReadAMF3String();
				}
				//Not an associative array
				if( hashtable == null )
				{
					IList array;
					//if(!_useLegacyCollection)
						array = new object[handle];
					//else
					//	array = new ArrayList(handle);
                    AddAMF3ObjectReference(array);
					for(int i = 0; i < handle; i++)
					{
						//Grab the type for each element.
						byte typeCode = this.ReadByte();
						object value = ReadAMF3Data(typeCode);
						if( array is ArrayList )
							array.Add(value);
						else
							array[i] = value;
					}
					return array;
				}
				else
				{
					for(int i = 0; i < handle; i++)
					{
						object value = ReadAMF3Data();
						hashtable.Add( i.ToString(), value);
					}
					return hashtable;
				}
			}
			else
			{
				return ReadAMF3ObjectReference(handle);
			}
		}

        internal void AddClassReference(ClassDefinition classDefinition)
        {
            _classDefinitions.Add(classDefinition);
        }

        internal ClassDefinition ReadClassReference(int index)
        {
            return _classDefinitions[index] as ClassDefinition;
        }

		internal ClassDefinition ReadClassDefinition(int handle)
		{
			ClassDefinition classDefinition = null;
			//an inline object
			bool inlineClassDef = ((handle & 1) != 0 );handle = handle >> 1;
			if( inlineClassDef )
			{
				//inline class-def
				string typeIdentifier = ReadAMF3String();
				//flags that identify the way the object is serialized/deserialized
				bool externalizable = ((handle & 1) != 0 );handle = handle >> 1;
				bool dynamic = ((handle & 1) != 0 );handle = handle >> 1;

                ClassMember[] members = new ClassMember[handle];
				for (int i = 0; i < handle; i++)
				{
                    string name = ReadAMF3String();
                    ClassMember classMember = new ClassMember(name, BindingFlags.Default, MemberTypes.Custom);
                    members[i] = classMember;
				}
				classDefinition = new ClassDefinition(typeIdentifier, members, externalizable, dynamic);
				AddClassReference(classDefinition);
			}
			else
			{
				//A reference to a previously passed class-def
				classDefinition = ReadClassReference(handle);
			}
			if (log.IsDebugEnabled)
			{
				if (classDefinition.IsTypedObject)
					log.Debug(__Res.GetString(__Res.ClassDefinition_Loaded, classDefinition.ClassName));
				else
					log.Debug(__Res.GetString(__Res.ClassDefinition_LoadedUntyped));
			}
			return classDefinition;
		}

		internal object ReadAMF3Object(ClassDefinition classDefinition)
		{
			object instance = null;
			if( classDefinition.IsDynamic )
				instance = new ASObject();
			else
			{
				instance = ObjectFactory.CreateInstance(classDefinition.ClassName);
                if (instance == null)
                {
                    if (log.IsWarnEnabled)
                        log.Warn(__Res.GetString(__Res.TypeLoad_ASO, classDefinition.ClassName));

                    instance = new ASObject(classDefinition.ClassName);
                }
			}
            AddAMF3ObjectReference(instance);
			if (classDefinition.IsExternalizable)
			{
				if (instance is IExternalizable)
				{
					IExternalizable externalizable = instance as IExternalizable;
					DataInput dataInput = new DataInput(this);
					externalizable.ReadExternal(dataInput);
				}
				else
				{
					string msg = __Res.GetString(__Res.Externalizable_CastFail, instance.GetType().FullName);
					if (log.IsErrorEnabled)
						log.Error(msg);
					throw new FluorineException(msg);
				}
			}
			else
			{
				for (int i = 0; i < classDefinition.MemberCount; i++)
				{
					string key = classDefinition.Members[i].Name;
					object value = ReadAMF3Data();
					SetMember(instance, key, value);
				}
				if (classDefinition.IsDynamic && instance is ASObject)
				{
					ASObject asObject = instance as ASObject;
					string key = ReadAMF3String();
                    while (key != null && key != string.Empty)
					{
						object value = ReadAMF3Data();
						asObject.Add(key, value);
						key = ReadAMF3String();
					}
				}
			}
            return instance;
		}

        public object ReadAMF3Object()
        {
            int handle = ReadAMF3IntegerData();
            bool inline = ((handle & 1) != 0); handle = handle >> 1;
            if (!inline)
            {
                //An object reference
                return ReadAMF3ObjectReference(handle);
            }
            else
            {
                ClassDefinition classDefinition = ReadClassDefinition(handle);
                object obj = ReadAMF3Object(classDefinition);
                return obj;
            }
        }

		#endregion AMF3

        internal void SetMember(object instance, string memberName, object value)
        {
            if (instance is ASObject)
            {
                ((ASObject)instance)[memberName] = value;
                return;
            }
            Type type = instance.GetType();
            //PropertyInfo propertyInfo = type.GetProperty(memberName);
            PropertyInfo propertyInfo = null;
            try
            {
                propertyInfo = type.GetProperty(memberName);
            }
            catch (AmbiguousMatchException)
            {
                //To resolve the ambiguity, include BindingFlags.DeclaredOnly to restrict the search to members that are not inherited.
                propertyInfo = type.GetProperty(memberName, BindingFlags.DeclaredOnly | BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance);
            }
            if (propertyInfo != null)
            {
                try
                {
                    value = TypeHelper.ChangeType(value, propertyInfo.PropertyType);
                    if (propertyInfo.CanWrite)
                    {
                        if (propertyInfo.GetIndexParameters() == null || propertyInfo.GetIndexParameters().Length == 0)
                            propertyInfo.SetValue(instance, value, null);
                        else
                        {
                            string msg = __Res.GetString(__Res.Reflection_PropertyIndexFail, string.Format("{0}.{1}", type.FullName, memberName));
                            if (log.IsErrorEnabled)
                                log.Error(msg);
                            if( !_faultTolerancy )
                                throw new FluorineException(msg);
                            else
                                _lastError = new FluorineException(msg);

                        }
                    }
                    else
                    {
                        string msg = __Res.GetString(__Res.Reflection_PropertyReadOnly, string.Format("{0}.{1}", type.FullName, memberName));
                        if (log.IsWarnEnabled)
                            log.Warn(msg);
                    }
                }
                catch (Exception ex)
                {
                    string msg = __Res.GetString(__Res.Reflection_PropertySetFail, string.Format("{0}.{1}", type.FullName, memberName), ex.Message);
                    if (log.IsErrorEnabled)
                        log.Error(msg, ex);
                    if (!_faultTolerancy)
                        throw new FluorineException(msg);
                    else
                        _lastError = new FluorineException(msg);
                }
            }
            else
            {
                FieldInfo fi = type.GetField(memberName, BindingFlags.Public | BindingFlags.Instance);
                try
                {
                    if (fi != null)
                    {
                        value = TypeHelper.ChangeType(value, fi.FieldType);
                        fi.SetValue(instance, value);
                    }
                    else
                    {
                        string msg = __Res.GetString(__Res.Reflection_MemberNotFound, string.Format("{0}.{1}", type.FullName, memberName));
                        if (log.IsWarnEnabled)
                            log.Warn(msg);
                    }
                }
                catch (Exception ex)
                {
                    string msg = __Res.GetString(__Res.Reflection_FieldSetFail, string.Format("{0}.{1}", type.FullName, memberName), ex.Message);
                    if (log.IsErrorEnabled)
                        log.Error(msg, ex);
                    if (!_faultTolerancy)
                        throw new FluorineException(msg);
                    else
                        _lastError = new FluorineException(msg);
                }
            }
        }
 	}
}
