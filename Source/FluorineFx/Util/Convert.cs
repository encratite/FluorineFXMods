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
using System.IO;
using System.Xml;
#if !SILVERLIGHT
using System.Data.SqlTypes;
#endif
using FluorineFx.AMF3;

namespace FluorineFx.Util
{
    /// <summary>
    /// Converts a base data type to another base data type.
    /// </summary>
    public class Convert
    {
        #region Scalar Types

        #region String

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(SByte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Int16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Int32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Int64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer  to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 8-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Byte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Single value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Double value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Boolean value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Decimal value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Char value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent String representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(TimeSpan value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent String representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(DateTime value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Guid value) { return value.ToString(); }

#if !(NET_1_1)
        // Nullable Types.
		// 
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(SByte? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Int16? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Int32? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Int64? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer  to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Byte? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt16? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt32? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt64? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Single? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Double? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Boolean value.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Boolean? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Decimal? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Char? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(TimeSpan? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(DateTime? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Guid? value) { return value.ToString(); }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlString value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlByte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlInt16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlInt32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlInt64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlSingle value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlDouble value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlDecimal value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlMoney value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlBoolean value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlGuid value) { return value.ToString(); }
#if !(NET_1_1)
        /// <summary>
        /// Converts the value of the specified SqlChars to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlChars.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlChars value) { return value.IsNull ? null : value.ToSqlString().Value; }
        /// <summary>
        /// Converts the value of the specified SqlXml to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlXml.</param>
        /// <returns>The String equivalent of the value of value.</returns>        
        public static String ToString(SqlXml value) { return value.IsNull ? null : value.Value; }
#endif
#endif
        /// <summary>
        /// Converts the value of the specified Type to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(Type value) { return value == null ? null : value.FullName; }
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified XmlDocument to its equivalent String representation.
        /// </summary>
        /// <param name="value">An XmlDocument.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(XmlDocument value) { return value == null ? null : value.InnerXml; }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent String representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The String equivalent of the value of value.</returns>
        public static String ToString(object value)
        {
            if (value == null || value is DBNull) return String.Empty;

            if (value is String) return (String)value;

            // Scalar Types.
            //
            if (value is Char) return ToString((Char)value);
            if (value is TimeSpan) return ToString((TimeSpan)value);
            if (value is DateTime) return ToString((DateTime)value);
            if (value is Guid) return ToString((Guid)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlGuid) return ToString((SqlGuid)value);
#if !(NET_1_1)
            if (value is SqlChars) return ToString((SqlChars)value);
            if (value is SqlXml) return ToString((SqlXml)value);
#endif
            if (value is XmlDocument) return ToString((XmlDocument)value);
#endif
            if (value is Type) return ToString((Type)value);

            if (value is IConvertible) return ((IConvertible)value).ToString(null);
            if (value is IFormattable) return ((IFormattable)value).ToString(null, null);

            return value.ToString();
        }

        #endregion

        #region SByte

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(String value) { return value == null ? (SByte)0 : SByte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Int16 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Int32 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Int64 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Byte value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(UInt16 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(UInt32 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(UInt64 value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Single value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Double value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Decimal value) { return checked((SByte)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Boolean value) { return (SByte)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Char value) { return checked((SByte)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SByte? value) { return value.HasValue ? value.Value : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Int16? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Int32? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Int64? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
		[CLSCompliant(false)]
        public static SByte ToSByte(Byte? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(UInt16? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(UInt32? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(UInt64? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Single? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Double? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Decimal? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Char? value) { return value.HasValue ? checked((SByte)value.Value) : (SByte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(Boolean? value) { return (value.HasValue && value.Value) ? (SByte)1 : (SByte)0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlString value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlByte value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlInt16 value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlInt32 value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlInt64 value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlSingle value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlDouble value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlDecimal value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlMoney value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(SqlBoolean value) { return value.IsNull ? (SByte)0 : ToSByte(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 8-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte ToSByte(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is SByte) return (SByte)value;

            // Scalar Types.
            //
            if (value is String) return ToSByte((String)value);

            if (value is Boolean) return ToSByte((Boolean)value);
            if (value is Char) return ToSByte((Char)value);

            // SqlTypes.
            //

            if (value is IConvertible) return ((IConvertible)value).ToSByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(SByte));
        }

        #endregion

        #region Int16

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(String value) { return value == null ? (Int16)0 : Int16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(SByte value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int32 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int64 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Byte value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(UInt16 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(UInt32 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(UInt64 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Single value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Double value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Decimal value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Boolean value) { return (Int16)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An Unicode character.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Char value) { return checked((Int16)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int16? value) { return value.HasValue ? value.Value : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(SByte? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int32? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Int64? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Byte? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(UInt16? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(UInt32? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16 ToInt16(UInt64? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Single? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Double? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Decimal? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Char? value) { return value.HasValue ? checked((Int16)value.Value) : (Int16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(Boolean? value) { return (value.HasValue && value.Value) ? (Int16)1 : (Int16)0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlInt16 value) { return value.IsNull ? (Int16)0 : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlString value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlByte value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlInt32 value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlInt64 value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlSingle value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlDouble value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlDecimal value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlMoney value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(SqlBoolean value) { return value.IsNull ? (Int16)0 : ToInt16(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 16-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 16-bit signed integer value.</returns>
        public static Int16 ToInt16(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Int16) return (Int16)value;

            // Scalar Types.
            //
            if (value is String) return ToInt16((String)value);

            if (value is Boolean) return ToInt16((Boolean)value);
            if (value is Char) return ToInt16((Char)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlInt16) return ToInt16((SqlInt16)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int16));
        }

        #endregion

        #region Int32

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(String value) { return value == null ? 0 : Int32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(SByte value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int16 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int64 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Byte value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(UInt16 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(UInt32 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(UInt64 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Single value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Double value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Decimal value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An Unicode character.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Char value) { return checked((Int32)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int32? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(SByte? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int16? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Int64? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Byte? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(UInt16? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(UInt32? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32 ToInt32(UInt64? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Single? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Double? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Decimal? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Char? value) { return value.HasValue ? checked((Int32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(Boolean? value) { return (value.HasValue && value.Value) ? 1 : 0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlInt32 value) { return value.IsNull ? 0 : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlString value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlByte value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlInt16 value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlInt64 value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlSingle value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlDouble value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlDecimal value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlMoney value) { return value.IsNull ? 0 : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(SqlBoolean value) { return value.IsNull ? 0 : ToInt32(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 32-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 32-bit signed integer value.</returns>
        public static Int32 ToInt32(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Int32) return (Int32)value;

            // Scalar Types.
            //
            if (value is String) return ToInt32((String)value);

            if (value is Boolean) return ToInt32((Boolean)value);
            if (value is Char) return ToInt32((Char)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlInt32) return ToInt32((SqlInt32)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int32));
        }

        #endregion

        #region Int64

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(String value) { return value == null ? 0 : Int64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(SByte value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int16 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int32 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Byte value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(UInt16 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(UInt32 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(UInt64 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Single value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Double value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Decimal value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An Unicode character.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Char value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(DateTime value) { return (value - DateTime.MinValue).Ticks; }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(TimeSpan value) { return value.Ticks; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int64? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(SByte? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int16? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Int32? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Byte? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(UInt16? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(UInt32? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64 ToInt64(UInt64? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Single? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Double? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Decimal? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Char? value) { return value.HasValue ? checked((Int64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(Boolean? value) { return (value.HasValue && value.Value) ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(DateTime? value) { return value.HasValue ? (value.Value - DateTime.MinValue).Ticks : 0; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(TimeSpan? value) { return value.HasValue ? value.Value.Ticks : 0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlInt64 value) { return value.IsNull ? 0 : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlString value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlByte value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlInt16 value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlInt32 value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlSingle value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlDouble value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlDecimal value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlMoney value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlBoolean value) { return value.IsNull ? 0 : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(SqlDateTime value) { return value.IsNull ? 0 : ToInt64(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 64-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 64-bit signed integer value.</returns>
        public static Int64 ToInt64(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Int64) return (Int64)value;

            // Scalar Types.
            //
            if (value is String) return ToInt64((String)value);

            if (value is Char) return ToInt64((Char)value);
            if (value is Boolean) return ToInt64((Boolean)value);
            if (value is DateTime) return ToInt64((DateTime)value);
            if (value is TimeSpan) return ToInt64((TimeSpan)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlInt64) return ToInt64((SqlInt64)value);
            if (value is SqlDateTime) return ToInt64((SqlDateTime)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int64));
        }

        #endregion

        #region Byte

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(String value) { return value == null ? (Byte)0 : Byte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(SByte value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int16 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int32 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int64 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(UInt16 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(UInt32 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(UInt64 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Single value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Double value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Decimal value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Boolean value) { return (Byte)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unicode character.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Char value) { return checked((Byte)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Byte? value) { return value.HasValue ? value.Value : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(SByte? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int16? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int32? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Int64? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(UInt16? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(UInt32? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte ToByte(UInt64? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Single? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Double? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Decimal? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Char? value) { return value.HasValue ? checked((Byte)value.Value) : (Byte)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(Boolean? value) { return (value.HasValue && value.Value) ? (Byte)1 : (Byte)0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlByte value) { return value.IsNull ? (Byte)0 : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlString value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlInt16 value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlInt32 value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlInt64 value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlSingle value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlDouble value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlDecimal value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlMoney value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(SqlBoolean value) { return value.IsNull ? (Byte)0 : ToByte(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 8-bit unsigned integer value.</returns>
        public static Byte ToByte(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is Byte) return (Byte)value;

            // Scalar Types.
            //
            if (value is String) return ToByte((String)value);

            if (value is Boolean) return ToByte((Boolean)value);
            if (value is Char) return ToByte((Char)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlByte) return ToByte((SqlByte)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Byte));
        }

        #endregion

        #region UInt16

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(String value) { return value == null ? (UInt16)0 : UInt16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SByte value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Int16 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Int32 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Int64 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Byte value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(UInt32 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(UInt64 value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Single value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Double value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Decimal value) { return checked((UInt16)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Boolean value) { return (UInt16)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Char value) { return checked((UInt16)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(UInt16? value) { return value.HasValue ? value.Value : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SByte? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Int16? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Int32? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Int64? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Byte? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(UInt32? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(UInt64? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt16 ToUInt16(Single? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Double? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Decimal? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Char? value) { return value.HasValue ? checked((UInt16)value.Value) : (UInt16)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(Boolean? value) { return (value.HasValue && value.Value) ? (UInt16)1 : (UInt16)0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlString value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlByte value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlInt16 value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlInt32 value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlInt64 value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlSingle value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlDouble value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlDecimal value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlMoney value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(SqlBoolean value) { return value.IsNull ? (UInt16)0 : ToUInt16(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16 ToUInt16(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is UInt16) return (UInt16)value;

            // Scalar Types.
            //
            if (value is String) return ToUInt16((String)value);

            if (value is Boolean) return ToUInt16((Boolean)value);
            if (value is Char) return ToUInt16((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt16));
        }

        #endregion

        #region UInt32

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(String value) { return value == null ? 0 : UInt32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SByte value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Int16 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Int32 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Int64 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Byte value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(UInt16 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(UInt64 value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Single value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Double value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Decimal value) { return checked((UInt32)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Boolean value) { return (UInt32)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Char value) { return checked((UInt32)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(UInt32? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SByte? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Int16? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Int32? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Int64? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Byte? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(UInt16? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(UInt64? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt32 ToUInt32(Single? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Double? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Decimal? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Char? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(Boolean? value) { return (value.HasValue && value.Value) ? (UInt32)1 : 0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlString value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlByte value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlInt16 value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlInt32 value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlInt64 value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlSingle value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlDouble value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlDecimal value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlMoney value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(SqlBoolean value) { return value.IsNull ? 0 : ToUInt32(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is UInt32) return (UInt32)value;

            // Scalar Types.
            //
            if (value is String) return ToUInt32((String)value);

            if (value is Boolean) return ToUInt32((Boolean)value);
            if (value is Char) return ToUInt32((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt32));
        }

        #endregion

        #region UInt64

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(String value) { return value == null ? 0 : UInt64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SByte value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Int16 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Int32 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Int64 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Byte value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(UInt16 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(UInt32 value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Single value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Double value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Decimal value) { return checked((UInt64)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Boolean value) { return (UInt64)(value ? 1 : 0); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Char value) { return checked((UInt64)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(UInt64? value) { return value.HasValue ? value.Value : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt64 ToUInt64(SByte? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Int16? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Int32? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Int64? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Byte? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(UInt16? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(UInt32? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Single? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Double? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt64 ToUInt64(Decimal? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Char? value) { return value.HasValue ? checked((UInt64)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(Boolean? value) { return (value.HasValue && value.Value) ? (UInt64)1 : 0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlString value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlByte value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlInt16 value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlInt32 value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlInt64 value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlSingle value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlDouble value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlDecimal value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlMoney value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(SqlBoolean value) { return value.IsNull ? 0 : ToUInt64(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64 ToUInt64(object value)
        {
            if (value == null || value is DBNull) return 0;

            if (value is UInt64) return (UInt64)value;

            // Scalar Types.
            //
            if (value is String) return ToUInt64((String)value);

            if (value is Boolean) return ToUInt64((Boolean)value);
            if (value is Char) return ToUInt64((Char)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt64));
        }

        #endregion

        #region Char

        // Scalar Types.

        /// <summary>
        /// Converts the first character of the specified String to a Unicode character.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        public static Char ToChar(String value) 
        {
#if !(NET_1_1)
            Char result;
            if (Char.TryParse(value, out result))
                return result;
            return (Char)0;
#else
            return (value == null) ? (Char)0 : Char.Parse(value);
#endif
        }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(SByte value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int16 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int32 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int64 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Byte value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(UInt16 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(UInt32 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(UInt64 value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Single value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Double value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Decimal value) { return checked((Char)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to a Unicode character.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Boolean value) { return (Char)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the specified nullable character to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable Char.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Char? value) { return value.HasValue ? value.Value : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent Unicode character.</returns>
		[CLSCompliant(false)]
        public static Char ToChar(SByte? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int16? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int32? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Int64? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(Byte? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(UInt16? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(UInt32? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char ToChar(UInt64? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Single? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Double? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Decimal? value) { return value.HasValue ? checked((Char)value.Value) : (Char)0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to a Unicode character.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(Boolean? value) { return (value.HasValue && value.Value) ? (Char)1 : (Char)0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(SqlString value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(SqlByte value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(SqlInt16 value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(SqlInt32 value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(SqlInt64 value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to a Unicode character.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(SqlSingle value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to a Unicode character.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(SqlDouble value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to a Unicode character.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(SqlDecimal value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to a Unicode character.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(SqlMoney value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to a Unicode character.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The Unicode character value.</returns>
        public static Char ToChar(SqlBoolean value) { return value.IsNull ? (Char)0 : ToChar(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Unicode character value.</returns>
        public static Char ToChar(object value)
        {
            if (value == null || value is DBNull) return '\x0';

            if (value is Char) return (Char)value;

            // Scalar Types.
            //
            if (value is String) return ToChar((String)value);
            if (value is Boolean) return ToChar((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToChar(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Char));
        }

        #endregion

        #region Single

        // Scalar Types.
        // 
        public static Single ToSingle(String p) { return p == null ? 0.0f : Single.Parse(p); }

        [CLSCompliant(false)]
        public static Single ToSingle(SByte p) { return checked((Single)p); }
        public static Single ToSingle(Int16 p) { return checked((Single)p); }
        public static Single ToSingle(Int32 p) { return checked((Single)p); }
        public static Single ToSingle(Int64 p) { return checked((Single)p); }

        public static Single ToSingle(Byte p) { return checked((Single)p); }
        [CLSCompliant(false)]
        public static Single ToSingle(UInt16 p) { return checked((Single)p); }
        [CLSCompliant(false)]
        public static Single ToSingle(UInt32 p) { return checked((Single)p); }
        [CLSCompliant(false)]
        public static Single ToSingle(UInt64 p) { return checked((Single)p); }

        public static Single ToSingle(Double p) { return checked((Single)p); }

        public static Single ToSingle(Decimal p) { return checked((Single)p); }
        public static Single ToSingle(Boolean p) { return p ? 1.0f : 0.0f; }
        public static Single ToSingle(Char p) { return checked((Single)p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Single ToSingle(Single? p)     { return p.HasValue?                 p.Value:  0.0f; }

		[CLSCompliant(false)]
		public static Single ToSingle(SByte? p)      { return p.HasValue? checked((Single)p.Value): 0.0f; }
		public static Single ToSingle(Int16? p)      { return p.HasValue? checked((Single)p.Value): 0.0f; }
		public static Single ToSingle(Int32? p)      { return p.HasValue? checked((Single)p.Value): 0.0f; }
		public static Single ToSingle(Int64? p)      { return p.HasValue? checked((Single)p.Value): 0.0f; }

		public static Single ToSingle(Byte? p)       { return p.HasValue? checked((Single)p.Value): 0.0f; }
		[CLSCompliant(false)]
		public static Single ToSingle(UInt16? p)     { return p.HasValue? checked((Single)p.Value): 0.0f; }
		[CLSCompliant(false)]
		public static Single ToSingle(UInt32? p)     { return p.HasValue? checked((Single)p.Value): 0.0f; }
		[CLSCompliant(false)]
		public static Single ToSingle(UInt64? p)     { return p.HasValue? checked((Single)p.Value): 0.0f; }

		public static Single ToSingle(Double? p)     { return p.HasValue? checked((Single)p.Value): 0.0f; }

		public static Single ToSingle(Decimal? p)    { return p.HasValue? checked((Single)p.Value): 0.0f; }
		public static Single ToSingle(Char? p)       { return p.HasValue? checked((Single)p.Value): 0.0f; }
		public static Single ToSingle(Boolean? p)    { return (p.HasValue && p.Value)?        1.0f: 0.0f; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Single ToSingle(SqlSingle p) { return p.IsNull ? 0.0f : p.Value; }
        public static Single ToSingle(SqlString p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }

        public static Single ToSingle(SqlByte p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }
        public static Single ToSingle(SqlInt16 p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }
        public static Single ToSingle(SqlInt32 p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }
        public static Single ToSingle(SqlInt64 p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }

        public static Single ToSingle(SqlDouble p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }
        public static Single ToSingle(SqlDecimal p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }
        public static Single ToSingle(SqlMoney p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }

        public static Single ToSingle(SqlBoolean p) { return p.IsNull ? 0.0f : ToSingle(p.Value); }
#endif
        public static Single ToSingle(object p)
        {
            if (p == null || p is DBNull) return 0.0f;

            if (p is Single) return (Single)p;

            // Scalar Types.
            //
            if (p is String) return ToSingle((String)p);

            if (p is Boolean) return ToSingle((Boolean)p);
            if (p is Char) return ToSingle((Char)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlSingle) return ToSingle((SqlSingle)p);
#endif
            if (p is IConvertible) return ((IConvertible)p).ToSingle(null);

            throw CreateInvalidCastException(p.GetType(), typeof(Single));
        }

        #endregion

        #region Double

        // Scalar Types.
        // 
        public static Double ToDouble(String p) { return p == null ? 0.0 : Double.Parse(p); }

        [CLSCompliant(false)]
        public static Double ToDouble(SByte p) { return checked((Double)p); }
        public static Double ToDouble(Int16 p) { return checked((Double)p); }
        public static Double ToDouble(Int32 p) { return checked((Double)p); }
        public static Double ToDouble(Int64 p) { return checked((Double)p); }

        public static Double ToDouble(Byte p) { return checked((Double)p); }
        [CLSCompliant(false)]
        public static Double ToDouble(UInt16 p) { return checked((Double)p); }
        [CLSCompliant(false)]
        public static Double ToDouble(UInt32 p) { return checked((Double)p); }
        [CLSCompliant(false)]
        public static Double ToDouble(UInt64 p) { return checked((Double)p); }

        public static Double ToDouble(Single p) { return checked((Double)p); }

        public static Double ToDouble(Decimal p) { return checked((Double)p); }
        public static Double ToDouble(Boolean p) { return p ? 1.0 : 0.0; }
        public static Double ToDouble(Char p) { return checked((Double)p); }
        public static Double ToDouble(DateTime p) { return (p - DateTime.MinValue).TotalDays; }
        public static Double ToDouble(TimeSpan p) { return p.TotalDays; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Double ToDouble(Double? p)     { return p.HasValue?                 p.Value:  0.0; }

		[CLSCompliant(false)]
		public static Double ToDouble(SByte? p)      { return p.HasValue? checked((Double)p.Value):  0.0; }
		public static Double ToDouble(Int16? p)      { return p.HasValue? checked((Double)p.Value):  0.0; }
		public static Double ToDouble(Int32? p)      { return p.HasValue? checked((Double)p.Value):  0.0; }
		public static Double ToDouble(Int64? p)      { return p.HasValue? checked((Double)p.Value):  0.0; }

		public static Double ToDouble(Byte? p)       { return p.HasValue? checked((Double)p.Value):  0.0; }
		[CLSCompliant(false)]
		public static Double ToDouble(UInt16? p)     { return p.HasValue? checked((Double)p.Value):  0.0; }
		[CLSCompliant(false)]
		public static Double ToDouble(UInt32? p)     { return p.HasValue? checked((Double)p.Value):  0.0; }
		[CLSCompliant(false)]
		public static Double ToDouble(UInt64? p)     { return p.HasValue? checked((Double)p.Value):  0.0; }

		public static Double ToDouble(Single? p)     { return p.HasValue? checked((Double)p.Value):  0.0; }

		public static Double ToDouble(Decimal? p)    { return p.HasValue? checked((Double)p.Value):  0.0; }
		public static Double ToDouble(Char? p)       { return p.HasValue? checked((Double)p.Value):  0.0; }
		public static Double ToDouble(Boolean? p)    { return (p.HasValue && p.Value)?         1.0: 0.0; }
		public static Double ToDouble(DateTime? p)   { return p.HasValue? (p.Value - DateTime.MinValue).TotalDays: 0.0; }
		public static Double ToDouble(TimeSpan? p)   { return p.HasValue? p.Value.TotalDays: 0.0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Double ToDouble(SqlDouble p) { return p.IsNull ? 0.0 : p.Value; }
        public static Double ToDouble(SqlString p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }

        public static Double ToDouble(SqlByte p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
        public static Double ToDouble(SqlInt16 p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
        public static Double ToDouble(SqlInt32 p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
        public static Double ToDouble(SqlInt64 p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }

        public static Double ToDouble(SqlSingle p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
        public static Double ToDouble(SqlDecimal p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
        public static Double ToDouble(SqlMoney p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }

        public static Double ToDouble(SqlBoolean p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
        public static Double ToDouble(SqlDateTime p) { return p.IsNull ? 0.0 : ToDouble(p.Value); }
#endif
        public static Double ToDouble(object p)
        {
            if (p == null || p is DBNull) return 0.0;

            if (p is Double) return (Double)p;

            // Scalar Types.
            //
            if (p is String) return ToDouble((String)p);

            if (p is Boolean) return ToDouble((Boolean)p);
            if (p is Char) return ToDouble((Char)p);
            if (p is DateTime) return ToDouble((DateTime)p);
            if (p is TimeSpan) return ToDouble((TimeSpan)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlDouble) return ToDouble((SqlDouble)p);
            if (p is SqlDateTime) return ToDouble((SqlDateTime)p);
#endif
            if (p is IConvertible) return ((IConvertible)p).ToDouble(null);

            throw CreateInvalidCastException(p.GetType(), typeof(Double));
        }

        #endregion

        #region Boolean

        // Scalar Types.
        // 
        public static Boolean ToBoolean(String p) { return p == null ? false : Boolean.Parse(p); }

        [CLSCompliant(false)]
        public static Boolean ToBoolean(SByte p) { return p != 0; }
        public static Boolean ToBoolean(Int16 p) { return p != 0; }
        public static Boolean ToBoolean(Int32 p) { return p != 0; }
        public static Boolean ToBoolean(Int64 p) { return p != 0; }

        public static Boolean ToBoolean(Byte p) { return p != 0; }
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt16 p) { return p != 0; }
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt32 p) { return p != 0; }
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt64 p) { return p != 0; }

        public static Boolean ToBoolean(Single p) { return p != 0; }
        public static Boolean ToBoolean(Double p) { return p != 0; }

        public static Boolean ToBoolean(Decimal p) { return p != 0; }

        public static Boolean ToBoolean(Char p)
        {
            switch (p)
            {
                case (Char)0: return false; // Allow int <=> Char <=> Boolean
                case '0': return false;
                case 'n': return false;
                case 'N': return false;
                case 'f': return false;
                case 'F': return false;

                case (Char)1: return true; // Allow int <=> Char <=> Boolean
                case '1': return true;
                case 'y': return true;
                case 'Y': return true;
                case 't': return true;
                case 'T': return true;
            }

            throw new InvalidCastException(string.Format(
                "Invalid cast from {0} to {1}", typeof(Char).FullName, typeof(Boolean).FullName));

        }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Boolean ToBoolean(Boolean? p)    { return p.HasValue? p.Value:      false; }

		[CLSCompliant(false)]
		public static Boolean ToBoolean(SByte? p)      { return p.HasValue? p.Value != 0: false; }
		public static Boolean ToBoolean(Int16? p)      { return p.HasValue? p.Value != 0: false; }
		public static Boolean ToBoolean(Int32? p)      { return p.HasValue? p.Value != 0: false; }
		public static Boolean ToBoolean(Int64? p)      { return p.HasValue? p.Value != 0: false; }

		public static Boolean ToBoolean(Byte? p)       { return p.HasValue? p.Value != 0: false; }
		[CLSCompliant(false)]
		public static Boolean ToBoolean(UInt16? p)     { return p.HasValue? p.Value != 0: false; }
		[CLSCompliant(false)]
		public static Boolean ToBoolean(UInt32? p)     { return p.HasValue? p.Value != 0: false; }
		[CLSCompliant(false)]
		public static Boolean ToBoolean(UInt64? p)     { return p.HasValue? p.Value != 0: false; }

		public static Boolean ToBoolean(Single? p)     { return p.HasValue? p.Value != 0: false; }
		public static Boolean ToBoolean(Double? p)     { return p.HasValue? p.Value != 0: false; }

		public static Boolean ToBoolean(Decimal? p)    { return p.HasValue? p.Value != 0: false; }

		public static Boolean ToBoolean(Char? p)       { return p.HasValue? ToBoolean(p.Value): false; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Boolean ToBoolean(SqlBoolean p) { return p.IsNull ? false : p.Value; }
        public static Boolean ToBoolean(SqlString p) { return p.IsNull ? false : ToBoolean(p.Value); }

        public static Boolean ToBoolean(SqlByte p) { return p.IsNull ? false : ToBoolean(p.Value); }
        public static Boolean ToBoolean(SqlInt16 p) { return p.IsNull ? false : ToBoolean(p.Value); }
        public static Boolean ToBoolean(SqlInt32 p) { return p.IsNull ? false : ToBoolean(p.Value); }
        public static Boolean ToBoolean(SqlInt64 p) { return p.IsNull ? false : ToBoolean(p.Value); }

        public static Boolean ToBoolean(SqlSingle p) { return p.IsNull ? false : ToBoolean(p.Value); }
        public static Boolean ToBoolean(SqlDouble p) { return p.IsNull ? false : ToBoolean(p.Value); }
        public static Boolean ToBoolean(SqlDecimal p) { return p.IsNull ? false : ToBoolean(p.Value); }
        public static Boolean ToBoolean(SqlMoney p) { return p.IsNull ? false : ToBoolean(p.Value); }
#endif

        public static Boolean ToBoolean(object p)
        {
            if (p == null || p is DBNull) return false;

            if (p is Boolean) return (Boolean)p;

            // Scalar Types.
            //
            if (p is String) return ToBoolean((String)p);

            if (p is Char) return ToBoolean((Char)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlBoolean) return ToBoolean((SqlBoolean)p);
#endif
            if (p is IConvertible) return ((IConvertible)p).ToBoolean(null);

            throw CreateInvalidCastException(p.GetType(), typeof(Boolean));
        }

        #endregion

        #region Decimal

        // Scalar Types.
        // 
        public static Decimal ToDecimal(String p) { return p == null ? 0.0m : Decimal.Parse(p); }

        [CLSCompliant(false)]
        public static Decimal ToDecimal(SByte p) { return checked((Decimal)p); }
        public static Decimal ToDecimal(Int16 p) { return checked((Decimal)p); }
        public static Decimal ToDecimal(Int32 p) { return checked((Decimal)p); }
        public static Decimal ToDecimal(Int64 p) { return checked((Decimal)p); }

        public static Decimal ToDecimal(Byte p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt16 p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt32 p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt64 p) { return checked((Decimal)p); }

        public static Decimal ToDecimal(Single p) { return checked((Decimal)p); }
        public static Decimal ToDecimal(Double p) { return checked((Decimal)p); }

        public static Decimal ToDecimal(Boolean p) { return p ? 1.0m : 0.0m; }
        public static Decimal ToDecimal(Char p) { return checked((Decimal)p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Decimal ToDecimal(Decimal? p)    { return p.HasValue?                  p.Value:  0.0m; }

		[CLSCompliant(false)]
		public static Decimal ToDecimal(SByte? p)      { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		public static Decimal ToDecimal(Int16? p)      { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		public static Decimal ToDecimal(Int32? p)      { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		public static Decimal ToDecimal(Int64? p)      { return p.HasValue? checked((Decimal)p.Value): 0.0m; }

		public static Decimal ToDecimal(Byte? p)       { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		[CLSCompliant(false)]
		public static Decimal ToDecimal(UInt16? p)     { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		[CLSCompliant(false)]
		public static Decimal ToDecimal(UInt32? p)     { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		[CLSCompliant(false)]
		public static Decimal ToDecimal(UInt64? p)     { return p.HasValue? checked((Decimal)p.Value): 0.0m; }

		public static Decimal ToDecimal(Single? p)     { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		public static Decimal ToDecimal(Double? p)     { return p.HasValue? checked((Decimal)p.Value): 0.0m; }

		public static Decimal ToDecimal(Char? p)       { return p.HasValue? checked((Decimal)p.Value): 0.0m; }
		public static Decimal ToDecimal(Boolean? p)    { return (p.HasValue && p.Value)?         1.0m: 0.0m; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Decimal ToDecimal(SqlDecimal p) { return p.IsNull ? 0.0m : p.Value; }
        public static Decimal ToDecimal(SqlMoney p) { return p.IsNull ? 0.0m : p.Value; }
        public static Decimal ToDecimal(SqlString p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }

        public static Decimal ToDecimal(SqlByte p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }
        public static Decimal ToDecimal(SqlInt16 p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }
        public static Decimal ToDecimal(SqlInt32 p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }
        public static Decimal ToDecimal(SqlInt64 p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }

        public static Decimal ToDecimal(SqlSingle p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }
        public static Decimal ToDecimal(SqlDouble p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }

        public static Decimal ToDecimal(SqlBoolean p) { return p.IsNull ? 0.0m : ToDecimal(p.Value); }
#endif
        public static Decimal ToDecimal(object p)
        {
            if (p == null || p is DBNull) return 0.0m;

            if (p is Decimal) return (Decimal)p;

            // Scalar Types.
            //
            if (p is String) return ToDecimal((String)p);

            if (p is Boolean) return ToDecimal((Boolean)p);
            if (p is Char) return ToDecimal((Char)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlDecimal) return ToDecimal((SqlDecimal)p);
            if (p is SqlMoney) return ToDecimal((SqlMoney)p);
#endif
            if (p is IConvertible) return ((IConvertible)p).ToDecimal(null);

            throw CreateInvalidCastException(p.GetType(), typeof(Decimal));
        }

        #endregion

        #region DateTime

        // Scalar Types.
        // 
        public static DateTime ToDateTime(String p) { return p == null ? DateTime.MinValue : DateTime.Parse(p); }
        public static DateTime ToDateTime(TimeSpan p) { return DateTime.MinValue + p; }
        public static DateTime ToDateTime(Int64 p) { return DateTime.MinValue + TimeSpan.FromTicks(p); }
        public static DateTime ToDateTime(Double p) { return DateTime.MinValue + TimeSpan.FromDays(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static DateTime ToDateTime(DateTime? p)   { return p.HasValue?                                               p.Value:  DateTime.MinValue; }
		public static DateTime ToDateTime(TimeSpan? p)   { return p.HasValue? DateTime.MinValue +                           p.Value:  DateTime.MinValue; }
		public static DateTime ToDateTime(Int64? p)      { return p.HasValue? DateTime.MinValue +        TimeSpan.FromTicks(p.Value): DateTime.MinValue; }
		public static DateTime ToDateTime(Double? p)     { return p.HasValue? DateTime.MinValue + TimeSpan.FromDays(p.Value): DateTime.MinValue; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static DateTime ToDateTime(SqlDateTime p) { return p.IsNull ? DateTime.MinValue : p.Value; }
        public static DateTime ToDateTime(SqlString p) { return p.IsNull ? DateTime.MinValue : ToDateTime(p.Value); }
        public static DateTime ToDateTime(SqlInt64 p) { return p.IsNull ? DateTime.MinValue : DateTime.MinValue + TimeSpan.FromTicks(p.Value); }
        public static DateTime ToDateTime(SqlDouble p) { return p.IsNull ? DateTime.MinValue : DateTime.MinValue + TimeSpan.FromDays(p.Value); }
#endif
        public static DateTime ToDateTime(object p)
        {
            if (p == null || p is DBNull) return DateTime.MinValue;

            if (p is DateTime) return (DateTime)p;

            // Scalar Types.
            //
            if (p is String) return ToDateTime((String)p);
            if (p is TimeSpan) return ToDateTime((TimeSpan)p);
            if (p is Int64) return ToDateTime((Int64)p);
            if (p is Double) return ToDateTime((Double)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlDateTime) return ToDateTime((SqlDateTime)p);
            if (p is SqlString) return ToDateTime((SqlString)p);
            if (p is SqlInt64) return ToDateTime((SqlInt64)p);
            if (p is SqlDouble) return ToDateTime((SqlDouble)p);
#endif
            if (p is IConvertible) return ((IConvertible)p).ToDateTime(null);

            throw CreateInvalidCastException(p.GetType(), typeof(DateTime));
        }

        #endregion

        #region TimeSpan

        // Scalar Types.
        // 
        public static TimeSpan ToTimeSpan(String p) { return p == null ? TimeSpan.MinValue : TimeSpan.Parse(p); }
        public static TimeSpan ToTimeSpan(DateTime p) { return p - DateTime.MinValue; }
        public static TimeSpan ToTimeSpan(Int64 p) { return TimeSpan.FromTicks(p); }
        public static TimeSpan ToTimeSpan(Double p) { return TimeSpan.FromDays(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static TimeSpan ToTimeSpan(TimeSpan? p)   { return p.HasValue? p.Value:                            TimeSpan.MinValue; }
		public static TimeSpan ToTimeSpan(DateTime? p)   { return p.HasValue? p.Value - DateTime.MinValue:        TimeSpan.MinValue; }
		public static TimeSpan ToTimeSpan(Int64? p)      { return p.HasValue? TimeSpan.FromTicks(p.Value):        TimeSpan.MinValue; }
		public static TimeSpan ToTimeSpan(Double? p)     { return p.HasValue? TimeSpan.FromDays(p.Value): TimeSpan.MinValue; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static TimeSpan ToTimeSpan(SqlString p) { return p.IsNull ? TimeSpan.MinValue : TimeSpan.Parse(p.Value); }
        public static TimeSpan ToTimeSpan(SqlDateTime p) { return p.IsNull ? TimeSpan.MinValue : p.Value - DateTime.MinValue; }
        public static TimeSpan ToTimeSpan(SqlInt64 p) { return p.IsNull ? TimeSpan.MinValue : TimeSpan.FromTicks(p.Value); }
        public static TimeSpan ToTimeSpan(SqlDouble p) { return p.IsNull ? TimeSpan.MinValue : TimeSpan.FromDays(p.Value); }
#endif
        public static TimeSpan ToTimeSpan(object p)
        {
            if (p == null || p is DBNull) return TimeSpan.MinValue;

            if (p is TimeSpan) return (TimeSpan)p;

            // Scalar Types.
            //
            if (p is String) return ToTimeSpan((String)p);
            if (p is DateTime) return ToTimeSpan((DateTime)p);
            if (p is Int64) return ToTimeSpan((Int64)p);
            if (p is Double) return ToTimeSpan((Double)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlString) return ToTimeSpan((SqlString)p);
            if (p is SqlDateTime) return ToTimeSpan((SqlDateTime)p);
            if (p is SqlInt64) return ToTimeSpan((SqlInt64)p);
            if (p is SqlDouble) return ToTimeSpan((SqlDouble)p);
#endif
            throw CreateInvalidCastException(p.GetType(), typeof(TimeSpan));
        }

        #endregion

        #region Guid

        // Scalar Types.
        // 
        public static Guid ToGuid(String p) { return p == null ? Guid.Empty : new Guid(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Guid ToGuid(Guid? p)       { return p.HasValue? p.Value : Guid.Empty; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Guid ToGuid(SqlGuid p) { return p.IsNull ? Guid.Empty : p.Value; }
        public static Guid ToGuid(SqlString p) { return p.IsNull ? Guid.Empty : new Guid(p.Value); }
        public static Guid ToGuid(SqlBinary p) { return p.IsNull ? Guid.Empty : p.ToSqlGuid().Value; }
#endif
        // Other Types.
        // 
        public static Guid ToGuid(Byte[] p) { return p == null ? Guid.Empty : new Guid(p); }
        public static Guid ToGuid(Type p) { return p == null ? Guid.Empty : p.GUID; }

        public static Guid ToGuid(object p)
        {
            if (p == null || p is DBNull) return Guid.Empty;

            if (p is Guid) return (Guid)p;

            // Scalar Types.
            //
            if (p is String) return ToGuid((String)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlGuid) return ToGuid((SqlGuid)p);
            if (p is SqlString) return ToGuid((SqlString)p);
            if (p is SqlBinary) return ToGuid((SqlBinary)p);
#endif
            // Other Types.
            //
            if (p is Byte[]) return ToGuid((Byte[])p);
            if (p is Type) return ToGuid((Type)p);

            throw CreateInvalidCastException(p.GetType(), typeof(Guid));
        }

        #endregion

        #endregion

#if !(NET_1_1)
        #region Nullable Types

        #region SByte?

        // Scalar Types.
		// 
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SByte p)       { return p; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(String p)      { return p == null? null: (SByte?)SByte.Parse(p); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Int16 p)       { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Int32 p)       { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Int64 p)       { return      checked((SByte?)p); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Byte p)        { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(UInt16 p)      { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(UInt32 p)      { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(UInt64 p)      { return      checked((SByte?)p); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Single p)      { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Double p)      { return      checked((SByte?)p); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Decimal p)     { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Char p)        { return      checked((SByte?)p); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Boolean p)     { return       (SByte?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Int16? p)      { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Int32? p)      { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Int64? p)      { return p.HasValue? checked((SByte?)p.Value): null; }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Byte? p)       { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(UInt16? p)     { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(UInt32? p)     { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(UInt64? p)     { return p.HasValue? checked((SByte?)p.Value): null; }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Single? p)     { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Double? p)     { return p.HasValue? checked((SByte?)p.Value): null; }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Decimal? p)    { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Char? p)       { return p.HasValue? checked((SByte?)p.Value): null; }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(Boolean? p)    { return p.HasValue? (SByte?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlString p)   { return p.IsNull? null: ToNullableSByte(p.Value); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlByte p)     { return p.IsNull? null: ToNullableSByte(p.Value); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlInt16 p)    { return p.IsNull? null: ToNullableSByte(p.Value); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlInt32 p)    { return p.IsNull? null: ToNullableSByte(p.Value); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlInt64 p)    { return p.IsNull? null: ToNullableSByte(p.Value); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlSingle p)   { return p.IsNull? null: ToNullableSByte(p.Value); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlDouble p)   { return p.IsNull? null: ToNullableSByte(p.Value); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlDecimal p)  { return p.IsNull? null: ToNullableSByte(p.Value); }
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlMoney p)    { return p.IsNull? null: ToNullableSByte(p.Value); }

		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(SqlBoolean p)  { return p.IsNull? null: ToNullableSByte(p.Value); }
#endif
		[CLSCompliant(false)]
		public static SByte? ToNullableSByte(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is SByte)       return ToNullableSByte((SByte)p);
			if (p is String)      return ToNullableSByte((String)p);

			if (p is Char)        return ToNullableSByte((Char)p);
			if (p is Boolean)     return ToNullableSByte((Boolean)p);

			if (p is IConvertible) return ((IConvertible)p).ToSByte(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(SByte?));
		}

        #endregion

        #region Int16?

		// Scalar Types.
		// 
		public static Int16? ToNullableInt16(Int16 p)       { return p; }
		public static Int16? ToNullableInt16(String p)      { return p == null? null: (Int16?)Int16.Parse(p); }

		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(SByte p)       { return      checked((Int16?)p); }
		public static Int16? ToNullableInt16(Int32 p)       { return      checked((Int16?)p); }
		public static Int16? ToNullableInt16(Int64 p)       { return      checked((Int16?)p); }

		public static Int16? ToNullableInt16(Byte p)        { return      checked((Int16?)p); }
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(UInt16 p)      { return      checked((Int16?)p); }
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(UInt32 p)      { return      checked((Int16?)p); }
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(UInt64 p)      { return      checked((Int16?)p); }

		public static Int16? ToNullableInt16(Single p)      { return      checked((Int16?)p); }
		public static Int16? ToNullableInt16(Double p)      { return      checked((Int16?)p); }

		public static Int16? ToNullableInt16(Decimal p)     { return      checked((Int16?)p); }
		public static Int16? ToNullableInt16(Char p)        { return      checked((Int16?)p); }
		public static Int16? ToNullableInt16(Boolean p)     { return       (Int16?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(SByte? p)      { return p.HasValue? checked((Int16?)p.Value): null; }
		public static Int16? ToNullableInt16(Int32? p)      { return p.HasValue? checked((Int16?)p.Value): null; }
		public static Int16? ToNullableInt16(Int64? p)      { return p.HasValue? checked((Int16?)p.Value): null; }

		public static Int16? ToNullableInt16(Byte? p)       { return p.HasValue? checked((Int16?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(UInt16? p)     { return p.HasValue? checked((Int16?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(UInt32? p)     { return p.HasValue? checked((Int16?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int16? ToNullableInt16(UInt64? p)     { return p.HasValue? checked((Int16?)p.Value): null; }

		public static Int16? ToNullableInt16(Single? p)     { return p.HasValue? checked((Int16?)p.Value): null; }
		public static Int16? ToNullableInt16(Double? p)     { return p.HasValue? checked((Int16?)p.Value): null; }

		public static Int16? ToNullableInt16(Decimal? p)    { return p.HasValue? checked((Int16?)p.Value): null; }
		public static Int16? ToNullableInt16(Char? p)       { return p.HasValue? checked((Int16?)p.Value): null; }
		public static Int16? ToNullableInt16(Boolean? p)    { return p.HasValue? (Int16?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Int16? ToNullableInt16(SqlInt16 p)    { return p.IsNull? null:         (Int16?)p.Value;  }
		public static Int16? ToNullableInt16(SqlString p)   { return p.IsNull? null: ToNullableInt16(p.Value); }

		public static Int16? ToNullableInt16(SqlByte p)     { return p.IsNull? null: ToNullableInt16(p.Value); }
		public static Int16? ToNullableInt16(SqlInt32 p)    { return p.IsNull? null: ToNullableInt16(p.Value); }
		public static Int16? ToNullableInt16(SqlInt64 p)    { return p.IsNull? null: ToNullableInt16(p.Value); }

		public static Int16? ToNullableInt16(SqlSingle p)   { return p.IsNull? null: ToNullableInt16(p.Value); }
		public static Int16? ToNullableInt16(SqlDouble p)   { return p.IsNull? null: ToNullableInt16(p.Value); }
		public static Int16? ToNullableInt16(SqlDecimal p)  { return p.IsNull? null: ToNullableInt16(p.Value); }
		public static Int16? ToNullableInt16(SqlMoney p)    { return p.IsNull? null: ToNullableInt16(p.Value); }

		public static Int16? ToNullableInt16(SqlBoolean p)  { return p.IsNull? null: ToNullableInt16(p.Value); }
#endif
		public static Int16? ToNullableInt16(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Int16)       return ToNullableInt16((Int16)p);
			if (p is String)      return ToNullableInt16((String)p);

			if (p is Char)        return ToNullableInt16((Char)p);
			if (p is Boolean)     return ToNullableInt16((Boolean)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlInt16)    return ToNullableInt16((SqlInt16)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToInt16(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Int16?));
		}

        #endregion

        #region Int32?

		// Scalar Types.
		// 
		public static Int32? ToNullableInt32(Int32 p)       { return p; }
		public static Int32? ToNullableInt32(String p)      { return p == null? null: (Int32?)Int32.Parse(p); }

		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(SByte p)       { return checked((Int32?)p); }
		public static Int32? ToNullableInt32(Int16 p)       { return checked((Int32?)p); }
		public static Int32? ToNullableInt32(Int64 p)       { return checked((Int32?)p); }

		public static Int32? ToNullableInt32(Byte p)        { return checked((Int32?)p); }
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(UInt16 p)      { return checked((Int32?)p); }
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(UInt32 p)      { return checked((Int32?)p); }
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(UInt64 p)      { return checked((Int32?)p); }

		public static Int32? ToNullableInt32(Single p)      { return checked((Int32?)p); }
		public static Int32? ToNullableInt32(Double p)      { return checked((Int32?)p); }

		public static Int32? ToNullableInt32(Decimal p)     { return checked((Int32?)p); }
		public static Int32? ToNullableInt32(Char p)        { return checked((Int32?)p); }
		public static Int32? ToNullableInt32(Boolean p)     { return p? 1: 0; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(SByte? p)      { return p.HasValue? checked((Int32?)p.Value): null; }
		public static Int32? ToNullableInt32(Int16? p)      { return p.HasValue? checked((Int32?)p.Value): null; }
		public static Int32? ToNullableInt32(Int64? p)      { return p.HasValue? checked((Int32?)p.Value): null; }

		public static Int32? ToNullableInt32(Byte? p)       { return p.HasValue? checked((Int32?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(UInt16? p)     { return p.HasValue? checked((Int32?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(UInt32? p)     { return p.HasValue? checked((Int32?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int32? ToNullableInt32(UInt64? p)     { return p.HasValue? checked((Int32?)p.Value): null; }

		public static Int32? ToNullableInt32(Single? p)     { return p.HasValue? checked((Int32?)p.Value): null; }
		public static Int32? ToNullableInt32(Double? p)     { return p.HasValue? checked((Int32?)p.Value): null; }

		public static Int32? ToNullableInt32(Decimal? p)    { return p.HasValue? checked((Int32?)p.Value): null; }
		public static Int32? ToNullableInt32(Char? p)       { return p.HasValue? checked((Int32?)p.Value): null; }
		public static Int32? ToNullableInt32(Boolean? p)    { return p.HasValue? (Int32?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Int32? ToNullableInt32(SqlInt32 p)    { return p.IsNull? null:         (Int32?)p.Value;  }
		public static Int32? ToNullableInt32(SqlString p)   { return p.IsNull? null: ToNullableInt32(p.Value); }

		public static Int32? ToNullableInt32(SqlByte p)     { return p.IsNull? null: ToNullableInt32(p.Value); }
		public static Int32? ToNullableInt32(SqlInt16 p)    { return p.IsNull? null: ToNullableInt32(p.Value); }
		public static Int32? ToNullableInt32(SqlInt64 p)    { return p.IsNull? null: ToNullableInt32(p.Value); }

		public static Int32? ToNullableInt32(SqlSingle p)   { return p.IsNull? null: ToNullableInt32(p.Value); }
		public static Int32? ToNullableInt32(SqlDouble p)   { return p.IsNull? null: ToNullableInt32(p.Value); }
		public static Int32? ToNullableInt32(SqlDecimal p)  { return p.IsNull? null: ToNullableInt32(p.Value); }
		public static Int32? ToNullableInt32(SqlMoney p)    { return p.IsNull? null: ToNullableInt32(p.Value); }

		public static Int32? ToNullableInt32(SqlBoolean p)  { return p.IsNull? null: ToNullableInt32(p.Value); }
#endif
		public static Int32? ToNullableInt32(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Int32)       return ToNullableInt32((Int32)p);
			if (p is String)      return ToNullableInt32((String)p);

			if (p is Char)        return ToNullableInt32((Char)p);
			if (p is Boolean)     return ToNullableInt32((Boolean)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlInt32)    return ToNullableInt32((SqlInt32)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToInt32(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Int32?));
		}

        #endregion

        #region Int64?

		// Scalar Types.
		// 
		public static Int64? ToNullableInt64(Int64 p)       { return p; }
		public static Int64? ToNullableInt64(String p)      { return p == null? null: (Int64?)Int64.Parse(p); }

		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(SByte p)       { return checked((Int64?)p); }
		public static Int64? ToNullableInt64(Int16 p)       { return checked((Int64?)p); }
		public static Int64? ToNullableInt64(Int32 p)       { return checked((Int64?)p); }

		public static Int64? ToNullableInt64(Byte p)        { return checked((Int64?)p); }
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(UInt16 p)      { return checked((Int64?)p); }
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(UInt32 p)      { return checked((Int64?)p); }
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(UInt64 p)      { return checked((Int64?)p); }

		public static Int64? ToNullableInt64(Single p)      { return checked((Int64?)p); }
		public static Int64? ToNullableInt64(Double p)      { return checked((Int64?)p); }

		public static Int64? ToNullableInt64(Decimal p)     { return checked((Int64?)p); }
		public static Int64? ToNullableInt64(Char p)        { return checked((Int64?)p); }
		public static Int64? ToNullableInt64(Boolean p)     { return p? 1: 0; }
		public static Int64? ToNullableInt64(DateTime p)    { return (p - DateTime.MinValue).Ticks; }
		public static Int64? ToNullableInt64(TimeSpan p)    { return p.Ticks; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(SByte? p)      { return p.HasValue? checked((Int64?)p.Value): null; }
		public static Int64? ToNullableInt64(Int16? p)      { return p.HasValue? checked((Int64?)p.Value): null; }
		public static Int64? ToNullableInt64(Int32? p)      { return p.HasValue? checked((Int64?)p.Value): null; }

		public static Int64? ToNullableInt64(Byte? p)       { return p.HasValue? checked((Int64?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(UInt16? p)     { return p.HasValue? checked((Int64?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(UInt32? p)     { return p.HasValue? checked((Int64?)p.Value): null; }
		[CLSCompliant(false)]
		public static Int64? ToNullableInt64(UInt64? p)     { return p.HasValue? checked((Int64?)p.Value): null; }

		public static Int64? ToNullableInt64(Single? p)     { return p.HasValue? checked((Int64?)p.Value): null; }
		public static Int64? ToNullableInt64(Double? p)     { return p.HasValue? checked((Int64?)p.Value): null; }

		public static Int64? ToNullableInt64(Decimal? p)    { return p.HasValue? checked((Int64?)p.Value): null; }
		public static Int64? ToNullableInt64(Char? p)       { return p.HasValue? checked((Int64?)p.Value): null; }
		public static Int64? ToNullableInt64(Boolean? p)    { return p.HasValue? (Int64?)(p.Value? 1: 0):  null; }
		public static Int64? ToNullableInt64(DateTime? p)   { return p.HasValue? (Int64?)(p.Value - DateTime.MinValue).Ticks: null; }
		public static Int64? ToNullableInt64(TimeSpan? p)   { return p.HasValue? (Int64?)p.Value.Ticks: null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Int64? ToNullableInt64(SqlInt64 p)    { return p.IsNull? null:         (Int64?)p.Value;  }
		public static Int64? ToNullableInt64(SqlString p)   { return p.IsNull? null: ToNullableInt64(p.Value); }

		public static Int64? ToNullableInt64(SqlByte p)     { return p.IsNull? null: ToNullableInt64(p.Value); }
		public static Int64? ToNullableInt64(SqlInt16 p)    { return p.IsNull? null: ToNullableInt64(p.Value); }
		public static Int64? ToNullableInt64(SqlInt32 p)    { return p.IsNull? null: ToNullableInt64(p.Value); }

		public static Int64? ToNullableInt64(SqlSingle p)   { return p.IsNull? null: ToNullableInt64(p.Value); }
		public static Int64? ToNullableInt64(SqlDouble p)   { return p.IsNull? null: ToNullableInt64(p.Value); }
		public static Int64? ToNullableInt64(SqlDecimal p)  { return p.IsNull? null: ToNullableInt64(p.Value); }
		public static Int64? ToNullableInt64(SqlMoney p)    { return p.IsNull? null: ToNullableInt64(p.Value); }

		public static Int64? ToNullableInt64(SqlBoolean p)  { return p.IsNull? null: ToNullableInt64(p.Value); }
		public static Int64? ToNullableInt64(SqlDateTime p) { return p.IsNull? null: ToNullableInt64(p.Value); }
#endif
		public static Int64? ToNullableInt64(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Int64)       return ToNullableInt64((Int64)p);
			if (p is String)      return ToNullableInt64((String)p);

			if (p is Char)        return ToNullableInt64((Char)p);
			if (p is Boolean)     return ToNullableInt64((Boolean)p);
			if (p is DateTime)    return ToNullableInt64((DateTime)p);
			if (p is TimeSpan)    return ToNullableInt64((TimeSpan)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlInt64)    return ToNullableInt64((SqlInt64)p);
			if (p is SqlDateTime) return ToNullableInt64((SqlDateTime)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToInt64(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Int64?));
		}

        #endregion

        #region Byte?

		// Scalar Types.
		// 
		public static Byte? ToNullableByte(Byte p)        { return p; }
		public static Byte? ToNullableByte(String p)      { return p == null? null: (Byte?)Byte.Parse(p); }

		[CLSCompliant(false)]
		public static Byte? ToNullableByte(SByte p)       { return      checked((Byte?)p); }
		public static Byte? ToNullableByte(Int16 p)       { return      checked((Byte?)p); }
		public static Byte? ToNullableByte(Int32 p)       { return      checked((Byte?)p); }
		public static Byte? ToNullableByte(Int64 p)       { return      checked((Byte?)p); }

		[CLSCompliant(false)]
		public static Byte? ToNullableByte(UInt16 p)      { return      checked((Byte?)p); }
		[CLSCompliant(false)]
		public static Byte? ToNullableByte(UInt32 p)      { return      checked((Byte?)p); }
		[CLSCompliant(false)]
		public static Byte? ToNullableByte(UInt64 p)      { return      checked((Byte?)p); }

		public static Byte? ToNullableByte(Single p)      { return      checked((Byte?)p); }
		public static Byte? ToNullableByte(Double p)      { return      checked((Byte?)p); }

		public static Byte? ToNullableByte(Decimal p)     { return      checked((Byte?)p); }
		public static Byte? ToNullableByte(Char p)        { return      checked((Byte?)p); }
		public static Byte? ToNullableByte(Boolean p)     { return       (Byte?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Byte? ToNullableByte(SByte? p)      { return p.HasValue? checked((Byte?)p.Value): null; }
		public static Byte? ToNullableByte(Int16? p)      { return p.HasValue? checked((Byte?)p.Value): null; }
		public static Byte? ToNullableByte(Int32? p)      { return p.HasValue? checked((Byte?)p.Value): null; }
		public static Byte? ToNullableByte(Int64? p)      { return p.HasValue? checked((Byte?)p.Value): null; }

		[CLSCompliant(false)]
		public static Byte? ToNullableByte(UInt16? p)     { return p.HasValue? checked((Byte?)p.Value): null; }
		[CLSCompliant(false)]
		public static Byte? ToNullableByte(UInt32? p)     { return p.HasValue? checked((Byte?)p.Value): null; }
		[CLSCompliant(false)]
		public static Byte? ToNullableByte(UInt64? p)     { return p.HasValue? checked((Byte?)p.Value): null; }

		public static Byte? ToNullableByte(Single? p)     { return p.HasValue? checked((Byte?)p.Value): null; }
		public static Byte? ToNullableByte(Double? p)     { return p.HasValue? checked((Byte?)p.Value): null; }

		public static Byte? ToNullableByte(Decimal? p)    { return p.HasValue? checked((Byte?)p.Value): null; }
		public static Byte? ToNullableByte(Char? p)       { return p.HasValue? checked((Byte?)p.Value): null; }
		public static Byte? ToNullableByte(Boolean? p)    { return p.HasValue? (Byte?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Byte? ToNullableByte(SqlByte p)     { return p.IsNull? null:         (Byte?)p.Value;  }
		public static Byte? ToNullableByte(SqlString p)   { return p.IsNull? null: ToNullableByte(p.Value); }

		public static Byte? ToNullableByte(SqlInt16 p)    { return p.IsNull? null: ToNullableByte(p.Value); }
		public static Byte? ToNullableByte(SqlInt32 p)    { return p.IsNull? null: ToNullableByte(p.Value); }
		public static Byte? ToNullableByte(SqlInt64 p)    { return p.IsNull? null: ToNullableByte(p.Value); }

		public static Byte? ToNullableByte(SqlSingle p)   { return p.IsNull? null: ToNullableByte(p.Value); }
		public static Byte? ToNullableByte(SqlDouble p)   { return p.IsNull? null: ToNullableByte(p.Value); }
		public static Byte? ToNullableByte(SqlDecimal p)  { return p.IsNull? null: ToNullableByte(p.Value); }
		public static Byte? ToNullableByte(SqlMoney p)    { return p.IsNull? null: ToNullableByte(p.Value); }

		public static Byte? ToNullableByte(SqlBoolean p)  { return p.IsNull? null: ToNullableByte(p.Value); }
#endif
		public static Byte? ToNullableByte(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Byte)        return ToNullableByte((Byte)p);
			if (p is String)      return ToNullableByte((String)p);

			if (p is Char)        return ToNullableByte((Char)p);
			if (p is Boolean)     return ToNullableByte((Boolean)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlByte)     return ToNullableByte((SqlByte)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToByte(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Byte?));
		}

        #endregion

        #region UInt16?

		// Scalar Types.
		// 
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(UInt16 p)      { return p; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(String p)      { return p == null? null: (UInt16?)UInt16.Parse(p); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SByte p)       { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Int16 p)       { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Int32 p)       { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Int64 p)       { return      checked((UInt16?)p); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Byte p)        { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(UInt32 p)      { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(UInt64 p)      { return      checked((UInt16?)p); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Single p)      { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Double p)      { return      checked((UInt16?)p); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Decimal p)     { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Char p)        { return      checked((UInt16?)p); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Boolean p)     { return       (UInt16?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SByte? p)      { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Int16? p)      { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Int32? p)      { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Int64? p)      { return p.HasValue? checked((UInt16?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Byte? p)       { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(UInt32? p)     { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(UInt64? p)     { return p.HasValue? checked((UInt16?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Single? p)     { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Double? p)     { return p.HasValue? checked((UInt16?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Decimal? p)    { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Char? p)       { return p.HasValue? checked((UInt16?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(Boolean? p)    { return p.HasValue? (UInt16?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlString p)   { return p.IsNull? null: ToNullableUInt16(p.Value); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlByte p)     { return p.IsNull? null: ToNullableUInt16(p.Value); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlInt16 p)    { return p.IsNull? null: ToNullableUInt16(p.Value); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlInt32 p)    { return p.IsNull? null: ToNullableUInt16(p.Value); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlInt64 p)    { return p.IsNull? null: ToNullableUInt16(p.Value); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlSingle p)   { return p.IsNull? null: ToNullableUInt16(p.Value); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlDouble p)   { return p.IsNull? null: ToNullableUInt16(p.Value); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlDecimal p)  { return p.IsNull? null: ToNullableUInt16(p.Value); }
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlMoney p)    { return p.IsNull? null: ToNullableUInt16(p.Value); }

		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(SqlBoolean p)  { return p.IsNull? null: ToNullableUInt16(p.Value); }
#endif
		[CLSCompliant(false)]
		public static UInt16? ToNullableUInt16(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is UInt16)      return ToNullableUInt16((UInt16)p);
			if (p is String)      return ToNullableUInt16((String)p);

			if (p is Char)        return ToNullableUInt16((Char)p);
			if (p is Boolean)     return ToNullableUInt16((Boolean)p);

			if (p is IConvertible) return ((IConvertible)p).ToUInt16(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(UInt16?));
		}

        #endregion

        #region UInt32?

		// Scalar Types.
		// 
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(UInt32 p)      { return p; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(String p)      { return p == null? null: (UInt32?)UInt32.Parse(p); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SByte p)       { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Int16 p)       { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Int32 p)       { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Int64 p)       { return      checked((UInt32?)p); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Byte p)        { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(UInt16 p)      { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(UInt64 p)      { return      checked((UInt32?)p); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Single p)      { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Double p)      { return      checked((UInt32?)p); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Decimal p)     { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Char p)        { return      checked((UInt32?)p); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Boolean p)     { return       (UInt32?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SByte? p)      { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Int16? p)      { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Int32? p)      { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Int64? p)      { return p.HasValue? checked((UInt32?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Byte? p)       { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(UInt16? p)     { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(UInt64? p)     { return p.HasValue? checked((UInt32?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Single? p)     { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Double? p)     { return p.HasValue? checked((UInt32?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Decimal? p)    { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Char? p)       { return p.HasValue? checked((UInt32?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(Boolean? p)    { return p.HasValue? (UInt32?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlString p)   { return p.IsNull? null: ToNullableUInt32(p.Value); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlByte p)     { return p.IsNull? null: ToNullableUInt32(p.Value); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlInt16 p)    { return p.IsNull? null: ToNullableUInt32(p.Value); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlInt32 p)    { return p.IsNull? null: ToNullableUInt32(p.Value); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlInt64 p)    { return p.IsNull? null: ToNullableUInt32(p.Value); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlSingle p)   { return p.IsNull? null: ToNullableUInt32(p.Value); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlDouble p)   { return p.IsNull? null: ToNullableUInt32(p.Value); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlDecimal p)  { return p.IsNull? null: ToNullableUInt32(p.Value); }
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlMoney p)    { return p.IsNull? null: ToNullableUInt32(p.Value); }

		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(SqlBoolean p)  { return p.IsNull? null: ToNullableUInt32(p.Value); }
#endif
		[CLSCompliant(false)]
		public static UInt32? ToNullableUInt32(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is UInt32)      return ToNullableUInt32((UInt32)p);
			if (p is String)      return ToNullableUInt32((String)p);

			if (p is Char)        return ToNullableUInt32((Char)p);
			if (p is Boolean)     return ToNullableUInt32((Boolean)p);

			if (p is IConvertible) return ((IConvertible)p).ToUInt32(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(UInt32?));
		}

        #endregion

        #region UInt64?

		// Scalar Types.
		// 
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(UInt64 p)      { return p; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(String p)      { return p == null? null: (UInt64?)UInt64.Parse(p); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SByte p)       { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Int16 p)       { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Int32 p)       { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Int64 p)       { return checked((UInt64?)p); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Byte p)        { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(UInt16 p)      { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(UInt32 p)      { return checked((UInt64?)p); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Single p)      { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Double p)      { return checked((UInt64?)p); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Decimal p)     { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Char p)        { return checked((UInt64?)p); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Boolean p)     { return (UInt64?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SByte? p)      { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Int16? p)      { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Int32? p)      { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Int64? p)      { return p.HasValue? checked((UInt64?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Byte? p)       { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(UInt16? p)     { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(UInt32? p)     { return p.HasValue? checked((UInt64?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Single? p)     { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Double? p)     { return p.HasValue? checked((UInt64?)p.Value): null; }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Decimal? p)    { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Char? p)       { return p.HasValue? checked((UInt64?)p.Value): null; }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(Boolean? p)    { return p.HasValue? (UInt64?)(p.Value? 1: 0):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlString p)   { return p.IsNull? null: ToNullableUInt64(p.Value); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlByte p)     { return p.IsNull? null: ToNullableUInt64(p.Value); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlInt16 p)    { return p.IsNull? null: ToNullableUInt64(p.Value); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlInt32 p)    { return p.IsNull? null: ToNullableUInt64(p.Value); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlInt64 p)    { return p.IsNull? null: ToNullableUInt64(p.Value); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlSingle p)   { return p.IsNull? null: ToNullableUInt64(p.Value); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlDouble p)   { return p.IsNull? null: ToNullableUInt64(p.Value); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlDecimal p)  { return p.IsNull? null: ToNullableUInt64(p.Value); }
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlMoney p)    { return p.IsNull? null: ToNullableUInt64(p.Value); }

		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(SqlBoolean p)  { return p.IsNull? null: ToNullableUInt64(p.Value); }
#endif
		[CLSCompliant(false)]
		public static UInt64? ToNullableUInt64(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is UInt64)      return ToNullableUInt64((UInt64)p);
			if (p is String)      return ToNullableUInt64((String)p);

			if (p is Char)        return ToNullableUInt64((Char)p);
			if (p is Boolean)     return ToNullableUInt64((Boolean)p);

			if (p is IConvertible) return ((IConvertible)p).ToUInt64(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(UInt64?));
		}

        #endregion

        #region Char?

		// Scalar Types.
		// 
		public static Char? ToNullableChar(Char p)        { return p; }
		public static Char? ToNullableChar(String p)      
        { 
#if !(NET_1_1)
            Char result;
            if (Char.TryParse(p, out result))
                return result;
            return (Char)0;
#else
            return p == null? null: (Char?)Char.Parse(p); 
#endif
        }

		[CLSCompliant(false)]
		public static Char? ToNullableChar(SByte p)       { return checked((Char?)p); }
		public static Char? ToNullableChar(Int16 p)       { return checked((Char?)p); }
		public static Char? ToNullableChar(Int32 p)       { return checked((Char?)p); }
		public static Char? ToNullableChar(Int64 p)       { return checked((Char?)p); }

		public static Char? ToNullableChar(Byte p)        { return checked((Char?)p); }
		[CLSCompliant(false)]
		public static Char? ToNullableChar(UInt16 p)      { return checked((Char?)p); }
		[CLSCompliant(false)]
		public static Char? ToNullableChar(UInt32 p)      { return checked((Char?)p); }
		[CLSCompliant(false)]
		public static Char? ToNullableChar(UInt64 p)      { return checked((Char?)p); }

		public static Char? ToNullableChar(Single p)      { return checked((Char?)p); }
		public static Char? ToNullableChar(Double p)      { return checked((Char?)p); }

		public static Char? ToNullableChar(Decimal p)     { return checked((Char?)p); }
		public static Char? ToNullableChar(Boolean p)     { return (Char?)(p? 1: 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Char? ToNullableChar(SByte? p)      { return p.HasValue? checked((Char?)p.Value) : null; }
		public static Char? ToNullableChar(Int16? p)      { return p.HasValue? checked((Char?)p.Value) : null; }
		public static Char? ToNullableChar(Int32? p)      { return p.HasValue? checked((Char?)p.Value) : null; }
		public static Char? ToNullableChar(Int64? p)      { return p.HasValue? checked((Char?)p.Value) : null; }

		public static Char? ToNullableChar(Byte? p)       { return p.HasValue? checked((Char?)p.Value) : null; }
		[CLSCompliant(false)]
		public static Char? ToNullableChar(UInt16? p)     { return p.HasValue? checked((Char?)p.Value) : null; }
		[CLSCompliant(false)]
		public static Char? ToNullableChar(UInt32? p)     { return p.HasValue? checked((Char?)p.Value) : null; }
		[CLSCompliant(false)]
		public static Char? ToNullableChar(UInt64? p)     { return p.HasValue? checked((Char?)p.Value) : null; }

		public static Char? ToNullableChar(Single? p)     { return p.HasValue? checked((Char?)p.Value) : null; }
		public static Char? ToNullableChar(Double? p)     { return p.HasValue? checked((Char?)p.Value) : null; }

		public static Char? ToNullableChar(Decimal? p)    { return p.HasValue? checked((Char?)p.Value) : null; }
		public static Char? ToNullableChar(Boolean? p)    { return p.HasValue? (Char?)(p.Value? 1: 0)  : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Char? ToNullableChar(SqlString p)   { return p.IsNull? null: ToNullableChar(p.Value); }

		public static Char? ToNullableChar(SqlByte p)     { return p.IsNull? null: ToNullableChar(p.Value); }
		public static Char? ToNullableChar(SqlInt16 p)    { return p.IsNull? null: ToNullableChar(p.Value); }
		public static Char? ToNullableChar(SqlInt32 p)    { return p.IsNull? null: ToNullableChar(p.Value); }
		public static Char? ToNullableChar(SqlInt64 p)    { return p.IsNull? null: ToNullableChar(p.Value); }

		public static Char? ToNullableChar(SqlSingle p)   { return p.IsNull? null: ToNullableChar(p.Value); }
		public static Char? ToNullableChar(SqlDouble p)   { return p.IsNull? null: ToNullableChar(p.Value); }
		public static Char? ToNullableChar(SqlDecimal p)  { return p.IsNull? null: ToNullableChar(p.Value); }
		public static Char? ToNullableChar(SqlMoney p)    { return p.IsNull? null: ToNullableChar(p.Value); }

		public static Char? ToNullableChar(SqlBoolean p)  { return p.IsNull? null: ToNullableChar(p.Value); }
#endif
		public static Char? ToNullableChar(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Char)        return ToNullableChar((Char)p);
			if (p is String)      return ToNullableChar((String)p);

			if (p is Boolean)     return ToNullableChar((Boolean)p);

			if (p is IConvertible) return ((IConvertible)p).ToChar(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Char?));
		}

        #endregion

        #region Single?

		// Scalar Types.
		// 
		public static Single? ToNullableSingle(Single p)      { return p; }
		public static Single? ToNullableSingle(String p)      { return p == null? null: (Single?)Single.Parse(p); }

		[CLSCompliant(false)]
		public static Single? ToNullableSingle(SByte p)       { return checked((Single?)p); }
		public static Single? ToNullableSingle(Int16 p)       { return checked((Single?)p); }
		public static Single? ToNullableSingle(Int32 p)       { return checked((Single?)p); }
		public static Single? ToNullableSingle(Int64 p)       { return checked((Single?)p); }

		public static Single? ToNullableSingle(Byte p)        { return checked((Single?)p); }
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(UInt16 p)      { return checked((Single?)p); }
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(UInt32 p)      { return checked((Single?)p); }
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(UInt64 p)      { return checked((Single?)p); }

		public static Single? ToNullableSingle(Double p)      { return checked((Single?)p); }

		public static Single? ToNullableSingle(Decimal p)     { return checked((Single?)p); }
		public static Single? ToNullableSingle(Char p)        { return checked((Single?)p); }
		public static Single? ToNullableSingle(Boolean p)     { return p? 1.0f: 0.0f; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(SByte? p)      { return p.HasValue? checked((Single?)p.Value): null; }
		public static Single? ToNullableSingle(Int16? p)      { return p.HasValue? checked((Single?)p.Value): null; }
		public static Single? ToNullableSingle(Int32? p)      { return p.HasValue? checked((Single?)p.Value): null; }
		public static Single? ToNullableSingle(Int64? p)      { return p.HasValue? checked((Single?)p.Value): null; }

		public static Single? ToNullableSingle(Byte? p)       { return p.HasValue? checked((Single?)p.Value): null; }
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(UInt16? p)     { return p.HasValue? checked((Single?)p.Value): null; }
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(UInt32? p)     { return p.HasValue? checked((Single?)p.Value): null; }
		[CLSCompliant(false)]
		public static Single? ToNullableSingle(UInt64? p)     { return p.HasValue? checked((Single?)p.Value): null; }

		public static Single? ToNullableSingle(Double? p)     { return p.HasValue? checked((Single?)p.Value): null; }

		public static Single? ToNullableSingle(Decimal? p)    { return p.HasValue? checked((Single?)p.Value): null; }
		public static Single? ToNullableSingle(Char? p)       { return p.HasValue? checked((Single?)p.Value): null; }
		public static Single? ToNullableSingle(Boolean? p)    { return p.HasValue? (Single?)(p.Value? 1.0f: 0.0f):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Single? ToNullableSingle(SqlSingle p)   { return p.IsNull? null:         (Single?)p.Value;  }
		public static Single? ToNullableSingle(SqlString p)   { return p.IsNull? null: ToNullableSingle(p.Value); }

		public static Single? ToNullableSingle(SqlByte p)     { return p.IsNull? null: ToNullableSingle(p.Value); }
		public static Single? ToNullableSingle(SqlInt16 p)    { return p.IsNull? null: ToNullableSingle(p.Value); }
		public static Single? ToNullableSingle(SqlInt32 p)    { return p.IsNull? null: ToNullableSingle(p.Value); }
		public static Single? ToNullableSingle(SqlInt64 p)    { return p.IsNull? null: ToNullableSingle(p.Value); }

		public static Single? ToNullableSingle(SqlDouble p)   { return p.IsNull? null: ToNullableSingle(p.Value); }
		public static Single? ToNullableSingle(SqlDecimal p)  { return p.IsNull? null: ToNullableSingle(p.Value); }
		public static Single? ToNullableSingle(SqlMoney p)    { return p.IsNull? null: ToNullableSingle(p.Value); }

		public static Single? ToNullableSingle(SqlBoolean p)  { return p.IsNull? null: ToNullableSingle(p.Value); }
#endif
		public static Single? ToNullableSingle(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Single)      return ToNullableSingle((Single)p);
			if (p is String)      return ToNullableSingle((String)p);

			if (p is Char)        return ToNullableSingle((Char)p);
			if (p is Boolean)     return ToNullableSingle((Boolean)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlSingle)   return ToNullableSingle((SqlSingle)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToSingle(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Single?));
		}

        #endregion

        #region Double?

		// Scalar Types.
		// 
		public static Double? ToNullableDouble(Double p)      { return p; }
		public static Double? ToNullableDouble(String p)      { return p == null? null: (Double?)Double.Parse(p); }

		[CLSCompliant(false)]
		public static Double? ToNullableDouble(SByte p)       { return checked((Double?)p); }
		public static Double? ToNullableDouble(Int16 p)       { return checked((Double?)p); }
		public static Double? ToNullableDouble(Int32 p)       { return checked((Double?)p); }
		public static Double? ToNullableDouble(Int64 p)       { return checked((Double?)p); }

		public static Double? ToNullableDouble(Byte p)        { return checked((Double?)p); }
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(UInt16 p)      { return checked((Double?)p); }
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(UInt32 p)      { return checked((Double?)p); }
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(UInt64 p)      { return checked((Double?)p); }

		public static Double? ToNullableDouble(Single p)      { return checked((Double?)p); }

		public static Double? ToNullableDouble(Decimal p)     { return checked((Double?)p); }
		public static Double? ToNullableDouble(Char p)        { return checked((Double?)p); }
		public static Double? ToNullableDouble(Boolean p)     { return p? 1.0: 0.0; }
		public static Double? ToNullableDouble(DateTime p)    { return (p - DateTime.MinValue).TotalDays; }
		public static Double? ToNullableDouble(TimeSpan p)    { return p.TotalDays; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(SByte? p)      { return p.HasValue? checked((Double?)p.Value): null; }
		public static Double? ToNullableDouble(Int16? p)      { return p.HasValue? checked((Double?)p.Value): null; }
		public static Double? ToNullableDouble(Int32? p)      { return p.HasValue? checked((Double?)p.Value): null; }
		public static Double? ToNullableDouble(Int64? p)      { return p.HasValue? checked((Double?)p.Value): null; }

		public static Double? ToNullableDouble(Byte? p)       { return p.HasValue? checked((Double?)p.Value): null; }
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(UInt16? p)     { return p.HasValue? checked((Double?)p.Value): null; }
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(UInt32? p)     { return p.HasValue? checked((Double?)p.Value): null; }
		[CLSCompliant(false)]
		public static Double? ToNullableDouble(UInt64? p)     { return p.HasValue? checked((Double?)p.Value): null; }

		public static Double? ToNullableDouble(Single? p)     { return p.HasValue? checked((Double?)p.Value): null; }

		public static Double? ToNullableDouble(Decimal? p)    { return p.HasValue? checked((Double?)p.Value): null; }
		public static Double? ToNullableDouble(Char? p)       { return p.HasValue? checked((Double?)p.Value): null; }
		public static Double? ToNullableDouble(Boolean? p)    { return p.HasValue? (Double?)(p.Value? 1.0: 0.0):  null; }
		public static Double? ToNullableDouble(DateTime? p)   { return p.HasValue? (Double?)(p.Value - DateTime.MinValue).TotalDays: null; }
		public static Double? ToNullableDouble(TimeSpan? p)   { return p.HasValue? (Double?)p.Value.TotalDays: null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Double? ToNullableDouble(SqlDouble p)   { return p.IsNull? null:         (Double?)p.Value;  }
		public static Double? ToNullableDouble(SqlString p)   { return p.IsNull? null: ToNullableDouble(p.Value); }

		public static Double? ToNullableDouble(SqlByte p)     { return p.IsNull? null: ToNullableDouble(p.Value); }
		public static Double? ToNullableDouble(SqlInt16 p)    { return p.IsNull? null: ToNullableDouble(p.Value); }
		public static Double? ToNullableDouble(SqlInt32 p)    { return p.IsNull? null: ToNullableDouble(p.Value); }
		public static Double? ToNullableDouble(SqlInt64 p)    { return p.IsNull? null: ToNullableDouble(p.Value); }

		public static Double? ToNullableDouble(SqlSingle p)   { return p.IsNull? null: ToNullableDouble(p.Value); }
		public static Double? ToNullableDouble(SqlDecimal p)  { return p.IsNull? null: ToNullableDouble(p.Value); }
		public static Double? ToNullableDouble(SqlMoney p)    { return p.IsNull? null: ToNullableDouble(p.Value); }

		public static Double? ToNullableDouble(SqlBoolean p)  { return p.IsNull? null: ToNullableDouble(p.Value); }
		public static Double? ToNullableDouble(SqlDateTime p) { return p.IsNull? null: (Double?)(p.Value - DateTime.MinValue).TotalDays; }
#endif
		public static Double? ToNullableDouble(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Double)      return ToNullableDouble((Double)p);
			if (p is String)      return ToNullableDouble((String)p);

			if (p is Char)        return ToNullableDouble((Char)p);
			if (p is Boolean)     return ToNullableDouble((Boolean)p);
			if (p is DateTime)    return ToNullableDouble((DateTime)p);
			if (p is TimeSpan)    return ToNullableDouble((TimeSpan)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlDouble)   return ToNullableDouble((SqlDouble)p);
			if (p is SqlDateTime) return ToNullableDouble((SqlDateTime)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToDouble(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Double?));
		}

        #endregion

        #region Boolean?

		// Scalar Types.
		// 
		public static Boolean? ToNullableBoolean(Boolean p)     { return p; }
		public static Boolean? ToNullableBoolean(String p)      { return p == null? null: (Boolean?)Boolean.Parse(p); }

		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(SByte p)       { return ToBoolean(p); }
		public static Boolean? ToNullableBoolean(Int16 p)       { return ToBoolean(p); }
		public static Boolean? ToNullableBoolean(Int32 p)       { return ToBoolean(p); }
		public static Boolean? ToNullableBoolean(Int64 p)       { return ToBoolean(p); }

		public static Boolean? ToNullableBoolean(Byte p)        { return ToBoolean(p); }
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(UInt16 p)      { return ToBoolean(p); }
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(UInt32 p)      { return ToBoolean(p); }
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(UInt64 p)      { return ToBoolean(p); }

		public static Boolean? ToNullableBoolean(Single p)      { return ToBoolean(p); }
		public static Boolean? ToNullableBoolean(Double p)      { return ToBoolean(p); }

		public static Boolean? ToNullableBoolean(Decimal p)     { return ToBoolean(p); }
		public static Boolean? ToNullableBoolean(Char p)        { return ToBoolean(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(SByte? p)      { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		public static Boolean? ToNullableBoolean(Int16? p)      { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		public static Boolean? ToNullableBoolean(Int32? p)      { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		public static Boolean? ToNullableBoolean(Int64? p)      { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }

		public static Boolean? ToNullableBoolean(Byte? p)       { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(UInt16? p)     { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(UInt32? p)     { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		[CLSCompliant(false)]
		public static Boolean? ToNullableBoolean(UInt64? p)     { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }

		public static Boolean? ToNullableBoolean(Single? p)     { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		public static Boolean? ToNullableBoolean(Double? p)     { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }

		public static Boolean? ToNullableBoolean(Decimal? p)    { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }
		public static Boolean? ToNullableBoolean(Char? p)       { return p.HasValue? (Boolean?)ToBoolean(p.Value): null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Boolean? ToNullableBoolean(SqlBoolean p)  { return p.IsNull? null: (Boolean?)          p.Value;  }
		public static Boolean? ToNullableBoolean(SqlString p)   { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }

		public static Boolean? ToNullableBoolean(SqlByte p)     { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
		public static Boolean? ToNullableBoolean(SqlInt16 p)    { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
		public static Boolean? ToNullableBoolean(SqlInt32 p)    { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
		public static Boolean? ToNullableBoolean(SqlInt64 p)    { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }

		public static Boolean? ToNullableBoolean(SqlSingle p)   { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
		public static Boolean? ToNullableBoolean(SqlDouble p)   { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
		public static Boolean? ToNullableBoolean(SqlDecimal p)  { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
		public static Boolean? ToNullableBoolean(SqlMoney p)    { return p.IsNull? null: (Boolean?)ToBoolean(p.Value); }
#endif

		public static Boolean? ToNullableBoolean(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Boolean)     return ToNullableBoolean((Boolean)p);
			if (p is String)      return ToNullableBoolean((String)p);

			if (p is Char)        return ToNullableBoolean((Char)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlBoolean)  return ToNullableBoolean((SqlBoolean)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToBoolean(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Boolean?));
		}

        #endregion

        #region Decimal?

		// Scalar Types.
		// 
		public static Decimal? ToNullableDecimal(Decimal p)     { return p; }
		public static Decimal? ToNullableDecimal(String p)      { return p == null? null: (Decimal?)Decimal.Parse(p); }

		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(SByte p)       { return checked((Decimal?)p); }
		public static Decimal? ToNullableDecimal(Int16 p)       { return checked((Decimal?)p); }
		public static Decimal? ToNullableDecimal(Int32 p)       { return checked((Decimal?)p); }
		public static Decimal? ToNullableDecimal(Int64 p)       { return checked((Decimal?)p); }

		public static Decimal? ToNullableDecimal(Byte p)        { return checked((Decimal?)p); }
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(UInt16 p)      { return checked((Decimal?)p); }
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(UInt32 p)      { return checked((Decimal?)p); }
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(UInt64 p)      { return checked((Decimal?)p); }

		public static Decimal? ToNullableDecimal(Single p)      { return checked((Decimal?)p); }
		public static Decimal? ToNullableDecimal(Double p)      { return checked((Decimal?)p); }

		public static Decimal? ToNullableDecimal(Char p)        { return checked((Decimal?)p); }
		public static Decimal? ToNullableDecimal(Boolean p)     { return p? 1.0m: 0.0m; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(SByte? p)      { return p.HasValue? checked((Decimal?)p.Value): null; }
		public static Decimal? ToNullableDecimal(Int16? p)      { return p.HasValue? checked((Decimal?)p.Value): null; }
		public static Decimal? ToNullableDecimal(Int32? p)      { return p.HasValue? checked((Decimal?)p.Value): null; }
		public static Decimal? ToNullableDecimal(Int64? p)      { return p.HasValue? checked((Decimal?)p.Value): null; }

		public static Decimal? ToNullableDecimal(Byte? p)       { return p.HasValue? checked((Decimal?)p.Value): null; }
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(UInt16? p)     { return p.HasValue? checked((Decimal?)p.Value): null; }
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(UInt32? p)     { return p.HasValue? checked((Decimal?)p.Value): null; }
		[CLSCompliant(false)]
		public static Decimal? ToNullableDecimal(UInt64? p)     { return p.HasValue? checked((Decimal?)p.Value): null; }

		public static Decimal? ToNullableDecimal(Single? p)     { return p.HasValue? checked((Decimal?)p.Value): null; }
		public static Decimal? ToNullableDecimal(Double? p)     { return p.HasValue? checked((Decimal?)p.Value): null; }

		public static Decimal? ToNullableDecimal(Char? p)       { return p.HasValue? checked((Decimal?)p.Value): null; }
		public static Decimal? ToNullableDecimal(Boolean? p)    { return p.HasValue? (Decimal?)(p.Value? 1.0m: 0.0m):  null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static Decimal? ToNullableDecimal(SqlDecimal p)  { return p.IsNull? null:         (Decimal?)p.Value;  }
		public static Decimal? ToNullableDecimal(SqlMoney p)    { return p.IsNull? null:         (Decimal?)p.Value;  }
		public static Decimal? ToNullableDecimal(SqlString p)   { return p.IsNull? null: ToNullableDecimal(p.Value); }

		public static Decimal? ToNullableDecimal(SqlByte p)     { return p.IsNull? null: ToNullableDecimal(p.Value); }
		public static Decimal? ToNullableDecimal(SqlInt16 p)    { return p.IsNull? null: ToNullableDecimal(p.Value); }
		public static Decimal? ToNullableDecimal(SqlInt32 p)    { return p.IsNull? null: ToNullableDecimal(p.Value); }
		public static Decimal? ToNullableDecimal(SqlInt64 p)    { return p.IsNull? null: ToNullableDecimal(p.Value); }

		public static Decimal? ToNullableDecimal(SqlSingle p)   { return p.IsNull? null: ToNullableDecimal(p.Value); }
		public static Decimal? ToNullableDecimal(SqlDouble p)   { return p.IsNull? null: ToNullableDecimal(p.Value); }

		public static Decimal? ToNullableDecimal(SqlBoolean p)  { return p.IsNull? null: ToNullableDecimal(p.Value); }
#endif
		public static Decimal? ToNullableDecimal(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
            if (p is double && Double.IsNaN((double)p)) return null;
            if (p is Decimal) return ToNullableDecimal((Decimal)p);
			if (p is String)      return ToNullableDecimal((String)p);

			if (p is Char)        return ToNullableDecimal((Char)p);
			if (p is Boolean)     return ToNullableDecimal((Boolean)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlDecimal)  return ToNullableDecimal((SqlDecimal)p);
			if (p is SqlMoney)    return ToNullableDecimal((SqlMoney)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToDecimal(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(Decimal?));
		}

        #endregion

        #region DateTime?

		// Scalar Types.
		// 
		public static DateTime? ToNullableDateTime(DateTime p)    { return p; }
		public static DateTime? ToNullableDateTime(String p)      { return p == null? null: (DateTime?)DateTime.Parse(p); }

		public static DateTime? ToNullableDateTime(TimeSpan p)    { return DateTime.MinValue + p; }
		public static DateTime? ToNullableDateTime(Int64 p)       { return DateTime.MinValue + TimeSpan.FromTicks(p); }
		public static DateTime? ToNullableDateTime(Double p)      { return DateTime.MinValue + TimeSpan.FromDays(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static DateTime? ToNullableDateTime(TimeSpan? p)   { return p.HasValue? DateTime.MinValue +                           p.Value:  (DateTime?)null; }
		public static DateTime? ToNullableDateTime(Int64? p)      { return p.HasValue? DateTime.MinValue +        TimeSpan.FromTicks(p.Value): (DateTime?)null; }
		public static DateTime? ToNullableDateTime(Double? p)     { return p.HasValue? DateTime.MinValue + TimeSpan.FromDays(p.Value): (DateTime?)null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static DateTime? ToNullableDateTime(SqlDateTime p) { return p.IsNull? (DateTime?)null:                                               p.Value;  }
		public static DateTime? ToNullableDateTime(SqlString p)   { return p.IsNull? (DateTime?)null:                                    ToDateTime(p.Value); }
		public static DateTime? ToNullableDateTime(SqlInt64 p)    { return p.IsNull? (DateTime?)null: DateTime.MinValue +        TimeSpan.FromTicks(p.Value); }
		public static DateTime? ToNullableDateTime(SqlDouble p)   { return p.IsNull? (DateTime?)null: DateTime.MinValue + TimeSpan.FromDays(p.Value); }
#endif
		public static DateTime? ToNullableDateTime(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is DateTime)    return ToNullableDateTime((DateTime)p);
			if (p is String)      return ToNullableDateTime((String)p);

			if (p is TimeSpan)    return ToNullableDateTime((TimeSpan)p);
			if (p is Int64)       return ToNullableDateTime((Int64)p);
			if (p is Double)      return ToNullableDateTime((Double)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlDateTime) return ToNullableDateTime((SqlDateTime)p);
			if (p is SqlString)   return ToNullableDateTime((SqlString)p);
			if (p is SqlInt64)    return ToNullableDateTime((SqlInt64)p);
			if (p is SqlDouble)   return ToNullableDateTime((SqlDouble)p);
#endif
			if (p is IConvertible) return ((IConvertible)p).ToDateTime(null);
			
			throw CreateInvalidCastException(p.GetType(), typeof(DateTime?));
		}

        #endregion

        #region TimeSpan?

		// Scalar Types.
		// 
		public static TimeSpan? ToNullableTimeSpan(TimeSpan p)    { return p; }
		public static TimeSpan? ToNullableTimeSpan(String p)      { return p == null? null: (TimeSpan?)TimeSpan.Parse(p); }
		public static TimeSpan? ToNullableTimeSpan(DateTime p)    { return p - DateTime.MinValue; }
		public static TimeSpan? ToNullableTimeSpan(Int64 p)       { return TimeSpan.FromTicks(p); }
		public static TimeSpan? ToNullableTimeSpan(Double p)      { return TimeSpan.FromDays(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static TimeSpan? ToNullableTimeSpan(DateTime? p)   { return p.HasValue? p.Value - DateTime.MinValue: (TimeSpan?)null; }
		public static TimeSpan? ToNullableTimeSpan(Int64? p)      { return p.HasValue? TimeSpan.FromTicks(p.Value): (TimeSpan?)null; }
		public static TimeSpan? ToNullableTimeSpan(Double? p)     { return p.HasValue? TimeSpan.FromDays(p.Value): (TimeSpan?)null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
		public static TimeSpan? ToNullableTimeSpan(SqlString p)   { return p.IsNull? (TimeSpan?)null: TimeSpan.Parse(p.Value);     }
		public static TimeSpan? ToNullableTimeSpan(SqlDateTime p) { return p.IsNull? (TimeSpan?)null: p.Value - DateTime.MinValue; }
		public static TimeSpan? ToNullableTimeSpan(SqlInt64 p)    { return p.IsNull? (TimeSpan?)null: TimeSpan.FromTicks(p.Value); }
		public static TimeSpan? ToNullableTimeSpan(SqlDouble p)   { return p.IsNull? (TimeSpan?)null: TimeSpan.FromDays(p.Value); }
#endif
		public static TimeSpan? ToNullableTimeSpan(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is TimeSpan)    return ToNullableTimeSpan((TimeSpan)p);
			if (p is String)      return ToNullableTimeSpan((String)p);
			if (p is DateTime)    return ToNullableTimeSpan((DateTime)p);
			if (p is Int64)       return ToNullableTimeSpan((Int64)p);
			if (p is Double)      return ToNullableTimeSpan((Double)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlString)   return ToNullableTimeSpan((SqlString)p);
			if (p is SqlDateTime) return ToNullableTimeSpan((SqlDateTime)p);
			if (p is SqlInt64)    return ToNullableTimeSpan((SqlInt64)p);
			if (p is SqlDouble)   return ToNullableTimeSpan((SqlDouble)p);
#endif
			throw CreateInvalidCastException(p.GetType(), typeof(TimeSpan?));
		}

        #endregion

        #region Guid?

		// Scalar Types.
		// 
		public static Guid? ToNullableGuid(Guid p)        { return p; }
		public static Guid? ToNullableGuid(String p)      { return p == null? null: (Guid?)new Guid(p); }

		// SqlTypes.
#if! SILVERLIGHT
		public static Guid? ToNullableGuid(SqlGuid p)     { return p.IsNull? null: (Guid?)p.Value;             }
		public static Guid? ToNullableGuid(SqlString p)   { return p.IsNull? null: (Guid?)new Guid(p.Value);   }
		public static Guid? ToNullableGuid(SqlBinary p)   { return p.IsNull? null: (Guid?)p.ToSqlGuid().Value; }
#endif
		// Other Types.
		// 
		public static Guid? ToNullableGuid(Type p)        { return p == null? null: (Guid?)p.GUID; }
		public static Guid? ToNullableGuid(Byte[] p)      { return p == null? null: (Guid?)new Guid(p); }

		public static Guid? ToNullableGuid(object p)
		{
			if (p == null || p is DBNull) return null;

			// Scalar Types.
			//
			if (p is Guid)        return ToNullableGuid((Guid)p);
			if (p is String)      return ToNullableGuid((String)p);

			// SqlTypes.
#if! SILVERLIGHT
			if (p is SqlGuid)     return ToNullableGuid((SqlGuid)p);
			if (p is SqlString)   return ToNullableGuid((SqlString)p);
			if (p is SqlBinary)   return ToNullableGuid((SqlBinary)p);
#endif
			// Other Types.
			//
			if (p is Type)        return ToNullableGuid((Type)p);
			if (p is Byte[])      return ToNullableGuid((Byte[])p);

			throw CreateInvalidCastException(p.GetType(), typeof(Guid?));
		}

        #endregion

        #endregion
#endif

        #region SqlTypes

        #region SqlString
#if! SILVERLIGHT
        // Scalar Types.
        public static SqlString ToSqlString(String p) { return p == null ? SqlString.Null : p; }

        [CLSCompliant(false)]
        public static SqlString ToSqlString(SByte p) { return p.ToString(); }
        public static SqlString ToSqlString(Int16 p) { return p.ToString(); }
        public static SqlString ToSqlString(Int32 p) { return p.ToString(); }
        public static SqlString ToSqlString(Int64 p) { return p.ToString(); }

        public static SqlString ToSqlString(Byte p) { return p.ToString(); }
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt16 p) { return p.ToString(); }
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt32 p) { return p.ToString(); }
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt64 p) { return p.ToString(); }

        public static SqlString ToSqlString(Single p) { return p.ToString(); }
        public static SqlString ToSqlString(Double p) { return p.ToString(); }

        public static SqlString ToSqlString(Boolean p) { return p.ToString(); }
        public static SqlString ToSqlString(Decimal p) { return p.ToString(); }
        public static SqlString ToSqlString(Char p) { return p.ToString(); }
        public static SqlString ToSqlString(TimeSpan p) { return p.ToString(); }
        public static SqlString ToSqlString(DateTime p) { return p.ToString(); }
        public static SqlString ToSqlString(Guid p) { return p.ToString(); }
        public static SqlString ToSqlString(Char[] p) { return new String(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		[CLSCompliant(false)]
		public static SqlString ToSqlString(SByte? p)      { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Int16? p)      { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Int32? p)      { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Int64? p)      { return p.HasValue? p.ToString(): SqlString.Null; }

		public static SqlString ToSqlString(Byte? p)       { return p.HasValue? p.ToString(): SqlString.Null; }
		[CLSCompliant(false)]
		public static SqlString ToSqlString(UInt16? p)     { return p.HasValue? p.ToString(): SqlString.Null; }
		[CLSCompliant(false)]
		public static SqlString ToSqlString(UInt32? p)     { return p.HasValue? p.ToString(): SqlString.Null; }
		[CLSCompliant(false)]
		public static SqlString ToSqlString(UInt64? p)     { return p.HasValue? p.ToString(): SqlString.Null; }

		public static SqlString ToSqlString(Single? p)     { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Double? p)     { return p.HasValue? p.ToString(): SqlString.Null; }

		public static SqlString ToSqlString(Boolean? p)    { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Decimal? p)    { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Char? p)       { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(TimeSpan? p)   { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(DateTime? p)   { return p.HasValue? p.ToString(): SqlString.Null; }
		public static SqlString ToSqlString(Guid? p)       { return p.HasValue? p.ToString(): SqlString.Null; }

#endif
        // SqlTypes.
        // 

        public static SqlString ToSqlString(SqlByte p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlInt16 p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlInt32 p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlInt64 p) { return p.ToSqlString(); }

        public static SqlString ToSqlString(SqlSingle p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlDouble p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlDecimal p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlMoney p) { return p.ToSqlString(); }

        public static SqlString ToSqlString(SqlBoolean p) { return p.ToSqlString(); }
#if !(NET_1_1)
        public static SqlString ToSqlString(SqlChars p)    { return p.ToSqlString(); }
		public static SqlString ToSqlString(SqlXml p)      { return p.IsNull? SqlString.Null: p.Value; }
#endif
        public static SqlString ToSqlString(SqlGuid p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlDateTime p) { return p.ToSqlString(); }
        public static SqlString ToSqlString(SqlBinary p) { return p.IsNull ? SqlString.Null : p.ToString(); }

        public static SqlString ToSqlString(Type p) { return p == null ? SqlString.Null : p.FullName; }
        public static SqlString ToSqlString(XmlDocument p) { return p == null ? SqlString.Null : p.InnerXml; }

        public static SqlString ToSqlString(object p)
        {
            if (p == null || p is DBNull) return SqlString.Null;

            if (p is SqlString) return (SqlString)p;

            // Scalar Types.
            //
            if (p is String) return ToSqlString((String)p);

            if (p is Char) return ToSqlString((Char)p);
            if (p is TimeSpan) return ToSqlString((TimeSpan)p);
            if (p is DateTime) return ToSqlString((DateTime)p);
            if (p is Guid) return ToSqlString((Guid)p);
            if (p is Char[]) return ToSqlString((Char[])p);

            // SqlTypes.
            //
#if !(NET_1_1)
            if (p is SqlChars)    return ToSqlString((SqlChars)p);
			if (p is SqlXml)      return ToSqlString((SqlXml)p);
#endif
            if (p is SqlGuid) return ToSqlString((SqlGuid)p);
            if (p is SqlDateTime) return ToSqlString((SqlDateTime)p);
            if (p is SqlBinary) return ToSqlString((SqlBinary)p);

            if (p is Type) return ToSqlString((Type)p);
            if (p is XmlDocument) return ToSqlString((XmlDocument)p);

            return ToString(p);
        }
#endif
        #endregion

        #region SqlByte
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlByte ToSqlByte(Byte p) { return p; }
        public static SqlByte ToSqlByte(String p) { return p == null ? SqlByte.Null : SqlByte.Parse(p); }

        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(SByte p) { return checked((Byte)p); }
        public static SqlByte ToSqlByte(Int16 p) { return checked((Byte)p); }
        public static SqlByte ToSqlByte(Int32 p) { return checked((Byte)p); }
        public static SqlByte ToSqlByte(Int64 p) { return checked((Byte)p); }

        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt16 p) { return checked((Byte)p); }
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt32 p) { return checked((Byte)p); }
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt64 p) { return checked((Byte)p); }

        public static SqlByte ToSqlByte(Single p) { return checked((Byte)p); }
        public static SqlByte ToSqlByte(Double p) { return checked((Byte)p); }

        public static SqlByte ToSqlByte(Decimal p) { return checked((Byte)p); }
        public static SqlByte ToSqlByte(Char p) { return checked((Byte)p); }
        public static SqlByte ToSqlByte(Boolean p) { return (Byte)(p ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlByte ToSqlByte(Byte? p)       { return p.HasValue?        p.Value:  SqlByte.Null; }
		[CLSCompliant(false)]
		public static SqlByte ToSqlByte(SByte? p)      { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		public static SqlByte ToSqlByte(Int16? p)      { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		public static SqlByte ToSqlByte(Int32? p)      { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		public static SqlByte ToSqlByte(Int64? p)      { return p.HasValue? ToByte(p.Value): SqlByte.Null; }

		[CLSCompliant(false)]
		public static SqlByte ToSqlByte(UInt16? p)     { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		[CLSCompliant(false)]
		public static SqlByte ToSqlByte(UInt32? p)     { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		[CLSCompliant(false)]
		public static SqlByte ToSqlByte(UInt64? p)     { return p.HasValue? ToByte(p.Value): SqlByte.Null; }

		public static SqlByte ToSqlByte(Single? p)     { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		public static SqlByte ToSqlByte(Double? p)     { return p.HasValue? ToByte(p.Value): SqlByte.Null; }

		public static SqlByte ToSqlByte(Boolean? p)    { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		public static SqlByte ToSqlByte(Decimal? p)    { return p.HasValue? ToByte(p.Value): SqlByte.Null; }
		public static SqlByte ToSqlByte(Char? p)       { return p.HasValue? ToByte(p.Value): SqlByte.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlByte ToSqlByte(SqlString p) { return p.ToSqlByte(); }

        public static SqlByte ToSqlByte(SqlInt16 p) { return p.ToSqlByte(); }
        public static SqlByte ToSqlByte(SqlInt32 p) { return p.ToSqlByte(); }
        public static SqlByte ToSqlByte(SqlInt64 p) { return p.ToSqlByte(); }

        public static SqlByte ToSqlByte(SqlSingle p) { return p.ToSqlByte(); }
        public static SqlByte ToSqlByte(SqlDouble p) { return p.ToSqlByte(); }
        public static SqlByte ToSqlByte(SqlDecimal p) { return p.ToSqlByte(); }
        public static SqlByte ToSqlByte(SqlMoney p) { return p.ToSqlByte(); }

        public static SqlByte ToSqlByte(SqlBoolean p) { return p.ToSqlByte(); }
        public static SqlByte ToSqlByte(SqlDateTime p) { return p.IsNull ? SqlByte.Null : ToByte(p.Value); }

        public static SqlByte ToSqlByte(object p)
        {
            if (p == null || p is DBNull) return SqlByte.Null;

            if (p is SqlByte) return (SqlByte)p;

            // Scalar Types.
            //
            if (p is Byte) return ToSqlByte((Byte)p);
            if (p is String) return ToSqlByte((String)p);

            if (p is Char) return ToSqlByte((Char)p);
            if (p is Boolean) return ToSqlByte((Boolean)p);

            // SqlTypes.
            //
            if (p is SqlDateTime) return ToSqlByte((SqlDateTime)p);

            return ToByte(p);
        }
#endif
        #endregion

        #region SqlInt16
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlInt16 ToSqlInt16(Int16 p) { return p; }
        public static SqlInt16 ToSqlInt16(String p) { return p == null ? SqlInt16.Null : SqlInt16.Parse(p); }

        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(SByte p) { return checked((Int16)p); }
        public static SqlInt16 ToSqlInt16(Int32 p) { return checked((Int16)p); }
        public static SqlInt16 ToSqlInt16(Int64 p) { return checked((Int16)p); }

        public static SqlInt16 ToSqlInt16(Byte p) { return checked((Int16)p); }
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt16 p) { return checked((Int16)p); }
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt32 p) { return checked((Int16)p); }
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt64 p) { return checked((Int16)p); }

        public static SqlInt16 ToSqlInt16(Single p) { return checked((Int16)p); }
        public static SqlInt16 ToSqlInt16(Double p) { return checked((Int16)p); }

        public static SqlInt16 ToSqlInt16(Decimal p) { return checked((Int16)p); }
        public static SqlInt16 ToSqlInt16(Char p) { return checked((Int16)p); }
        public static SqlInt16 ToSqlInt16(Boolean p) { return (Int16)(p ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlInt16 ToSqlInt16(Int16? p)      { return p.HasValue?         p.Value:  SqlInt16.Null; }
		[CLSCompliant(false)]
		public static SqlInt16 ToSqlInt16(SByte? p)      { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		public static SqlInt16 ToSqlInt16(Int32? p)      { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		public static SqlInt16 ToSqlInt16(Int64? p)      { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }

		public static SqlInt16 ToSqlInt16(Byte? p)       { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		[CLSCompliant(false)]
		public static SqlInt16 ToSqlInt16(UInt16? p)     { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		[CLSCompliant(false)]
		public static SqlInt16 ToSqlInt16(UInt32? p)     { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		[CLSCompliant(false)]
		public static SqlInt16 ToSqlInt16(UInt64? p)     { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }

		public static SqlInt16 ToSqlInt16(Single? p)     { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		public static SqlInt16 ToSqlInt16(Double? p)     { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }

		public static SqlInt16 ToSqlInt16(Boolean? p)    { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		public static SqlInt16 ToSqlInt16(Decimal? p)    { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }
		public static SqlInt16 ToSqlInt16(Char? p)       { return p.HasValue? ToInt16(p.Value): SqlInt16.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlInt16 ToSqlInt16(SqlString p) { return p.ToSqlInt16(); }

        public static SqlInt16 ToSqlInt16(SqlByte p) { return p.ToSqlInt16(); }
        public static SqlInt16 ToSqlInt16(SqlInt32 p) { return p.ToSqlInt16(); }
        public static SqlInt16 ToSqlInt16(SqlInt64 p) { return p.ToSqlInt16(); }

        public static SqlInt16 ToSqlInt16(SqlSingle p) { return p.ToSqlInt16(); }
        public static SqlInt16 ToSqlInt16(SqlDouble p) { return p.ToSqlInt16(); }
        public static SqlInt16 ToSqlInt16(SqlDecimal p) { return p.ToSqlInt16(); }
        public static SqlInt16 ToSqlInt16(SqlMoney p) { return p.ToSqlInt16(); }

        public static SqlInt16 ToSqlInt16(SqlBoolean p) { return p.ToSqlInt16(); }
        public static SqlInt16 ToSqlInt16(SqlDateTime p) { return p.IsNull ? SqlInt16.Null : ToInt16(p.Value); }

        public static SqlInt16 ToSqlInt16(object p)
        {
            if (p == null || p is DBNull) return SqlInt16.Null;

            if (p is SqlInt16) return (SqlInt16)p;

            // Scalar Types.
            //
            if (p is Int16) return ToSqlInt16((Int16)p);
            if (p is String) return ToSqlInt16((String)p);

            if (p is Char) return ToSqlInt16((Char)p);
            if (p is Boolean) return ToSqlInt16((Boolean)p);

            // SqlTypes.
            //
            if (p is SqlDateTime) return ToSqlInt16((SqlDateTime)p);

            return ToInt16(p);
        }
#endif
        #endregion

        #region SqlInt32
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlInt32 ToSqlInt32(Int32 p) { return p; }
        public static SqlInt32 ToSqlInt32(String p) { return p == null ? SqlInt32.Null : SqlInt32.Parse(p); }

        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(SByte p) { return checked((Int32)p); }
        public static SqlInt32 ToSqlInt32(Int16 p) { return checked((Int32)p); }
        public static SqlInt32 ToSqlInt32(Int64 p) { return checked((Int32)p); }

        public static SqlInt32 ToSqlInt32(Byte p) { return checked((Int32)p); }
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt16 p) { return checked((Int32)p); }
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt32 p) { return checked((Int32)p); }
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt64 p) { return checked((Int32)p); }

        public static SqlInt32 ToSqlInt32(Single p) { return checked((Int32)p); }
        public static SqlInt32 ToSqlInt32(Double p) { return checked((Int32)p); }

        public static SqlInt32 ToSqlInt32(Decimal p) { return checked((Int32)p); }
        public static SqlInt32 ToSqlInt32(Char p) { return checked((Int32)p); }
        public static SqlInt32 ToSqlInt32(Boolean p) { return p ? 1 : 0; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlInt32 ToSqlInt32(Int32? p)      { return p.HasValue?         p.Value:  SqlInt32.Null; }
		[CLSCompliant(false)]
		public static SqlInt32 ToSqlInt32(SByte? p)      { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		public static SqlInt32 ToSqlInt32(Int16? p)      { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		public static SqlInt32 ToSqlInt32(Int64? p)      { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }

		public static SqlInt32 ToSqlInt32(Byte? p)       { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		[CLSCompliant(false)]
		public static SqlInt32 ToSqlInt32(UInt16? p)     { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		[CLSCompliant(false)]
		public static SqlInt32 ToSqlInt32(UInt32? p)     { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		[CLSCompliant(false)]
		public static SqlInt32 ToSqlInt32(UInt64? p)     { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }

		public static SqlInt32 ToSqlInt32(Single? p)     { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		public static SqlInt32 ToSqlInt32(Double? p)     { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }

		public static SqlInt32 ToSqlInt32(Boolean? p)    { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		public static SqlInt32 ToSqlInt32(Decimal? p)    { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }
		public static SqlInt32 ToSqlInt32(Char? p)       { return p.HasValue? ToInt32(p.Value): SqlInt32.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlInt32 ToSqlInt32(SqlString p) { return p.ToSqlInt32(); }

        public static SqlInt32 ToSqlInt32(SqlByte p) { return p.ToSqlInt32(); }
        public static SqlInt32 ToSqlInt32(SqlInt16 p) { return p.ToSqlInt32(); }
        public static SqlInt32 ToSqlInt32(SqlInt64 p) { return p.ToSqlInt32(); }

        public static SqlInt32 ToSqlInt32(SqlSingle p) { return p.ToSqlInt32(); }
        public static SqlInt32 ToSqlInt32(SqlDouble p) { return p.ToSqlInt32(); }
        public static SqlInt32 ToSqlInt32(SqlDecimal p) { return p.ToSqlInt32(); }
        public static SqlInt32 ToSqlInt32(SqlMoney p) { return p.ToSqlInt32(); }

        public static SqlInt32 ToSqlInt32(SqlBoolean p) { return p.ToSqlInt32(); }
        public static SqlInt32 ToSqlInt32(SqlDateTime p) { return p.IsNull ? SqlInt32.Null : ToInt32(p.Value); }

        public static SqlInt32 ToSqlInt32(object p)
        {
            if (p == null || p is DBNull) return SqlInt32.Null;

            if (p is SqlInt32) return (SqlInt32)p;

            // Scalar Types.
            //
            if (p is Int32) return ToSqlInt32((Int32)p);
            if (p is String) return ToSqlInt32((String)p);

            if (p is Char) return ToSqlInt32((Char)p);
            if (p is Boolean) return ToSqlInt32((Boolean)p);

            // SqlTypes.
            //
            if (p is SqlDateTime) return ToSqlInt32((SqlDateTime)p);

            return ToInt32(p);
        }
#endif
        #endregion

        #region SqlInt64
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlInt64 ToSqlInt64(Int64 p) { return p; }
        public static SqlInt64 ToSqlInt64(String p) { return p == null ? SqlInt64.Null : SqlInt64.Parse(p); }

        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(SByte p) { return checked((Int64)p); }
        public static SqlInt64 ToSqlInt64(Int16 p) { return checked((Int64)p); }
        public static SqlInt64 ToSqlInt64(Int32 p) { return checked((Int64)p); }

        public static SqlInt64 ToSqlInt64(Byte p) { return checked((Int64)p); }
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt16 p) { return checked((Int64)p); }
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt32 p) { return checked((Int64)p); }
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt64 p) { return checked((Int64)p); }

        public static SqlInt64 ToSqlInt64(Single p) { return checked((Int64)p); }
        public static SqlInt64 ToSqlInt64(Double p) { return checked((Int64)p); }

        public static SqlInt64 ToSqlInt64(Decimal p) { return checked((Int64)p); }
        public static SqlInt64 ToSqlInt64(Char p) { return checked((Int64)p); }
        public static SqlInt64 ToSqlInt64(Boolean p) { return p ? 1 : 0; }
        public static SqlInt64 ToSqlInt64(DateTime p) { return (p - DateTime.MinValue).Ticks; }
        public static SqlInt64 ToSqlInt64(TimeSpan p) { return p.Ticks; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlInt64 ToSqlInt64(Int64? p)      { return p.HasValue?         p.Value:  SqlInt64.Null; }
		[CLSCompliant(false)]
		public static SqlInt64 ToSqlInt64(SByte? p)      { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(Int16? p)      { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(Int32? p)      { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }

		public static SqlInt64 ToSqlInt64(Byte? p)       { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		[CLSCompliant(false)]
		public static SqlInt64 ToSqlInt64(UInt16? p)     { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		[CLSCompliant(false)]
		public static SqlInt64 ToSqlInt64(UInt32? p)     { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		[CLSCompliant(false)]
		public static SqlInt64 ToSqlInt64(UInt64? p)     { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }

		public static SqlInt64 ToSqlInt64(Single? p)     { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(Double? p)     { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }

		public static SqlInt64 ToSqlInt64(Boolean? p)    { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(Decimal? p)    { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(Char? p)       { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(DateTime? p)   { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }
		public static SqlInt64 ToSqlInt64(TimeSpan? p)   { return p.HasValue? ToInt64(p.Value): SqlInt64.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlInt64 ToSqlInt64(SqlString p) { return p.ToSqlInt64(); }

        public static SqlInt64 ToSqlInt64(SqlByte p) { return p.ToSqlInt64(); }
        public static SqlInt64 ToSqlInt64(SqlInt16 p) { return p.ToSqlInt64(); }
        public static SqlInt64 ToSqlInt64(SqlInt32 p) { return p.ToSqlInt64(); }

        public static SqlInt64 ToSqlInt64(SqlSingle p) { return p.ToSqlInt64(); }
        public static SqlInt64 ToSqlInt64(SqlDouble p) { return p.ToSqlInt64(); }
        public static SqlInt64 ToSqlInt64(SqlDecimal p) { return p.ToSqlInt64(); }
        public static SqlInt64 ToSqlInt64(SqlMoney p) { return p.ToSqlInt64(); }

        public static SqlInt64 ToSqlInt64(SqlBoolean p) { return p.ToSqlInt64(); }
        public static SqlInt64 ToSqlInt64(SqlDateTime p) { return p.IsNull ? SqlInt64.Null : ToInt64(p.Value); }

        public static SqlInt64 ToSqlInt64(object p)
        {
            if (p == null || p is DBNull) return SqlInt64.Null;

            if (p is SqlInt64) return (SqlInt64)p;

            // Scalar Types.
            //
            if (p is Int64) return ToSqlInt64((Int64)p);
            if (p is String) return ToSqlInt64((String)p);

            if (p is Char) return ToSqlInt64((Char)p);
            if (p is Boolean) return ToSqlInt64((Boolean)p);
            if (p is DateTime) return ToSqlInt64((DateTime)p);
            if (p is TimeSpan) return ToSqlInt64((TimeSpan)p);

            // SqlTypes.
            //
            if (p is SqlDateTime) return ToSqlInt64((SqlDateTime)p);

            return ToInt64(p);
        }
#endif
        #endregion

        #region SqlSingle
#if! SILVERLIGHT
        // Scalar Types.
        // 
        public static SqlSingle ToSqlSingle(Single p) { return p; }
        public static SqlSingle ToSqlSingle(String p) { return p == null ? SqlSingle.Null : SqlSingle.Parse(p); }

        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(SByte p) { return checked((Single)p); }
        public static SqlSingle ToSqlSingle(Int16 p) { return checked((Single)p); }
        public static SqlSingle ToSqlSingle(Int32 p) { return checked((Single)p); }
        public static SqlSingle ToSqlSingle(Int64 p) { return checked((Single)p); }

        public static SqlSingle ToSqlSingle(Byte p) { return checked((Single)p); }
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt16 p) { return checked((Single)p); }
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt32 p) { return checked((Single)p); }
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt64 p) { return checked((Single)p); }

        public static SqlSingle ToSqlSingle(Double p) { return checked((Single)p); }

        public static SqlSingle ToSqlSingle(Decimal p) { return checked((Single)p); }
        public static SqlSingle ToSqlSingle(Char p) { return checked((Single)p); }
        public static SqlSingle ToSqlSingle(Boolean p) { return p ? 1.0f : 0.0f; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlSingle ToSqlSingle(Single? p)     { return p.HasValue?          p.Value:  SqlSingle.Null; }
		[CLSCompliant(false)]
		public static SqlSingle ToSqlSingle(SByte? p)      { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		public static SqlSingle ToSqlSingle(Int16? p)      { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		public static SqlSingle ToSqlSingle(Int32? p)      { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		public static SqlSingle ToSqlSingle(Int64? p)      { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }

		public static SqlSingle ToSqlSingle(Byte? p)       { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		[CLSCompliant(false)]
		public static SqlSingle ToSqlSingle(UInt16? p)     { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		[CLSCompliant(false)]
		public static SqlSingle ToSqlSingle(UInt32? p)     { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		[CLSCompliant(false)]
		public static SqlSingle ToSqlSingle(UInt64? p)     { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }

		public static SqlSingle ToSqlSingle(Double? p)     { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }

		public static SqlSingle ToSqlSingle(Boolean? p)    { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }
		public static SqlSingle ToSqlSingle(Decimal? p)    { return p.HasValue? ToSingle(p.Value): SqlSingle.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlSingle ToSqlSingle(SqlString p) { return p.ToSqlSingle(); }

        public static SqlSingle ToSqlSingle(SqlByte p) { return p.ToSqlSingle(); }
        public static SqlSingle ToSqlSingle(SqlInt16 p) { return p.ToSqlSingle(); }
        public static SqlSingle ToSqlSingle(SqlInt32 p) { return p.ToSqlSingle(); }
        public static SqlSingle ToSqlSingle(SqlInt64 p) { return p.ToSqlSingle(); }

        public static SqlSingle ToSqlSingle(SqlDouble p) { return p.ToSqlSingle(); }
        public static SqlSingle ToSqlSingle(SqlDecimal p) { return p.ToSqlSingle(); }
        public static SqlSingle ToSqlSingle(SqlMoney p) { return p.ToSqlSingle(); }

        public static SqlSingle ToSqlSingle(SqlBoolean p) { return p.ToSqlSingle(); }

        public static SqlSingle ToSqlSingle(object p)
        {
            if (p == null || p is DBNull) return SqlSingle.Null;

            if (p is SqlSingle) return (SqlSingle)p;

            // Scalar Types.
            //
            if (p is Single) return ToSqlSingle((Single)p);
            if (p is String) return ToSqlSingle((String)p);

            if (p is Char) return ToSqlSingle((Char)p);
            if (p is Boolean) return ToSqlSingle((Boolean)p);

            return ToSingle(p);
        }
#endif
        #endregion

        #region SqlDouble
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlDouble ToSqlDouble(Double p) { return p; }
        public static SqlDouble ToSqlDouble(String p) { return p == null ? SqlDouble.Null : SqlDouble.Parse(p); }

        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(SByte p) { return checked((Double)p); }
        public static SqlDouble ToSqlDouble(Int16 p) { return checked((Double)p); }
        public static SqlDouble ToSqlDouble(Int32 p) { return checked((Double)p); }
        public static SqlDouble ToSqlDouble(Int64 p) { return checked((Double)p); }

        public static SqlDouble ToSqlDouble(Byte p) { return checked((Double)p); }
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt16 p) { return checked((Double)p); }
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt32 p) { return checked((Double)p); }
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt64 p) { return checked((Double)p); }

        public static SqlDouble ToSqlDouble(Single p) { return checked((Double)p); }

        public static SqlDouble ToSqlDouble(Decimal p) { return checked((Double)p); }
        public static SqlDouble ToSqlDouble(Char p) { return checked((Double)p); }
        public static SqlDouble ToSqlDouble(Boolean p) { return p ? 1.0 : 0.0; }
        public static SqlDouble ToSqlDouble(DateTime p) { return (p - DateTime.MinValue).TotalDays; }
        public static SqlDouble ToSqlDouble(TimeSpan p) { return p.TotalDays; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlDouble ToSqlDouble(Double? p)     { return p.HasValue?          p.Value:  SqlDouble.Null; }
		[CLSCompliant(false)]
		public static SqlDouble ToSqlDouble(SByte? p)      { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		public static SqlDouble ToSqlDouble(Int16? p)      { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		public static SqlDouble ToSqlDouble(Int32? p)      { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		public static SqlDouble ToSqlDouble(Int64? p)      { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }

		public static SqlDouble ToSqlDouble(Byte? p)       { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		[CLSCompliant(false)]
		public static SqlDouble ToSqlDouble(UInt16? p)     { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		[CLSCompliant(false)]
		public static SqlDouble ToSqlDouble(UInt32? p)     { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		[CLSCompliant(false)]
		public static SqlDouble ToSqlDouble(UInt64? p)     { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }

		public static SqlDouble ToSqlDouble(Single? p)     { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }

		public static SqlDouble ToSqlDouble(Boolean? p)    { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		public static SqlDouble ToSqlDouble(Decimal? p)    { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		public static SqlDouble ToSqlDouble(DateTime? p)   { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }
		public static SqlDouble ToSqlDouble(TimeSpan? p)   { return p.HasValue? ToDouble(p.Value): SqlDouble.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlDouble ToSqlDouble(SqlString p) { return p.ToSqlDouble(); }

        public static SqlDouble ToSqlDouble(SqlByte p) { return p.ToSqlDouble(); }
        public static SqlDouble ToSqlDouble(SqlInt16 p) { return p.ToSqlDouble(); }
        public static SqlDouble ToSqlDouble(SqlInt32 p) { return p.ToSqlDouble(); }
        public static SqlDouble ToSqlDouble(SqlInt64 p) { return p.ToSqlDouble(); }

        public static SqlDouble ToSqlDouble(SqlSingle p) { return p.ToSqlDouble(); }
        public static SqlDouble ToSqlDouble(SqlDecimal p) { return p.ToSqlDouble(); }
        public static SqlDouble ToSqlDouble(SqlMoney p) { return p.ToSqlDouble(); }

        public static SqlDouble ToSqlDouble(SqlBoolean p) { return p.ToSqlDouble(); }
        public static SqlDouble ToSqlDouble(SqlDateTime p) { return p.IsNull ? SqlDouble.Null : ToDouble(p.Value); }

        public static SqlDouble ToSqlDouble(object p)
        {
            if (p == null || p is DBNull) return SqlDouble.Null;

            if (p is SqlDouble) return (SqlDouble)p;

            // Scalar Types.
            //
            if (p is Double) return ToSqlDouble((Double)p);
            if (p is String) return ToSqlDouble((String)p);

            if (p is Char) return ToSqlDouble((Char)p);
            if (p is Boolean) return ToSqlDouble((Boolean)p);
            if (p is DateTime) return ToSqlDouble((DateTime)p);
            if (p is TimeSpan) return ToSqlDouble((TimeSpan)p);

            // SqlTypes.
            //
            if (p is SqlDateTime) return ToSqlDouble((SqlDateTime)p);

            return ToDouble(p);
        }
#endif
        #endregion

        #region SqlDecimal
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlDecimal ToSqlDecimal(Decimal p) { return p; }
        public static SqlDecimal ToSqlDecimal(String p) { return p == null ? SqlDecimal.Null : SqlDecimal.Parse(p); }

        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(SByte p) { return checked((Decimal)p); }
        public static SqlDecimal ToSqlDecimal(Int16 p) { return checked((Decimal)p); }
        public static SqlDecimal ToSqlDecimal(Int32 p) { return checked((Decimal)p); }
        public static SqlDecimal ToSqlDecimal(Int64 p) { return checked((Decimal)p); }

        public static SqlDecimal ToSqlDecimal(Byte p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt16 p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt32 p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt64 p) { return checked((Decimal)p); }

        public static SqlDecimal ToSqlDecimal(Single p) { return checked((Decimal)p); }
        public static SqlDecimal ToSqlDecimal(Double p) { return checked((Decimal)p); }

        public static SqlDecimal ToSqlDecimal(Char p) { return checked((Decimal)p); }
        public static SqlDecimal ToSqlDecimal(Boolean p) { return p ? 1.0m : 0.0m; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlDecimal ToSqlDecimal(Decimal? p)    { return p.HasValue?           p.Value:  SqlDecimal.Null; }
		[CLSCompliant(false)]
		public static SqlDecimal ToSqlDecimal(SByte? p)      { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		public static SqlDecimal ToSqlDecimal(Int16? p)      { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		public static SqlDecimal ToSqlDecimal(Int32? p)      { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		public static SqlDecimal ToSqlDecimal(Int64? p)      { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }

		public static SqlDecimal ToSqlDecimal(Byte? p)       { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		[CLSCompliant(false)]
		public static SqlDecimal ToSqlDecimal(UInt16? p)     { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		[CLSCompliant(false)]
		public static SqlDecimal ToSqlDecimal(UInt32? p)     { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		[CLSCompliant(false)]
		public static SqlDecimal ToSqlDecimal(UInt64? p)     { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }

		public static SqlDecimal ToSqlDecimal(Single? p)     { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }
		public static SqlDecimal ToSqlDecimal(Double? p)     { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }

		public static SqlDecimal ToSqlDecimal(Boolean? p)    { return p.HasValue? ToDecimal(p.Value): SqlDecimal.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlDecimal ToSqlDecimal(SqlString p) { return p.ToSqlDecimal(); }

        public static SqlDecimal ToSqlDecimal(SqlByte p) { return p.ToSqlDecimal(); }
        public static SqlDecimal ToSqlDecimal(SqlInt16 p) { return p.ToSqlDecimal(); }
        public static SqlDecimal ToSqlDecimal(SqlInt32 p) { return p.ToSqlDecimal(); }
        public static SqlDecimal ToSqlDecimal(SqlInt64 p) { return p.ToSqlDecimal(); }

        public static SqlDecimal ToSqlDecimal(SqlSingle p) { return p.ToSqlDecimal(); }
        public static SqlDecimal ToSqlDecimal(SqlDouble p) { return p.ToSqlDecimal(); }
        public static SqlDecimal ToSqlDecimal(SqlMoney p) { return p.ToSqlDecimal(); }

        public static SqlDecimal ToSqlDecimal(SqlBoolean p) { return p.ToSqlDecimal(); }

        public static SqlDecimal ToSqlDecimal(object p)
        {
            if (p == null || p is DBNull) return SqlDecimal.Null;

            if (p is SqlDecimal) return (SqlDecimal)p;

            // Scalar Types.
            //
            if (p is Decimal) return ToSqlDecimal((Decimal)p);
            if (p is String) return ToSqlDecimal((String)p);

            if (p is Char) return ToSqlDecimal((Char)p);
            if (p is Boolean) return ToSqlDecimal((Boolean)p);

            return ToDecimal(p);
        }
#endif
        #endregion

        #region SqlMoney
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlMoney ToSqlMoney(Decimal p) { return p; }
        public static SqlMoney ToSqlMoney(String p) { return p == null ? SqlMoney.Null : SqlMoney.Parse(p); }

        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(SByte p) { return checked((Decimal)p); }
        public static SqlMoney ToSqlMoney(Int16 p) { return checked((Decimal)p); }
        public static SqlMoney ToSqlMoney(Int32 p) { return checked((Decimal)p); }
        public static SqlMoney ToSqlMoney(Int64 p) { return checked((Decimal)p); }

        public static SqlMoney ToSqlMoney(Byte p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt16 p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt32 p) { return checked((Decimal)p); }
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt64 p) { return checked((Decimal)p); }

        public static SqlMoney ToSqlMoney(Single p) { return checked((Decimal)p); }
        public static SqlMoney ToSqlMoney(Double p) { return checked((Decimal)p); }

        public static SqlMoney ToSqlMoney(Char p) { return checked((Decimal)p); }
        public static SqlMoney ToSqlMoney(Boolean p) { return p ? 1.0m : 0.0m; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlMoney ToSqlMoney(Decimal? p)    { return p.HasValue?           p.Value:  SqlMoney.Null; }
		[CLSCompliant(false)]
		public static SqlMoney ToSqlMoney(SByte? p)      { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		public static SqlMoney ToSqlMoney(Int16? p)      { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		public static SqlMoney ToSqlMoney(Int32? p)      { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		public static SqlMoney ToSqlMoney(Int64? p)      { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }

		public static SqlMoney ToSqlMoney(Byte? p)       { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		[CLSCompliant(false)]
		public static SqlMoney ToSqlMoney(UInt16? p)     { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		[CLSCompliant(false)]
		public static SqlMoney ToSqlMoney(UInt32? p)     { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		[CLSCompliant(false)]
		public static SqlMoney ToSqlMoney(UInt64? p)     { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }

		public static SqlMoney ToSqlMoney(Single? p)     { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }
		public static SqlMoney ToSqlMoney(Double? p)     { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }

		public static SqlMoney ToSqlMoney(Boolean? p)    { return p.HasValue? ToDecimal(p.Value): SqlMoney.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlMoney ToSqlMoney(SqlString p) { return p.ToSqlMoney(); }

        public static SqlMoney ToSqlMoney(SqlByte p) { return p.ToSqlMoney(); }
        public static SqlMoney ToSqlMoney(SqlInt16 p) { return p.ToSqlMoney(); }
        public static SqlMoney ToSqlMoney(SqlInt32 p) { return p.ToSqlMoney(); }
        public static SqlMoney ToSqlMoney(SqlInt64 p) { return p.ToSqlMoney(); }

        public static SqlMoney ToSqlMoney(SqlSingle p) { return p.ToSqlMoney(); }
        public static SqlMoney ToSqlMoney(SqlDouble p) { return p.ToSqlMoney(); }
        public static SqlMoney ToSqlMoney(SqlDecimal p) { return p.ToSqlMoney(); }

        public static SqlMoney ToSqlMoney(SqlBoolean p) { return p.ToSqlMoney(); }

        public static SqlMoney ToSqlMoney(object p)
        {
            if (p == null || p is DBNull) return SqlMoney.Null;

            if (p is SqlMoney) return (SqlMoney)p;

            // Scalar Types.
            //
            if (p is Decimal) return ToSqlMoney((Decimal)p);
            if (p is String) return ToSqlMoney((String)p);

            if (p is Char) return ToSqlMoney((Char)p);
            if (p is Boolean) return ToSqlMoney((Boolean)p);

            return ToDecimal(p);
        }
#endif
        #endregion

        #region SqlBoolean
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlBoolean ToSqlBoolean(Boolean p) { return p; }
        public static SqlBoolean ToSqlBoolean(String p) { return p == null ? SqlBoolean.Null : SqlBoolean.Parse(p); }

        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(SByte p) { return p != 0; }
        public static SqlBoolean ToSqlBoolean(Int16 p) { return p != 0; }
        public static SqlBoolean ToSqlBoolean(Int32 p) { return p != 0; }
        public static SqlBoolean ToSqlBoolean(Int64 p) { return p != 0; }

        public static SqlBoolean ToSqlBoolean(Byte p) { return p != 0; }
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt16 p) { return p != 0; }
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt32 p) { return p != 0; }
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt64 p) { return p != 0; }

        public static SqlBoolean ToSqlBoolean(Single p) { return p != 0; }
        public static SqlBoolean ToSqlBoolean(Double p) { return p != 0; }

        public static SqlBoolean ToSqlBoolean(Decimal p) { return p != 0; }
        public static SqlBoolean ToSqlBoolean(Char p) { return p != 0; }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlBoolean ToSqlBoolean(Boolean? p)    { return p.HasValue?           p.Value:  SqlBoolean.Null; }
		[CLSCompliant(false)]
		public static SqlBoolean ToSqlBoolean(SByte? p)      { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		public static SqlBoolean ToSqlBoolean(Int16? p)      { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		public static SqlBoolean ToSqlBoolean(Int32? p)      { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		public static SqlBoolean ToSqlBoolean(Int64? p)      { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }

		public static SqlBoolean ToSqlBoolean(Byte? p)       { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		[CLSCompliant(false)]
		public static SqlBoolean ToSqlBoolean(UInt16? p)     { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		[CLSCompliant(false)]
		public static SqlBoolean ToSqlBoolean(UInt32? p)     { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		[CLSCompliant(false)]
		public static SqlBoolean ToSqlBoolean(UInt64? p)     { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }

		public static SqlBoolean ToSqlBoolean(Single? p)     { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		public static SqlBoolean ToSqlBoolean(Double? p)     { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }

		public static SqlBoolean ToSqlBoolean(Decimal? p)    { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }
		public static SqlBoolean ToSqlBoolean(Char? p)       { return p.HasValue? ToBoolean(p.Value): SqlBoolean.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlBoolean ToSqlBoolean(SqlString p) { return p.ToSqlBoolean(); }

        public static SqlBoolean ToSqlBoolean(SqlByte p) { return p.ToSqlBoolean(); }
        public static SqlBoolean ToSqlBoolean(SqlInt16 p) { return p.ToSqlBoolean(); }
        public static SqlBoolean ToSqlBoolean(SqlInt32 p) { return p.ToSqlBoolean(); }
        public static SqlBoolean ToSqlBoolean(SqlInt64 p) { return p.ToSqlBoolean(); }

        public static SqlBoolean ToSqlBoolean(SqlSingle p) { return p.ToSqlBoolean(); }
        public static SqlBoolean ToSqlBoolean(SqlDouble p) { return p.ToSqlBoolean(); }
        public static SqlBoolean ToSqlBoolean(SqlDecimal p) { return p.ToSqlBoolean(); }
        public static SqlBoolean ToSqlBoolean(SqlMoney p) { return p.ToSqlBoolean(); }


        public static SqlBoolean ToSqlBoolean(object p)
        {
            if (p == null || p is DBNull) return SqlBoolean.Null;

            if (p is SqlBoolean) return (SqlBoolean)p;

            // Scalar Types.
            //
            if (p is Boolean) return ToSqlBoolean((Boolean)p);
            if (p is String) return ToSqlBoolean((String)p);

            if (p is Char) return ToSqlBoolean((Char)p);

            return ToBoolean(p);
        }
#endif
        #endregion

        #region SqlDateTime
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlDateTime ToSqlDateTime(String p) { return p == null ? SqlDateTime.Null : SqlDateTime.Parse(p); }
        public static SqlDateTime ToSqlDateTime(DateTime p) { return p; }
        public static SqlDateTime ToSqlDateTime(TimeSpan p) { return ToDateTime(p); }
        public static SqlDateTime ToSqlDateTime(Int64 p) { return ToDateTime(p); }
        public static SqlDateTime ToSqlDateTime(Double p) { return ToDateTime(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlDateTime ToSqlDateTime(DateTime? p)   { return p.HasValue?            p.Value:  SqlDateTime.Null; }
		public static SqlDateTime ToSqlDateTime(TimeSpan? p)   { return p.HasValue? ToDateTime(p.Value): SqlDateTime.Null; }
		public static SqlDateTime ToSqlDateTime(Int64? p)      { return p.HasValue? ToDateTime(p.Value): SqlDateTime.Null; }
		public static SqlDateTime ToSqlDateTime(Double? p)     { return p.HasValue? ToDateTime(p.Value): SqlDateTime.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlDateTime ToSqlDateTime(SqlString p) { return p.ToSqlDateTime(); }
        public static SqlDateTime ToSqlDateTime(SqlInt64 p) { return p.IsNull ? SqlDateTime.Null : ToDateTime(p); }
        public static SqlDateTime ToSqlDateTime(SqlDouble p) { return p.IsNull ? SqlDateTime.Null : ToDateTime(p); }

        public static SqlDateTime ToSqlDateTime(object p)
        {
            if (p == null || p is DBNull) return SqlDateTime.Null;

            if (p is SqlDateTime) return (SqlDateTime)p;

            // Scalar Types.
            //
            if (p is String) return ToSqlDateTime((String)p);
            if (p is DateTime) return ToSqlDateTime((DateTime)p);
            if (p is TimeSpan) return ToSqlDateTime((TimeSpan)p);
            if (p is Int64) return ToSqlDateTime((Int64)p);
            if (p is Double) return ToSqlDateTime((Double)p);

            // SqlTypes.
            //
            if (p is SqlString) return ToSqlDateTime((SqlString)p);
            if (p is SqlInt64) return ToSqlDateTime((SqlInt64)p);
            if (p is SqlDouble) return ToSqlDateTime((SqlDouble)p);

            return ToDateTime(p);
        }
#endif
        #endregion

        #region SqlGuid
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlGuid ToSqlGuid(Guid p) { return p; }
        public static SqlGuid ToSqlGuid(String p) { return p == null ? SqlGuid.Null : SqlGuid.Parse(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlGuid ToSqlGuid(Guid? p)       { return p.HasValue? p.Value : SqlGuid.Null; }

#endif
        // SqlTypes.
        // 
        public static SqlGuid ToSqlGuid(SqlBinary p) { return p.ToSqlGuid(); }
#if !(NET_1_1)
        public static SqlGuid ToSqlGuid(SqlBytes p)    { return p.ToSqlBinary().ToSqlGuid(); }
#endif
        public static SqlGuid ToSqlGuid(SqlString p) { return p.ToSqlGuid(); }

        // Other Types.
        // 
        public static SqlGuid ToSqlGuid(Type p) { return p == null ? SqlGuid.Null : p.GUID; }
        public static SqlGuid ToSqlGuid(Byte[] p) { return p == null ? SqlGuid.Null : new SqlGuid(p); }

        public static SqlGuid ToSqlGuid(object p)
        {
            if (p == null || p is DBNull) return SqlGuid.Null;

            if (p is SqlGuid) return (SqlGuid)p;

            // Scalar Types.
            //
            if (p is Guid) return ToSqlGuid((Guid)p);
            if (p is String) return ToSqlGuid((String)p);

            // SqlTypes.
            //
            if (p is SqlBinary) return ToSqlGuid((SqlBinary)p);
#if !(NET_1_1)
            if (p is SqlBytes)    return ToSqlGuid((SqlBytes)p);
#endif
            if (p is SqlString) return ToSqlGuid((SqlString)p);

            // Other Types.
            //
            if (p is Type) return ToSqlGuid((Type)p);
            if (p is Byte[]) return ToSqlGuid((Byte[])p);

            return ToGuid(p);
        }
#endif
        #endregion

        #region SqlBinary
#if! SILVERLIGHT

        // Scalar Types.
        // 
        public static SqlBinary ToSqlBinary(Byte[] p) { return p; }
        public static SqlBinary ToSqlBinary(Guid p) { return p == Guid.Empty ? SqlBinary.Null : new SqlGuid(p).ToSqlBinary(); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static SqlBinary ToSqlBinary(Guid? p)       { return p.HasValue? new SqlGuid(p.Value).ToSqlBinary(): SqlBinary.Null; }

#endif
        // SqlTypes.
        // 
#if !(NET_1_1)
        public static SqlBinary ToSqlBinary(SqlBytes p)    { return p.ToSqlBinary(); }
#endif
        public static SqlBinary ToSqlBinary(SqlGuid p) { return p.ToSqlBinary(); }

        public static SqlBinary ToSqlBinary(object p)
        {
            if (p == null || p is DBNull) return SqlBinary.Null;

            if (p is SqlBinary) return (SqlBinary)p;

            // Scalar Types.
            //
            if (p is Byte[]) return ToSqlBinary((Byte[])p);
            if (p is Guid) return ToSqlBinary((Guid)p);

            // SqlTypes.
            //
#if !(NET_1_1)
            if (p is SqlBytes)    return ToSqlBinary((SqlBytes)p);
#endif
            if (p is SqlGuid) return ToSqlBinary((SqlGuid)p);

            return ToByteArray(p);
        }
#endif
        #endregion

#if !(NET_1_1)
        #region SqlBytes
#if! SILVERLIGHT

        // Scalar Types.
		// 
		public static SqlBytes ToSqlBytes(Byte[] p)      { return p == null? SqlBytes.Null: new SqlBytes(p); }
		public static SqlBytes ToSqlBytes(Stream p)      { return p == null? SqlBytes.Null: new SqlBytes(p); }
		public static SqlBytes ToSqlBytes(Guid p)        { return p == Guid.Empty? SqlBytes.Null: new SqlBytes(p.ToByteArray()); }

		// Nullable Types.
		// 
		public static SqlBytes ToSqlBytes(Guid? p)       { return p.HasValue? new SqlBytes(p.Value.ToByteArray()): SqlBytes.Null; }

		// SqlTypes.
		// 
		public static SqlBytes ToSqlBytes(SqlBinary p)   { return p.IsNull? SqlBytes.Null: new SqlBytes(p); }
		public static SqlBytes ToSqlBytes(SqlGuid p)     { return p.IsNull? SqlBytes.Null: new SqlBytes(p.ToByteArray()); }

		public static SqlBytes ToSqlBytes(object p)
		{
			if (p == null || p is DBNull) return SqlBytes.Null;

			if (p is SqlBytes)    return (SqlBytes)p;

			// Scalar Types.
			//
			if (p is Byte[])      return ToSqlBytes((Byte[])p);
			if (p is Stream)      return ToSqlBytes((Stream)p);
			if (p is Guid)        return ToSqlBytes((Guid)p);

			// SqlTypes.
			//
			if (p is SqlBinary)   return ToSqlBytes((SqlBinary)p);
			if (p is SqlGuid)     return ToSqlBytes((SqlGuid)p);

			return new SqlBytes(ToByteArray(p));
		}
#endif
        #endregion

        #region SqlChars
#if! SILVERLIGHT

		// Scalar Types.
		// 
		public static SqlChars ToSqlChars(String p)      { return p == null? SqlChars.Null: new SqlChars(p.ToCharArray()); }
		public static SqlChars ToSqlChars(Char[] p)      { return p == null? SqlChars.Null: new SqlChars(p); }

		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(SByte p)       { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Int16 p)       { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Int32 p)       { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Int64 p)       { return new SqlChars(ToString(p).ToCharArray()); }

		public static SqlChars ToSqlChars(Byte p)        { return new SqlChars(ToString(p).ToCharArray()); }
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(UInt16 p)      { return new SqlChars(ToString(p).ToCharArray()); }
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(UInt32 p)      { return new SqlChars(ToString(p).ToCharArray()); }
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(UInt64 p)      { return new SqlChars(ToString(p).ToCharArray()); }

		public static SqlChars ToSqlChars(Single p)      { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Double p)      { return new SqlChars(ToString(p).ToCharArray()); }

		public static SqlChars ToSqlChars(Boolean p)     { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Decimal p)     { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Char p)        { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(TimeSpan p)    { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(DateTime p)    { return new SqlChars(ToString(p).ToCharArray()); }
		public static SqlChars ToSqlChars(Guid p)        { return new SqlChars(ToString(p).ToCharArray()); }

		// Nullable Types.
		// 
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(SByte? p)      { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Int16? p)      { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Int32? p)      { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Int64? p)      { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }

		public static SqlChars ToSqlChars(Byte? p)       { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(UInt16? p)     { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(UInt32? p)     { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		[CLSCompliant(false)]
		public static SqlChars ToSqlChars(UInt64? p)     { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }

		public static SqlChars ToSqlChars(Single? p)     { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Double? p)     { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }

		public static SqlChars ToSqlChars(Boolean? p)    { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Decimal? p)    { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Char? p)       { return p.HasValue? new SqlChars(new Char[]{p.Value})       : SqlChars.Null; }
		public static SqlChars ToSqlChars(TimeSpan? p)   { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(DateTime? p)   { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }
		public static SqlChars ToSqlChars(Guid? p)       { return p.HasValue? new SqlChars(p.ToString().ToCharArray()): SqlChars.Null; }

		// SqlTypes.
		// 
		public static SqlChars ToSqlChars(SqlString p)   { return (SqlChars)p; }

		public static SqlChars ToSqlChars(SqlByte p)     { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlInt16 p)    { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlInt32 p)    { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlInt64 p)    { return (SqlChars)p.ToSqlString(); }

		public static SqlChars ToSqlChars(SqlSingle p)   { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlDouble p)   { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlDecimal p)  { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlMoney p)    { return (SqlChars)p.ToSqlString(); }

		public static SqlChars ToSqlChars(SqlBoolean p)  { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlGuid p)     { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlDateTime p) { return (SqlChars)p.ToSqlString(); }
		public static SqlChars ToSqlChars(SqlBinary p)   { return p.IsNull? SqlChars.Null: new SqlChars(p.ToString().ToCharArray()); }

		public static SqlChars ToSqlChars(Type p)        { return p == null? SqlChars.Null: new SqlChars(p.FullName.ToCharArray()); }
		public static SqlChars ToSqlChars(object p)      { return new SqlChars(ToString(p).ToCharArray()); }
#endif
        #endregion

        #region SqlXml
#if! SILVERLIGHT
		// Scalar Types.
		// 
		public static SqlXml ToSqlXml(String p)      { return p == null? SqlXml.Null: new SqlXml(new XmlTextReader(new StringReader(p))); }

		public static SqlXml ToSqlXml(Stream p)      { return p == null? SqlXml.Null: new SqlXml(p); }
		public static SqlXml ToSqlXml(XmlReader p)   { return p == null? SqlXml.Null: new SqlXml(p); }
		public static SqlXml ToSqlXml(XmlDocument p) { return p == null? SqlXml.Null: new SqlXml(new XmlTextReader(new StringReader(p.InnerXml))); }

		public static SqlXml ToSqlXml(Char[] p)      { return p == null? SqlXml.Null: new SqlXml(new XmlTextReader(new StringReader(new string(p)))); }
		public static SqlXml ToSqlXml(Byte[] p)      { return p == null? SqlXml.Null: new SqlXml(new MemoryStream(p)); }

		// SqlTypes.
		// 
		public static SqlXml ToSqlXml(SqlString p)   { return p.IsNull? SqlXml.Null: new SqlXml(new XmlTextReader(new StringReader(p.Value))); }
		public static SqlXml ToSqlXml(SqlChars p)    { return p.IsNull? SqlXml.Null: new SqlXml(new XmlTextReader(new StringReader(p.ToSqlString().Value))); }
		public static SqlXml ToSqlXml(SqlBinary p)   { return p.IsNull? SqlXml.Null: new SqlXml(new MemoryStream(p.Value)); }
		public static SqlXml ToSqlXml(SqlBytes p)    { return p.IsNull? SqlXml.Null: new SqlXml(p.Stream); }

		public static SqlXml ToSqlXml(object p)
		{
			if (p == null || p is DBNull) return SqlXml.Null;

			if (p is SqlXml)      return (SqlXml)p;

			// Scalar Types.
			//
			if (p is String)      return ToSqlXml((String)p);

			if (p is Stream)      return ToSqlXml((Stream)p);
			if (p is XmlReader)   return ToSqlXml((XmlReader)p);
			if (p is XmlDocument) return ToSqlXml((XmlDocument)p);

			if (p is Char[])      return ToSqlXml((Char[])p);
			if (p is Byte[])      return ToSqlXml((Byte[])p);

			// SqlTypes.
			//
			if (p is SqlString)   return ToSqlXml((SqlString)p);
			if (p is SqlChars)    return ToSqlXml((SqlChars)p);
			if (p is SqlBinary)   return ToSqlXml((SqlBinary)p);
			if (p is SqlBytes)    return ToSqlXml((SqlBytes)p);

			throw CreateInvalidCastException(p.GetType(), typeof(SqlXml));
		}
#endif
        #endregion
#endif

        #endregion

        #region Other types

        #region Type

        // Scalar Types.
        // 
        public static Type ToType(String p) { return p == null ? null : Type.GetType(p); }
        public static Type ToType(Char[] p) { return p == null ? null : Type.GetType(new string(p)); }
#if! SILVERLIGHT
        public static Type ToType(Guid p) { return p == Guid.Empty ? null : Type.GetTypeFromCLSID(p); }
#endif

#if !(NET_1_1)
        // Nullable Types.
#if! SILVERLIGHT
		public static Type ToType(Guid? p)       { return p.HasValue? Type.GetTypeFromCLSID(p.Value): null; }
#endif
#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Type ToType(SqlString p) { return p.IsNull ? null : Type.GetType(p.Value); }
#if !(NET_1_1)
        public static Type ToType(SqlChars p)    { return p.IsNull       ? null: Type.GetType(new string(p.Value)); }
#endif
        public static Type ToType(SqlGuid p) { return p.IsNull ? null : Type.GetTypeFromCLSID(p.Value); }
#endif
        public static Type ToType(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is Type) return (Type)p;

            // Scalar Types.
            //
            if (p is String) return ToType((String)p);
            if (p is Char[]) return ToType((Char[])p);
            if (p is Guid) return ToType((Guid)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlString) return ToType((SqlString)p);
#if !(NET_1_1)
            if (p is SqlChars)    return ToType((SqlChars)p);
#endif
            if (p is SqlGuid) return ToType((SqlGuid)p);
#endif
            throw CreateInvalidCastException(p.GetType(), typeof(Type));
        }

        #endregion

        #region Stream

        // Scalar Types.
        // 
        public static Stream ToStream(Guid p) { return p == Guid.Empty ? Stream.Null : new MemoryStream(p.ToByteArray()); }
        public static Stream ToStream(Byte[] p) { return p == null ? Stream.Null : new MemoryStream(p); }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Stream ToStream(Guid? p)       { return p.HasValue? new MemoryStream(p.Value.ToByteArray()): Stream.Null; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
#if !(NET_1_1)
        public static Stream ToStream(SqlBytes p)    { return p.IsNull? Stream.Null: p.Stream;                  }
#endif
        public static Stream ToStream(SqlBinary p) { return p.IsNull ? Stream.Null : new MemoryStream(p.Value); }
        public static Stream ToStream(SqlGuid p) { return p.IsNull ? Stream.Null : new MemoryStream(p.Value.ToByteArray()); }
#endif
        public static Stream ToStream(object p)
        {
            if (p == null || p is DBNull) return Stream.Null;

            if (p is Stream) return (Stream)p;

            // Scalar Types.
            //
            if (p is Guid) return ToStream((Guid)p);
            if (p is Byte[]) return ToStream((Byte[])p);

            // SqlTypes.
#if! SILVERLIGHT
#if !(NET_1_1)
            if (p is SqlBytes)    return ToStream((SqlBytes)p);
#endif
            if (p is SqlBinary) return ToStream((SqlBinary)p);
            if (p is SqlGuid) return ToStream((SqlGuid)p);
#endif
            throw CreateInvalidCastException(p.GetType(), typeof(Stream));
        }

        #endregion

        #region Byte[]

        // Scalar Types.
        // 
        public static Byte[] ToByteArray(string p) { return p == null ? null : System.Text.Encoding.UTF8.GetBytes(p); }
        [CLSCompliant(false)]
        public static Byte[] ToByteArray(SByte p) { return new byte[] { checked((Byte)p) }; }
        public static Byte[] ToByteArray(Int16 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Int32 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Int64 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Byte p) { return new byte[] { p }; }
        [CLSCompliant(false)]
        public static Byte[] ToByteArray(UInt16 p) { return BitConverter.GetBytes(p); }
        [CLSCompliant(false)]
        public static Byte[] ToByteArray(UInt32 p) { return BitConverter.GetBytes(p); }
        [CLSCompliant(false)]
        public static Byte[] ToByteArray(UInt64 p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Char p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Single p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Double p) { return BitConverter.GetBytes(p); }
        public static Byte[] ToByteArray(Boolean p) { return BitConverter.GetBytes(p); }
#if !(NET_1_1)
#if! SILVERLIGHT
        public static Byte[] ToByteArray(DateTime p)    { return ToByteArray(p.ToBinary()); }
#endif
#else
        public static Byte[] ToByteArray(DateTime p) { return ToByteArray(p.ToOADate()); }
#endif
        public static Byte[] ToByteArray(TimeSpan p) { return ToByteArray(p.Ticks); }
        public static Byte[] ToByteArray(Guid p) { return p == Guid.Empty ? null : p.ToByteArray(); }

        public static Byte[] ToByteArray(Decimal p)
        {
            int[] bits = Decimal.GetBits(p);
            byte[] bytes = new byte[bits.Length << 2];

            for (int i = 0; i < bits.Length; ++i)
                Buffer.BlockCopy(BitConverter.GetBytes(bits[i]), 0, bytes, i * 4, 4);

            return bytes;
        }

        public static Byte[] ToByteArray(Stream p)
        {
            if (p == null) return null;
            if (p is MemoryStream) return ((MemoryStream)p).ToArray();

            long position = p.Seek(0, SeekOrigin.Begin);
            Byte[] bytes = new Byte[p.Length];
            p.Read(bytes, 0, bytes.Length);
            p.Position = position;

            return bytes;
        }
        [CLSCompliant(false)]
        public static Byte[] ToByteArray(ByteArray p)
        {
            if (p == null) return null;

            return p.GetBuffer();
        }

#if !(NET_1_1)
        // Nullable Types.
		// 
		public static Byte[] ToByteArray(Guid? p)       { return p.HasValue? p.Value.ToByteArray(): null; }
		[CLSCompliant(false)]
		public static Byte[] ToByteArray(SByte?  p)     { return p.HasValue? new byte[]{checked((Byte)p.Value)}: null; }
		public static Byte[] ToByteArray(Int16?  p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Int32?  p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Int64?  p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Byte?   p)     { return p.HasValue? new byte[]{p.Value}: null; }
		[CLSCompliant(false)]
		public static Byte[] ToByteArray(UInt16? p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		[CLSCompliant(false)]
		public static Byte[] ToByteArray(UInt32? p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		[CLSCompliant(false)]
		public static Byte[] ToByteArray(UInt64? p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Char?   p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Single? p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Double? p)     { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
		public static Byte[] ToByteArray(Boolean? p)    { return p.HasValue? BitConverter.GetBytes(p.Value): null; }
#if! SILVERLIGHT
		public static Byte[] ToByteArray(DateTime? p)   { return p.HasValue? ToByteArray(p.Value.ToBinary()): null; }
#endif
		public static Byte[] ToByteArray(TimeSpan? p)   { return p.HasValue? ToByteArray(p.Value.Ticks): null; }
		public static Byte[] ToByteArray(Decimal? p)    { return p.HasValue? ToByteArray(p.Value): null; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        public static Byte[] ToByteArray(SqlString p) { return p.IsNull ? null : ToByteArray(p.Value); }

        public static Byte[] ToByteArray(SqlByte p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlInt16 p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlInt32 p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlInt64 p) { return p.IsNull ? null : ToByteArray(p.Value); }

        public static Byte[] ToByteArray(SqlSingle p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlDouble p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlDecimal p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlMoney p) { return p.IsNull ? null : ToByteArray(p.Value); }

        public static Byte[] ToByteArray(SqlBoolean p) { return p.IsNull ? null : ToByteArray(p.Value); }
        public static Byte[] ToByteArray(SqlDateTime p) { return p.IsNull ? null : ToByteArray(p.Value); }

        public static Byte[] ToByteArray(SqlBinary p) { return p.IsNull ? null : p.Value; }
#if !(NET_1_1)
        public static Byte[] ToByteArray(SqlBytes p)    { return p.IsNull? null: p.Value; }
#endif
        public static Byte[] ToByteArray(SqlGuid p) { return p.IsNull ? null : p.ToByteArray(); }
#endif
        public static Byte[] ToByteArray(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is Byte[]) return (Byte[])p;

            // Scalar Types.
            //
            if (p is String) return ToByteArray((String)p);

            if (p is SByte) return ToByteArray((SByte)p);
            if (p is Int16) return ToByteArray((Int16)p);
            if (p is Int32) return ToByteArray((Int32)p);
            if (p is Int64) return ToByteArray((Int64)p);

            if (p is Byte) return ToByteArray((Byte)p);
            if (p is UInt16) return ToByteArray((UInt16)p);
            if (p is UInt32) return ToByteArray((UInt32)p);
            if (p is UInt64) return ToByteArray((UInt64)p);

            if (p is Char) return ToByteArray((Char)p);
            if (p is Single) return ToByteArray((Single)p);
            if (p is Double) return ToByteArray((Double)p);
            if (p is Boolean) return ToByteArray((Boolean)p);
            if (p is Decimal) return ToByteArray((Decimal)p);

            if (p is DateTime) return ToByteArray((DateTime)p);
            if (p is TimeSpan) return ToByteArray((TimeSpan)p);

            if (p is Stream) return ToByteArray((Stream)p);
            if (p is Guid) return ToByteArray((Guid)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlString) return ToByteArray((SqlString)p);

            if (p is SqlByte) return ToByteArray((SqlByte)p);
            if (p is SqlInt16) return ToByteArray((SqlInt16)p);
            if (p is SqlInt32) return ToByteArray((SqlInt32)p);
            if (p is SqlInt64) return ToByteArray((SqlInt64)p);

            if (p is SqlSingle) return ToByteArray((SqlSingle)p);
            if (p is SqlDouble) return ToByteArray((SqlDouble)p);
            if (p is SqlDecimal) return ToByteArray((SqlDecimal)p);
            if (p is SqlMoney) return ToByteArray((SqlMoney)p);

            if (p is SqlBoolean) return ToByteArray((SqlBoolean)p);
            if (p is SqlDateTime) return ToByteArray((SqlDateTime)p);

            if (p is SqlBinary) return ToByteArray((SqlBinary)p);
#if !(NET_1_1)
            if (p is SqlBytes)    return ToByteArray((SqlBytes)p);
#endif
            if (p is SqlGuid) return ToByteArray((SqlGuid)p);
#endif
            if (p is ByteArray) return ToByteArray((ByteArray)p);

            throw CreateInvalidCastException(p.GetType(), typeof(Byte[]));
        }

        #endregion

        #region Char[]

        // Scalar Types.
        // 
        public static Char[] ToCharArray(String p) { return p == null ? null : p.ToCharArray(); }

        // SqlTypes.
#if! SILVERLIGHT
        public static Char[] ToCharArray(SqlString p) { return p.IsNull ? null : p.Value.ToCharArray(); }
#if !(NET_1_1)
        public static Char[] ToCharArray(SqlChars p)    { return p.IsNull? null: p.Value; }
#endif
#endif
        public static Char[] ToCharArray(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is Char[]) return (Char[])p;

            // Scalar Types.
            //
            if (p is String) return ToCharArray((String)p);

            // SqlTypes.
#if! SILVERLIGHT
            if (p is SqlString) return ToCharArray((SqlString)p);
#if !(NET_1_1)
            if (p is SqlChars)    return ToCharArray((SqlChars)p);
#endif
#endif
            return ToString(p).ToCharArray();
        }

        #endregion

        #region XmlReader

#if! SILVERLIGHT
        // Scalar Types.
        // 
        public static XmlReader ToXmlReader(String p) { return p == null ? null : new XmlTextReader(new StringReader(p)); }

        // SqlTypes.
        public static XmlReader ToXmlReader(SqlString p) { return p.IsNull ? null : new XmlTextReader(new StringReader(p.Value)); }
#if !(NET_1_1)
        public static XmlReader ToXmlReader(SqlXml p)      { return p.IsNull? null: p.CreateReader(); }
		public static XmlReader ToXmlReader(SqlChars p)    { return p.IsNull? null: new XmlTextReader(new StringReader(p.ToSqlString().Value)); }
#endif
        public static XmlReader ToXmlReader(SqlBinary p) { return p.IsNull ? null : new XmlTextReader(new MemoryStream(p.Value)); }
        // Other Types.
        // 
        public static XmlReader ToXmlReader(Stream p) { return p == null ? null : new XmlTextReader(p); }
        public static XmlReader ToXmlReader(TextReader p) { return p == null ? null : new XmlTextReader(p); }
#if! SILVERLIGHT
        public static XmlReader ToXmlReader(XmlDocument p) { return p == null ? null : new XmlTextReader(new StringReader(p.InnerXml)); }
#endif
        public static XmlReader ToXmlReader(Char[] p) { return p == null ? null : new XmlTextReader(new StringReader(new string(p))); }
        public static XmlReader ToXmlReader(Byte[] p) { return p == null ? null : new XmlTextReader(new MemoryStream(p)); }

        public static XmlReader ToXmlReader(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XmlReader) return (XmlReader)p;

            // Scalar Types.
            //
            if (p is String) return ToXmlReader((String)p);

            // SqlTypes.
            //
            if (p is SqlString) return ToXmlReader((SqlString)p);
#if !(NET_1_1)
            if (p is SqlXml)      return ToXmlReader((SqlXml)p);
			if (p is SqlChars)    return ToXmlReader((SqlChars)p);
#endif
            if (p is SqlBinary) return ToXmlReader((SqlBinary)p);

            // Other Types.
            //
            if (p is Stream) return ToXmlReader((Stream)p);
            if (p is TextReader) return ToXmlReader((TextReader)p);
            if (p is XmlDocument) return ToXmlReader((XmlDocument)p);

            if (p is Char[]) return ToXmlReader((Char[])p);
            if (p is Byte[]) return ToXmlReader((Byte[])p);

            throw CreateInvalidCastException(p.GetType(), typeof(XmlReader));
        }
#else
        public static XmlReader ToXmlReader(String p) { return p == null ? null : XmlReader.Create(new StringReader(p)); }
        public static XmlReader ToXmlReader(Stream p) { return p == null ? null : XmlReader.Create(p); }
        public static XmlReader ToXmlReader(TextReader p) { return p == null ? null : XmlReader.Create(p); }

        public static XmlReader ToXmlReader(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XmlReader) return (XmlReader)p;

            // Scalar Types.
            //
            if (p is String) return ToXmlReader((String)p);

            if (p is Stream) return ToXmlReader((Stream)p);
            if (p is TextReader) return ToXmlReader((TextReader)p);

            throw CreateInvalidCastException(p.GetType(), typeof(XmlReader));
        }
#endif
        #endregion

        #region XmlDocument
#if! SILVERLIGHT

        // Scalar Types.
        public static XmlDocument ToXmlDocument(String p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(p);
            return doc;
        }

        // SqlTypes.
        // 
        public static XmlDocument ToXmlDocument(SqlString p) { return p.IsNull ? null : ToXmlDocument(p.Value); }
#if !(NET_1_1)
        public static XmlDocument ToXmlDocument(SqlXml p)      { return p.IsNull? null: ToXmlDocument(p.Value); }
		public static XmlDocument ToXmlDocument(SqlChars p)    { return p.IsNull? null: ToXmlDocument(p.ToSqlString().Value); }
#endif
        public static XmlDocument ToXmlDocument(SqlBinary p) { return p.IsNull ? null : ToXmlDocument(new MemoryStream(p.Value)); }

        // Other Types.
        // 
        public static XmlDocument ToXmlDocument(Stream p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p);
            return doc;
        }

        public static XmlDocument ToXmlDocument(TextReader p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p);
            return doc;
        }

        public static XmlDocument ToXmlDocument(Char[] p) { return p == null ? null : ToXmlDocument(new string(p)); }
        public static XmlDocument ToXmlDocument(Byte[] p) { return p == null ? null : ToXmlDocument(new MemoryStream(p)); }

        public static XmlDocument ToXmlDocument(XmlReader p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p);
            return doc;
        }

        public static XmlDocument ToXmlDocument(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XmlDocument) return (XmlDocument)p;

            // Scalar Types.
            //
            if (p is String) return ToXmlDocument((String)p);

            // SqlTypes.
            //
            if (p is SqlString) return ToXmlDocument((SqlString)p);
#if !(NET_1_1)
            if (p is SqlXml)      return ToXmlDocument((SqlXml)p);
			if (p is SqlChars)    return ToXmlDocument((SqlChars)p);
#endif
            if (p is SqlBinary) return ToXmlDocument((SqlBinary)p);

            // Other Types.
            //
            if (p is Stream) return ToXmlDocument((Stream)p);
            if (p is TextReader) return ToXmlDocument((TextReader)p);
            if (p is XmlReader) return ToXmlDocument((XmlReader)p);

            if (p is Char[]) return ToXmlDocument((Char[])p);
            if (p is Byte[]) return ToXmlDocument((Byte[])p);

            throw CreateInvalidCastException(p.GetType(), typeof(XmlDocument));
        }
#endif
        #endregion

        #endregion

        private static InvalidCastException CreateInvalidCastException(Type originalType, Type conversionType)
        {
            return new InvalidCastException(string.Format("Invalid cast from {0} to {1}", originalType.FullName, conversionType.FullName));
        }
    }
}
