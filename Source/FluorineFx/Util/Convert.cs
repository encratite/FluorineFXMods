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
#if !NET_1_1 && !NET_2_0
using System.Xml.Linq;
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
        /// <returns>The String equivalent of the 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(SByte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The String equivalent of the 16-bit signed integer value.</returns>
        public static String ToString(Int16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The String equivalent of the 32-bit signed integer value.</returns>
        public static String ToString(Int32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The String equivalent of the 64-bit signed integer value.</returns>
        public static String ToString(Int64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 8-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 8-bit unsigned integer value.</returns>
        public static String ToString(Byte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The String equivalent of the 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The String equivalent of the single-precision floating point number.</returns>
        public static String ToString(Single value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The String equivalent of the double-precision floating point number.</returns>
        public static String ToString(Double value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <returns>The String equivalent of the Boolean.</returns>
        public static String ToString(Boolean value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The String equivalent of the Decimal number.</returns>
        public static String ToString(Decimal value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The String equivalent of the Unicode character.</returns>
        public static String ToString(Char value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent String representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The String equivalent of the TimeSpan.</returns>
        public static String ToString(TimeSpan value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent String representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The String equivalent of the DateTime.</returns>
        public static String ToString(DateTime value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The String equivalent of the Guid.</returns>
        public static String ToString(Guid value) { return value.ToString(); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(SByte? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 16-bit signed integer value.</returns>
        public static String ToString(Int16? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 32-bit signed integer value.</returns>
        public static String ToString(Int32? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The String equivalent of the nullable 64-bit signed integer value.</returns>
        public static String ToString(Int64? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer  to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 8-bit unsigned integer value.</returns>
        public static String ToString(Byte? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt16? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt32? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The String equivalent of the nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static String ToString(UInt64? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The String equivalent of the nullable single-precision floating point number.</returns>
        public static String ToString(Single? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The String equivalent of the nullable double-precision floating point number.</returns>
        public static String ToString(Double? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Boolean value.</param>
        /// <returns>The String equivalent of the nullable Boolean value.</returns>
        public static String ToString(Boolean? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The String equivalent of the nullable Decimal number.</returns>
        public static String ToString(Decimal? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The String equivalent of the nullable Unicode character.</returns>
        public static String ToString(Char? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The String equivalent of the nullable TimeSpan.</returns>
        public static String ToString(TimeSpan? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The String equivalent of the nullable DateTime.</returns>
        public static String ToString(DateTime? value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent String representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The String equivalent of the nullable Guid.</returns>
        public static String ToString(Guid? value) { return value.ToString(); }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The String equivalent of the SqlString.</returns>        
        public static String ToString(SqlString value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The String equivalent of the SqlByte.</returns>        
        public static String ToString(SqlByte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The String equivalent of SqlInt16.</returns>        
        public static String ToString(SqlInt16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The String equivalent of the SqlInt32.</returns>        
        public static String ToString(SqlInt32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The String equivalent of the SqlInt64.</returns>        
        public static String ToString(SqlInt64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The String equivalent of the SqlSingle.</returns>        
        public static String ToString(SqlSingle value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The String equivalent of the SqlDouble.</returns>        
        public static String ToString(SqlDouble value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The String equivalent of the SqlDecimal.</returns>        
        public static String ToString(SqlDecimal value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The String equivalent of the SqlMoney.</returns>        
        public static String ToString(SqlMoney value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The String equivalent of the SqlBoolean.</returns>        
        public static String ToString(SqlBoolean value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The String equivalent of the SqlGuid.</returns>        
        public static String ToString(SqlGuid value) { return value.ToString(); }
#if !(NET_1_1)
        /// <summary>
        /// Converts the value of the specified SqlChars to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlChars.</param>
        /// <returns>The String equivalent of the SqlChars.</returns>        
        public static String ToString(SqlChars value) { return value.IsNull ? null : value.ToSqlString().Value; }
        /// <summary>
        /// Converts the value of the specified SqlXml to its equivalent String representation.
        /// </summary>
        /// <param name="value">An SqlXml.</param>
        /// <returns>The String equivalent of the SqlXml.</returns>        
        public static String ToString(SqlXml value) { return value.IsNull ? null : value.Value; }
#endif
#endif
        /// <summary>
        /// Converts the value of the specified Type to its equivalent String representation.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The String equivalent of the Type.</returns>
        public static String ToString(Type value) { return value == null ? null : value.FullName; }
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified XmlDocument to its equivalent String representation.
        /// </summary>
        /// <param name="value">An XmlDocument.</param>
        /// <returns>The String equivalent of the XmlDocument.</returns>
        public static String ToString(XmlDocument value) { return value == null ? null : value.InnerXml; }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent String representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The String equivalent of the Object.</returns>
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
        /// <param name="value">A Unicode character.</param>
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
        /// <param name="value">A Unicode character.</param>
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
        /// <param name="value">A Unicode character.</param>
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
        /// <param name="value">A Unicode character.</param>
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
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32 ToUInt32(UInt16? value) { return value.HasValue ? checked((UInt32)value.Value) : 0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
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
        /// <returns>The equivalent Unicode character.</returns>
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
        /// <summary>
        /// Checks whether the value of the specified Object can be converted to a Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>Returns true if the specified Object can be converted to a Unicode character.</returns>
        public static bool CanConvertToChar(object value)
        {
            if (value == null || value is DBNull) return true;

            if (value is Char) return true;
            // Scalar Types.
            if (value is String) return (value == null || (value as String).Length == 1);
            if (value is Boolean) return true;

            if (value is IConvertible)
            {
                try
                {
                    ((IConvertible)value).ToChar(null);
                    return true;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
            return false;
        }


        #endregion

        #region Single

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(String value) { return value == null ? 0.0f : Single.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(SByte value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int16 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int32 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int64 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Byte value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(UInt16 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(UInt32 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(UInt64 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Double value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Decimal value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Boolean value) { return value ? 1.0f : 0.0f; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Char value) { return checked((Single)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Single? value) { return value.HasValue ? value.Value : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
		[CLSCompliant(false)]
        public static Single ToSingle(SByte? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int16? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int32? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Int64? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Byte? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(UInt16? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(UInt32? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single ToSingle(UInt64? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Double? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Decimal? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Char? value) { return value.HasValue ? checked((Single)value.Value) : 0.0f; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(Boolean? value) { return (value.HasValue && value.Value) ? 1.0f : 0.0f; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlSingle value) { return value.IsNull ? 0.0f : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlString value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlByte value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlInt16 value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlInt32 value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlInt64 value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlDouble value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlDecimal value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlMoney value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(SqlBoolean value) { return value.IsNull ? 0.0f : ToSingle(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent single-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent single-precision floating point number.</returns>
        public static Single ToSingle(object value)
        {
            if (value == null || value is DBNull) return 0.0f;

            if (value is Single) return (Single)value;

            // Scalar Types.
            //
            if (value is String) return ToSingle((String)value);

            if (value is Boolean) return ToSingle((Boolean)value);
            if (value is Char) return ToSingle((Char)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlSingle) return ToSingle((SqlSingle)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToSingle(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Single));
        }

        #endregion

        #region Double

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(String value) { return value == null ? 0.0 : Double.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(SByte value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int16 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int32 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int64 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Byte value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(UInt16 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(UInt32 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(UInt64 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Single value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Decimal value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Boolean value) { return value ? 1.0 : 0.0; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Char value) { return checked((Double)value); }
        public static Double ToDouble(DateTime value) { return (value - DateTime.MinValue).TotalDays; }
        public static Double ToDouble(TimeSpan value) { return value.TotalDays; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Double? value) { return value.HasValue ? value.Value : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
		[CLSCompliant(false)]
        public static Double ToDouble(SByte? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int16? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int32? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Int64? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Byte? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(UInt16? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(UInt32? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double ToDouble(UInt64? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Single? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Decimal? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Char? value) { return value.HasValue ? checked((Double)value.Value) : 0.0; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(Boolean? value) { return (value.HasValue && value.Value) ? 1.0 : 0.0; }
        public static Double ToDouble(DateTime? value) { return value.HasValue ? (value.Value - DateTime.MinValue).TotalDays : 0.0; }
        public static Double ToDouble(TimeSpan? value) { return value.HasValue ? value.Value.TotalDays : 0.0; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlDouble value) { return value.IsNull ? 0.0 : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlString value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlByte value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlInt16 value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlInt32 value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlInt64 value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlSingle value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlDecimal value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlMoney value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlBoolean value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(SqlDateTime value) { return value.IsNull ? 0.0 : ToDouble(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent double-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent double-precision floating point number.</returns>
        public static Double ToDouble(object value)
        {
            if (value == null || value is DBNull) return 0.0;

            if (value is Double) return (Double)value;

            // Scalar Types.
            //
            if (value is String) return ToDouble((String)value);

            if (value is Boolean) return ToDouble((Boolean)value);
            if (value is Char) return ToDouble((Char)value);
            if (value is DateTime) return ToDouble((DateTime)value);
            if (value is TimeSpan) return ToDouble((TimeSpan)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlDouble) return ToDouble((SqlDouble)value);
            if (value is SqlDateTime) return ToDouble((SqlDateTime)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToDouble(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Double));
        }

        #endregion

        #region Boolean

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(String value) { return value == null ? false : Boolean.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(SByte value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int16 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int32 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int64 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Byte value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt16 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt32 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt64 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Single value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Double value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Decimal value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Char value)
        {
            switch (value)
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

        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Boolean? value) { return value.HasValue ? value.Value : false; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
		[CLSCompliant(false)]
        public static Boolean ToBoolean(SByte? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int16? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int32? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Int64? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Byte? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt16? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt32? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean ToBoolean(UInt64? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Single? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Double? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Decimal? value) { return value.HasValue ? value.Value != 0 : false; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(Char? value) { return value.HasValue ? ToBoolean(value.Value) : false; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlBoolean value) { return value.IsNull ? false : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlString value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlByte value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlInt16 value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlInt32 value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent Boolean valuer.</returns>
        public static Boolean ToBoolean(SqlInt64 value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlSingle value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlDouble value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlDecimal value) { return value.IsNull ? false : ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(SqlMoney value) { return value.IsNull ? false : ToBoolean(value.Value); }
#endif

        /// <summary>
        /// Converts the value of the specified Object to its equivalent Boolean value.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Boolean value.</returns>
        public static Boolean ToBoolean(object value)
        {
            if (value == null || value is DBNull) return false;

            if (value is Boolean) return (Boolean)value;

            // Scalar Types.
            //
            if (value is String) return ToBoolean((String)value);

            if (value is Char) return ToBoolean((Char)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlBoolean) return ToBoolean((SqlBoolean)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToBoolean(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Boolean));
        }

        #endregion

        #region Decimal

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(String value) { return value == null ? 0.0m : Decimal.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(SByte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Byte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Single value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Double value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Boolean value) { return value ? 1.0m : 0.0m; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Char value) { return checked((Decimal)value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Decimal? value) { return value.HasValue ? value.Value : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(SByte? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int16? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int32? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Int64? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Byte? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt16? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt32? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal ToDecimal(UInt64? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Single? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Double? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Char? value) { return value.HasValue ? checked((Decimal)value.Value) : 0.0m; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(Boolean? value) { return (value.HasValue && value.Value) ? 1.0m : 0.0m; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlDecimal value) { return value.IsNull ? 0.0m : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlMoney value) { return value.IsNull ? 0.0m : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlString value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlByte value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlInt16 value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlInt32 value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlInt64 value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlSingle value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlDouble value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(SqlBoolean value) { return value.IsNull ? 0.0m : ToDecimal(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent Decimal number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Decimal number.</returns>
        public static Decimal ToDecimal(object value)
        {
            if (value == null || value is DBNull) return 0.0m;

            if (value is Decimal) return (Decimal)value;

            // Scalar Types.
            //
            if (value is String) return ToDecimal((String)value);

            if (value is Boolean) return ToDecimal((Boolean)value);
            if (value is Char) return ToDecimal((Char)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlDecimal) return ToDecimal((SqlDecimal)value);
            if (value is SqlMoney) return ToDecimal((SqlMoney)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToDecimal(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Decimal));
        }

        #endregion

        #region DateTime

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(String value) { return value == null ? DateTime.MinValue : DateTime.Parse(value); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(TimeSpan value) { return DateTime.MinValue + value; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Int64 value) { return DateTime.MinValue + TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Double value) { return DateTime.MinValue + TimeSpan.FromDays(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(DateTime? value) { return value.HasValue ? value.Value : DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(TimeSpan? value) { return value.HasValue ? DateTime.MinValue + value.Value : DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Int64? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromTicks(value.Value) : DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent DateTime.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(Double? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromDays(value.Value) : DateTime.MinValue; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent DateTime.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(SqlDateTime value) { return value.IsNull ? DateTime.MinValue : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent DateTime.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(SqlString value) { return value.IsNull ? DateTime.MinValue : ToDateTime(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent DateTime.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(SqlInt64 value) { return value.IsNull ? DateTime.MinValue : DateTime.MinValue + TimeSpan.FromTicks(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent DateTime.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(SqlDouble value) { return value.IsNull ? DateTime.MinValue : DateTime.MinValue + TimeSpan.FromDays(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent DateTime.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent DateTime.</returns>
        public static DateTime ToDateTime(object value)
        {
            if (value == null || value is DBNull) return DateTime.MinValue;

            if (value is DateTime) return (DateTime)value;

            // Scalar Types.
            //
            if (value is String) return ToDateTime((String)value);
            if (value is TimeSpan) return ToDateTime((TimeSpan)value);
            if (value is Int64) return ToDateTime((Int64)value);
            if (value is Double) return ToDateTime((Double)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlDateTime) return ToDateTime((SqlDateTime)value);
            if (value is SqlString) return ToDateTime((SqlString)value);
            if (value is SqlInt64) return ToDateTime((SqlInt64)value);
            if (value is SqlDouble) return ToDateTime((SqlDouble)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToDateTime(null);

            throw CreateInvalidCastException(value.GetType(), typeof(DateTime));
        }

        #endregion

        #region TimeSpan

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(String value) { return value == null ? TimeSpan.MinValue : TimeSpan.Parse(value); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(DateTime value) { return value - DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Int64 value) { return TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Double value) { return TimeSpan.FromDays(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(TimeSpan? value) { return value.HasValue ? value.Value : TimeSpan.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(DateTime? value) { return value.HasValue ? value.Value - DateTime.MinValue : TimeSpan.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Int64? value) { return value.HasValue ? TimeSpan.FromTicks(value.Value) : TimeSpan.MinValue; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(Double? value) { return value.HasValue ? TimeSpan.FromDays(value.Value) : TimeSpan.MinValue; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(SqlString value) { return value.IsNull ? TimeSpan.MinValue : TimeSpan.Parse(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(SqlDateTime value) { return value.IsNull ? TimeSpan.MinValue : value.Value - DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(SqlInt64 value) { return value.IsNull ? TimeSpan.MinValue : TimeSpan.FromTicks(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(SqlDouble value) { return value.IsNull ? TimeSpan.MinValue : TimeSpan.FromDays(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent TimeSpan.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent TimeSpan.</returns>
        public static TimeSpan ToTimeSpan(object value)
        {
            if (value == null || value is DBNull) return TimeSpan.MinValue;

            if (value is TimeSpan) return (TimeSpan)value;

            // Scalar Types.
            //
            if (value is String) return ToTimeSpan((String)value);
            if (value is DateTime) return ToTimeSpan((DateTime)value);
            if (value is Int64) return ToTimeSpan((Int64)value);
            if (value is Double) return ToTimeSpan((Double)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlString) return ToTimeSpan((SqlString)value);
            if (value is SqlDateTime) return ToTimeSpan((SqlDateTime)value);
            if (value is SqlInt64) return ToTimeSpan((SqlInt64)value);
            if (value is SqlDouble) return ToTimeSpan((SqlDouble)value);
#endif
            throw CreateInvalidCastException(value.GetType(), typeof(TimeSpan));
        }

        #endregion

        #region Guid

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent Guid.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(String value) { return value == null ? Guid.Empty : new Guid(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent Guid.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(Guid? value) { return value.HasValue ? value.Value : Guid.Empty; }

#endif
        // SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent Guid.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(SqlGuid value) { return value.IsNull ? Guid.Empty : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent Guid.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(SqlString value) { return value.IsNull ? Guid.Empty : new Guid(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent Guid.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(SqlBinary value) { return value.IsNull ? Guid.Empty : value.ToSqlGuid().Value; }
#endif
        // Other Types.

        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent Guid.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(Byte[] value) { return value == null ? Guid.Empty : new Guid(value); }
        /// <summary>
        /// Converts the value of the specified Type to its equivalent Guid.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(Type value) { return value == null ? Guid.Empty : value.GUID; }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent Guid.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent Guid.</returns>
        public static Guid ToGuid(object value)
        {
            if (value == null || value is DBNull) return Guid.Empty;

            if (value is Guid) return (Guid)value;

            // Scalar Types.
            //
            if (value is String) return ToGuid((String)value);

            // SqlTypes.
#if! SILVERLIGHT
            if (value is SqlGuid) return ToGuid((SqlGuid)value);
            if (value is SqlString) return ToGuid((SqlString)value);
            if (value is SqlBinary) return ToGuid((SqlBinary)value);
#endif
            // Other Types.
            //
            if (value is Byte[]) return ToGuid((Byte[])value);
            if (value is Type) return ToGuid((Type)value);

            throw CreateInvalidCastException(value.GetType(), typeof(Guid));
        }

        #endregion

        #endregion

#if !(NET_1_1)
        #region Nullable Types

        #region SByte?

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SByte value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(String value) { return value == null ? null : (SByte?)SByte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Int16 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Int32 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Int64 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Byte value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(UInt16 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(UInt32 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(UInt64 value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Single value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Double value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Decimal value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Char value) { return checked((SByte?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Boolean value) { return (SByte?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Int16? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Int32? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Int64? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Byte? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(UInt16? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(UInt32? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(UInt64? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Single? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Double? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
		[CLSCompliant(false)]
        public static SByte? ToNullableSByte(Decimal? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Char? value) { return value.HasValue ? checked((SByte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(Boolean? value) { return value.HasValue ? (SByte?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlString value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlByte value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlInt16 value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlInt32 value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlInt64 value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlSingle value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlDouble value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlDecimal value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlMoney value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(SqlBoolean value) { return value.IsNull ? null : ToNullableSByte(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 8-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SByte? ToNullableSByte(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
            if (value is SByte) return ToNullableSByte((SByte)value);
            if (value is String) return ToNullableSByte((String)value);

            if (value is Char) return ToNullableSByte((Char)value);
            if (value is Boolean) return ToNullableSByte((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToSByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(SByte?));
		}

        #endregion

        #region Int16?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int16 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(String value) { return value == null ? null : (Int16?)Int16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(SByte value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int32 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int64 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Byte value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(UInt16 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(UInt32 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(UInt64 value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Single value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Double value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Decimal value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Char value) { return checked((Int16?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Boolean value) { return (Int16?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(SByte? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int32? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Int64? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Byte? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(UInt16? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(UInt32? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int16? ToNullableInt16(UInt64? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Single? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Double? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Decimal? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Char? value) { return value.HasValue ? checked((Int16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(Boolean? value) { return value.HasValue ? (Int16?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlInt16 value) { return value.IsNull ? null : (Int16?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlString value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlByte value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlInt32 value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlInt64 value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlSingle value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlDouble value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlDecimal value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlMoney value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(SqlBoolean value) { return value.IsNull ? null : ToNullableInt16(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 16-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 16-bit signed integer value.</returns>
        public static Int16? ToNullableInt16(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Int16) return ToNullableInt16((Int16)value);
            if (value is String) return ToNullableInt16((String)value);

            if (value is Char) return ToNullableInt16((Char)value);
            if (value is Boolean) return ToNullableInt16((Boolean)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlInt16) return ToNullableInt16((SqlInt16)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int16?));
		}

        #endregion

        #region Int32?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int32 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(String value) { return value == null ? null : (Int32?)Int32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
		[CLSCompliant(false)]
        public static Int32? ToNullableInt32(SByte value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int16 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int64 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Byte value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(UInt16 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(UInt32 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(UInt64 value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Single value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Double value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Decimal value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Char value) { return checked((Int32?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Boolean value) { return value ? 1 : 0; }

#if !(NET_1_1)
        // Nullable Types.
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(SByte? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int16? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Int64? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Byte? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(UInt16? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(UInt32? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int32? ToNullableInt32(UInt64? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Single? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Double? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Decimal? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Char? value) { return value.HasValue ? checked((Int32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(Boolean? value) { return value.HasValue ? (Int32?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlInt32 value) { return value.IsNull ? null : (Int32?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlString value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlByte value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlInt16 value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlInt64 value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlSingle value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlDouble value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlDecimal value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlMoney value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(SqlBoolean value) { return value.IsNull ? null : ToNullableInt32(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 32-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 32-bit signed integer value.</returns>
        public static Int32? ToNullableInt32(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Int32) return ToNullableInt32((Int32)value);
            if (value is String) return ToNullableInt32((String)value);

            if (value is Char) return ToNullableInt32((Char)value);
            if (value is Boolean) return ToNullableInt32((Boolean)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlInt32) return ToNullableInt32((SqlInt32)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int32?));
		}

        #endregion

        #region Int64?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int64 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(String value) { return value == null ? null : (Int64?)Int64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
		[CLSCompliant(false)]
        public static Int64? ToNullableInt64(SByte value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int16 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int32 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Byte value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(UInt16 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(UInt32 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(UInt64 value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Single value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Double value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Decimal value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Char value) { return checked((Int64?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(DateTime value) { return (value - DateTime.MinValue).Ticks; }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(TimeSpan value) { return value.Ticks; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(SByte? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int16? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Int32? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Byte? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(UInt16? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(UInt32? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static Int64? ToNullableInt64(UInt64? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Single? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Double? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Decimal? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Char? value) { return value.HasValue ? checked((Int64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(Boolean? value) { return value.HasValue ? (Int64?)(value.Value ? 1 : 0) : null; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(DateTime? value) { return value.HasValue ? (Int64?)(value.Value - DateTime.MinValue).Ticks : null; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(TimeSpan? value) { return value.HasValue ? (Int64?)value.Value.Ticks : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlInt64 value) { return value.IsNull ? null : (Int64?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlString value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlByte value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlInt16 value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlInt32 value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlSingle value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlDouble value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlDecimal value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlMoney value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlBoolean value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(SqlDateTime value) { return value.IsNull ? null : ToNullableInt64(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 64-bit signed integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 64-bit signed integer value.</returns>
        public static Int64? ToNullableInt64(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Int64) return ToNullableInt64((Int64)value);
            if (value is String) return ToNullableInt64((String)value);

            if (value is Char) return ToNullableInt64((Char)value);
            if (value is Boolean) return ToNullableInt64((Boolean)value);
            if (value is DateTime) return ToNullableInt64((DateTime)value);
            if (value is TimeSpan) return ToNullableInt64((TimeSpan)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlInt64) return ToNullableInt64((SqlInt64)value);
            if (value is SqlDateTime) return ToNullableInt64((SqlDateTime)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Int64?));
		}

        #endregion

        #region Byte?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Byte value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(String value) { return value == null ? null : (Byte?)Byte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static Byte? ToNullableByte(SByte value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int16 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int32 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int64 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte? ToNullableByte(UInt16 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte? ToNullableByte(UInt32 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte? ToNullableByte(UInt64 value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Single value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Double value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Decimal value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Char value) { return checked((Byte?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Boolean value) { return (Byte?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte? ToNullableByte(SByte? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int16? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int32? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Int64? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static Byte? ToNullableByte(UInt16? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte? ToNullableByte(UInt32? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static Byte? ToNullableByte(UInt64? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Single? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Double? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Decimal? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Char? value) { return value.HasValue ? checked((Byte?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(Boolean? value) { return value.HasValue ? (Byte?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlByte value) { return value.IsNull ? null : (Byte?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlString value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlInt16 value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlInt32 value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlInt64 value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlSingle value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlDouble value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlDecimal value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlMoney value) { return value.IsNull ? null : ToNullableByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(SqlBoolean value) { return value.IsNull ? null : ToNullableByte(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 8-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 8-bit unsigned integer value.</returns>
        public static Byte? ToNullableByte(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Byte) return ToNullableByte((Byte)value);
            if (value is String) return ToNullableByte((String)value);

            if (value is Char) return ToNullableByte((Char)value);
            if (value is Boolean) return ToNullableByte((Boolean)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlByte) return ToNullableByte((SqlByte)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToByte(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Byte?));
		}

        #endregion

        #region UInt16?

		// Scalar Types.
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(UInt16 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(String value) { return value == null ? null : (UInt16?)UInt16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SByte value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Int16 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Int32 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Int64 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Byte value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(UInt32 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(UInt64 value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Single value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Double value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Decimal value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Char value) { return checked((UInt16?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Boolean value) { return (UInt16?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SByte? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Int16? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Int32? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Int64? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Byte? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(UInt32? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(UInt64? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Single? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Double? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Decimal? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Char? value) { return value.HasValue ? checked((UInt16?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(Boolean? value) { return value.HasValue ? (UInt16?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlString value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlByte value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlInt16 value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlInt32 value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlInt64 value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlSingle value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlDouble value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlDecimal value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlMoney value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(SqlBoolean value) { return value.IsNull ? null : ToNullableUInt16(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt16? ToNullableUInt16(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is UInt16) return ToNullableUInt16((UInt16)value);
            if (value is String) return ToNullableUInt16((String)value);

            if (value is Char) return ToNullableUInt16((Char)value);
            if (value is Boolean) return ToNullableUInt16((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt16(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt16?));
		}

        #endregion

        #region UInt32?

		// Scalar Types.
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(UInt32 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(String value) { return value == null ? null : (UInt32?)UInt32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SByte value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Int16 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Int32 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Int64 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Byte value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(UInt16 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(UInt64 value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Single value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Double value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Decimal value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Char value) { return checked((UInt32?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Boolean value) { return (UInt32?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SByte? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Int16? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Int32? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Int64? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Byte? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(UInt16? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(UInt64? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Single? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Double? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Decimal? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Char? value) { return value.HasValue ? checked((UInt32?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(Boolean? value) { return value.HasValue ? (UInt32?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlString value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlByte value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlInt16 value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlInt32 value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlInt64 value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlSingle value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlDouble value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlDecimal value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent 32-bit nullable unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlMoney value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(SqlBoolean value) { return value.IsNull ? null : ToNullableUInt32(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 32-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt32? ToNullableUInt32(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is UInt32) return ToNullableUInt32((UInt32)value);
            if (value is String) return ToNullableUInt32((String)value);

            if (value is Char) return ToNullableUInt32((Char)value);
            if (value is Boolean) return ToNullableUInt32((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt32(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt32?));
		}

        #endregion

        #region UInt64?

		// Scalar Types.
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(UInt64 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(String value) { return value == null ? null : (UInt64?)UInt64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SByte value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Int16 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Int32 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Int64 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Byte value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(UInt16 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(UInt32 value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Single value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Double value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Decimal value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Char value) { return checked((UInt64?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Boolean value) { return (UInt64?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SByte? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Int16? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Int32? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Int64? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Byte? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(UInt16? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(UInt32? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Single? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Double? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Decimal? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Char? value) { return value.HasValue ? checked((UInt64?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(Boolean? value) { return value.HasValue ? (UInt64?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlString value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlByte value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlInt16 value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlInt32 value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlInt64 value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlSingle value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlDouble value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlDecimal value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlMoney value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
		[CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(SqlBoolean value) { return value.IsNull ? null : ToNullableUInt64(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable 64-bit unsigned integer.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static UInt64? ToNullableUInt64(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is UInt64) return ToNullableUInt64((UInt64)value);
            if (value is String) return ToNullableUInt64((String)value);

            if (value is Char) return ToNullableUInt64((Char)value);
            if (value is Boolean) return ToNullableUInt64((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToUInt64(null);

            throw CreateInvalidCastException(value.GetType(), typeof(UInt64?));
		}

        #endregion

        #region Char?

		// Scalar Types.
        /// <summary>
        /// Converts a Unicode character to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        public static Char? ToNullableChar(Char value) { return value; }
        /// <summary>
        /// Converts the first character of the specified String to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        public static Char? ToNullableChar(String value)      
        { 
#if !(NET_1_1)
            Char result;
            if (Char.TryParse(value, out result))
                return result;
            return (Char)0;
#else
            return value == null? null: (Char?)Char.Parse(value); 
#endif
        }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(SByte value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int16 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int32 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int64 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Byte value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(UInt16 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(UInt32 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(UInt64 value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Single value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Double value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Decimal value) { return checked((Char?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Boolean value) { return (Char?)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(SByte? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int16? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int32? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Int64? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Byte? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(UInt16? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(UInt32? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        [CLSCompliant(false)]
        public static Char? ToNullableChar(UInt64? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Single? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Double? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Decimal? value) { return value.HasValue ? checked((Char?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to a nullable Unicode character.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(Boolean? value) { return value.HasValue ? (Char?)(value.Value ? 1 : 0) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlString value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlByte value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlInt16 value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlInt32 value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlInt64 value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlSingle value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlDouble value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlDecimal value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlMoney value) { return value.IsNull ? null : ToNullableChar(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The nullable Unicode character value.</returns>
        public static Char? ToNullableChar(SqlBoolean value) { return value.IsNull ? null : ToNullableChar(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Unicode character value.</returns>
        public static Char? ToNullableChar(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Char) return ToNullableChar((Char)value);
            if (value is String) return ToNullableChar((String)value);

            if (value is Boolean) return ToNullableChar((Boolean)value);

            if (value is IConvertible) return ((IConvertible)value).ToChar(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Char?));
		}
        /// <summary>
        /// Checks whether the value of the specified Object can be converted to a nullable Unicode character.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>Returns true if the specified Object can be converted to a nullable Unicode character.</returns>
        public static bool CanConvertToNullableChar(object value)
        {
            if (value == null || value is DBNull) return true;

            // Scalar Types.
            //
            if (value is Char) return true;
            if (value is String) return (value == null || (value as String).Length == 1);

            if (value is Boolean) return true;

            if (value is IConvertible)
            {
                try
                {
                    ((IConvertible)value).ToChar(null);
                    return true;
                }
                catch (InvalidCastException)
                {
                    return false;
                }
            }
            return false;
        }


        #endregion

        #region Single?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Single value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(String value) { return value == null ? null : (Single?)Single.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(SByte value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int16 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int32 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int64 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Byte value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(UInt16 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(UInt32 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(UInt64 value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Double value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Decimal value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Char value) { return checked((Single?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Boolean value) { return value ? 1.0f : 0.0f; }

#if !(NET_1_1)
        // Nullable Types.
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(SByte? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int16? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int32? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Int64? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Byte? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(UInt16? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(UInt32? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Single? ToNullableSingle(UInt64? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Double? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Decimal? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Char? value) { return value.HasValue ? checked((Single?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(Boolean? value) { return value.HasValue ? (Single?)(value.Value ? 1.0f : 0.0f) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlSingle value) { return value.IsNull ? null : (Single?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlString value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlByte value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlInt16 value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlInt32 value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlInt64 value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlDouble value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlDecimal value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlMoney value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(SqlBoolean value) { return value.IsNull ? null : ToNullableSingle(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable single-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable single-precision floating point number.</returns>
        public static Single? ToNullableSingle(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Single) return ToNullableSingle((Single)value);
            if (value is String) return ToNullableSingle((String)value);

            if (value is Char) return ToNullableSingle((Char)value);
            if (value is Boolean) return ToNullableSingle((Boolean)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlSingle) return ToNullableSingle((SqlSingle)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToSingle(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Single?));
		}

        #endregion

        #region Double?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Double value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(String value) { return value == null ? null : (Double?)Double.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
		[CLSCompliant(false)]
        public static Double? ToNullableDouble(SByte value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int16 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int32 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int64 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Byte value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(UInt16 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(UInt32 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(UInt64 value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Single value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Decimal value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Char value) { return checked((Double?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Boolean value) { return value ? 1.0 : 0.0; }
        public static Double? ToNullableDouble(DateTime value) { return (value - DateTime.MinValue).TotalDays; }
        public static Double? ToNullableDouble(TimeSpan value) { return value.TotalDays; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(SByte? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int16? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int32? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Int64? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Byte? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(UInt16? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(UInt32? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        [CLSCompliant(false)]
        public static Double? ToNullableDouble(UInt64? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Single? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Decimal? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Char? value) { return value.HasValue ? checked((Double?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(Boolean? value) { return value.HasValue ? (Double?)(value.Value ? 1.0 : 0.0) : null; }
        public static Double? ToNullableDouble(DateTime? value) { return value.HasValue ? (Double?)(value.Value - DateTime.MinValue).TotalDays : null; }
        public static Double? ToNullableDouble(TimeSpan? value) { return value.HasValue ? (Double?)value.Value.TotalDays : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlDouble value) { return value.IsNull ? null : (Double?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlString value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlByte value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlInt16 value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlInt32 value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlInt64 value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlSingle value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlDecimal value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlMoney value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlBoolean value) { return value.IsNull ? null : ToNullableDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(SqlDateTime value) { return value.IsNull ? null : (Double?)(value.Value - DateTime.MinValue).TotalDays; }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable double-precision floating point number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable double-precision floating point number.</returns>
        public static Double? ToNullableDouble(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Double) return ToNullableDouble((Double)value);
            if (value is String) return ToNullableDouble((String)value);

            if (value is Char) return ToNullableDouble((Char)value);
            if (value is Boolean) return ToNullableDouble((Boolean)value);
            if (value is DateTime) return ToNullableDouble((DateTime)value);
            if (value is TimeSpan) return ToNullableDouble((TimeSpan)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlDouble) return ToNullableDouble((SqlDouble)value);
            if (value is SqlDateTime) return ToNullableDouble((SqlDateTime)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToDouble(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Double?));
		}

        #endregion

        #region Boolean?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified Boolean value to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Boolean value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(String value) { return value == null ? null : (Boolean?)Boolean.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
		[CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(SByte value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int16 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int32 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int64 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Byte value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(UInt16 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(UInt32 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(UInt64 value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Single value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Double value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Decimal value) { return ToBoolean(value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Char value) { return ToBoolean(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(SByte? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int16? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int32? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Int64? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Byte? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(UInt16? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(UInt32? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        [CLSCompliant(false)]
        public static Boolean? ToNullableBoolean(UInt64? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Single? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Double? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Decimal? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(Char? value) { return value.HasValue ? (Boolean?)ToBoolean(value.Value) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlBoolean value) { return value.IsNull ? null : (Boolean?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlString value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlByte value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlInt16 value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlInt32 value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable Boolean valuer.</returns>
        public static Boolean? ToNullableBoolean(SqlInt64 value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlSingle value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlDouble value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlDecimal value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(SqlMoney value) { return value.IsNull ? null : (Boolean?)ToBoolean(value.Value); }
#endif

        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Boolean value.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Boolean value.</returns>
        public static Boolean? ToNullableBoolean(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Boolean) return ToNullableBoolean((Boolean)value);
            if (value is String) return ToNullableBoolean((String)value);

            if (value is Char) return ToNullableBoolean((Char)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlBoolean) return ToNullableBoolean((SqlBoolean)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToBoolean(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Boolean?));
		}

        #endregion

        #region Decimal?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Decimal value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(String value) { return value == null ? null : (Decimal?)Decimal.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(SByte value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int16 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int32 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int64 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Byte value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(UInt16 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(UInt32 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(UInt64 value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Single value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Double value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Char value) { return checked((Decimal?)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Boolean value) { return value ? 1.0m : 0.0m; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(SByte? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int16? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int32? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Int64? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Byte? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(UInt16? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(UInt32? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        [CLSCompliant(false)]
        public static Decimal? ToNullableDecimal(UInt64? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Single? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Double? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Char? value) { return value.HasValue ? checked((Decimal?)value.Value) : null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(Boolean? value) { return value.HasValue ? (Decimal?)(value.Value ? 1.0m : 0.0m) : null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlDecimal value) { return value.IsNull ? null : (Decimal?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlMoney value) { return value.IsNull ? null : (Decimal?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlString value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlByte value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlInt16 value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlInt32 value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlInt64 value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlSingle value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlDouble value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(SqlBoolean value) { return value.IsNull ? null : ToNullableDecimal(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Decimal number.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Decimal number.</returns>
        public static Decimal? ToNullableDecimal(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is double && Double.IsNaN((double)value)) return null;
            if (value is Decimal) return ToNullableDecimal((Decimal)value);
            if (value is String) return ToNullableDecimal((String)value);

            if (value is Char) return ToNullableDecimal((Char)value);
            if (value is Boolean) return ToNullableDecimal((Boolean)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlDecimal) return ToNullableDecimal((SqlDecimal)value);
            if (value is SqlMoney) return ToNullableDecimal((SqlMoney)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToDecimal(null);

            throw CreateInvalidCastException(value.GetType(), typeof(Decimal?));
		}

        #endregion

        #region DateTime?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(DateTime value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(String value) { return value == null ? null : (DateTime?)DateTime.Parse(value); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(TimeSpan value) { return DateTime.MinValue + value; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Int64 value) { return DateTime.MinValue + TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Double value) { return DateTime.MinValue + TimeSpan.FromDays(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(TimeSpan? value) { return value.HasValue ? DateTime.MinValue + value.Value : (DateTime?)null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Int64? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromTicks(value.Value) : (DateTime?)null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(Double? value) { return value.HasValue ? DateTime.MinValue + TimeSpan.FromDays(value.Value) : (DateTime?)null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(SqlDateTime value) { return value.IsNull ? (DateTime?)null : value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(SqlString value) { return value.IsNull ? (DateTime?)null : ToDateTime(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(SqlInt64 value) { return value.IsNull ? (DateTime?)null : DateTime.MinValue + TimeSpan.FromTicks(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(SqlDouble value) { return value.IsNull ? (DateTime?)null : DateTime.MinValue + TimeSpan.FromDays(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable DateTime.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable DateTime.</returns>
        public static DateTime? ToNullableDateTime(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is DateTime) return ToNullableDateTime((DateTime)value);
            if (value is String) return ToNullableDateTime((String)value);

            if (value is TimeSpan) return ToNullableDateTime((TimeSpan)value);
            if (value is Int64) return ToNullableDateTime((Int64)value);
            if (value is Double) return ToNullableDateTime((Double)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlDateTime) return ToNullableDateTime((SqlDateTime)value);
            if (value is SqlString) return ToNullableDateTime((SqlString)value);
            if (value is SqlInt64) return ToNullableDateTime((SqlInt64)value);
            if (value is SqlDouble) return ToNullableDateTime((SqlDouble)value);
#endif
            if (value is IConvertible) return ((IConvertible)value).ToDateTime(null);

            throw CreateInvalidCastException(value.GetType(), typeof(DateTime?));
		}

        #endregion

        #region TimeSpan?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(TimeSpan value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(String value) { return value == null ? null : (TimeSpan?)TimeSpan.Parse(value); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(DateTime value) { return value - DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(Int64 value) { return TimeSpan.FromTicks(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(Double value) { return TimeSpan.FromDays(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(DateTime? value) { return value.HasValue ? value.Value - DateTime.MinValue : (TimeSpan?)null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(Int64? value) { return value.HasValue ? TimeSpan.FromTicks(value.Value) : (TimeSpan?)null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(Double? value) { return value.HasValue ? TimeSpan.FromDays(value.Value) : (TimeSpan?)null; }

#endif
		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(SqlString value) { return value.IsNull ? (TimeSpan?)null : TimeSpan.Parse(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(SqlDateTime value) { return value.IsNull ? (TimeSpan?)null : value.Value - DateTime.MinValue; }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(SqlInt64 value) { return value.IsNull ? (TimeSpan?)null : TimeSpan.FromTicks(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(SqlDouble value) { return value.IsNull ? (TimeSpan?)null : TimeSpan.FromDays(value.Value); }
#endif
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable TimeSpan.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable TimeSpan.</returns>
        public static TimeSpan? ToNullableTimeSpan(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is TimeSpan) return ToNullableTimeSpan((TimeSpan)value);
            if (value is String) return ToNullableTimeSpan((String)value);
            if (value is DateTime) return ToNullableTimeSpan((DateTime)value);
            if (value is Int64) return ToNullableTimeSpan((Int64)value);
            if (value is Double) return ToNullableTimeSpan((Double)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlString) return ToNullableTimeSpan((SqlString)value);
            if (value is SqlDateTime) return ToNullableTimeSpan((SqlDateTime)value);
            if (value is SqlInt64) return ToNullableTimeSpan((SqlInt64)value);
            if (value is SqlDouble) return ToNullableTimeSpan((SqlDouble)value);
#endif
            throw CreateInvalidCastException(value.GetType(), typeof(TimeSpan?));
		}

        #endregion

        #region Guid?

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified Guid to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(Guid value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(String value) { return value == null ? null : (Guid?)new Guid(value); }

		// SqlTypes.
#if! SILVERLIGHT
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(SqlGuid value) { return value.IsNull ? null : (Guid?)value.Value; }
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(SqlString value) { return value.IsNull ? null : (Guid?)new Guid(value.Value); }
        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(SqlBinary value) { return value.IsNull ? null : (Guid?)value.ToSqlGuid().Value; }
#endif
		// Other Types.

        /// <summary>
        /// Converts the value of the specified Type to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(Type value) { return value == null ? null : (Guid?)value.GUID; }
        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(Byte[] value) { return value == null ? null : (Guid?)new Guid(value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent nullable Guid.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent nullable Guid.</returns>
        public static Guid? ToNullableGuid(object value)
		{
            if (value == null || value is DBNull) return null;

			// Scalar Types.
			//
            if (value is Guid) return ToNullableGuid((Guid)value);
            if (value is String) return ToNullableGuid((String)value);

			// SqlTypes.
#if! SILVERLIGHT
            if (value is SqlGuid) return ToNullableGuid((SqlGuid)value);
            if (value is SqlString) return ToNullableGuid((SqlString)value);
            if (value is SqlBinary) return ToNullableGuid((SqlBinary)value);
#endif
			// Other Types.
			//
            if (value is Type) return ToNullableGuid((Type)value);
            if (value is Byte[]) return ToNullableGuid((Byte[])value);

            throw CreateInvalidCastException(value.GetType(), typeof(Guid?));
		}

        #endregion

        #endregion
#endif

        #region SqlTypes

        #region SqlString
#if! SILVERLIGHT
        // Scalar Types.
        
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The SqlString equivalent of the value.</returns>
        public static SqlString ToSqlString(String value) { return value == null ? SqlString.Null : value; }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the 8-bit signed integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(SByte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the 16-bit signed integer value.</returns>
        public static SqlString ToSqlString(Int16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the 32-bit signed integer value.</returns>
        public static SqlString ToSqlString(Int32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the 64-bit signed integer value.</returns>
        public static SqlString ToSqlString(Int64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 8-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the 8-bit unsigned integer value.</returns>
        public static SqlString ToSqlString(Byte value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt16 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt32 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt64 value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The SqlString equivalent of the single-precision floating point number.</returns>
        public static SqlString ToSqlString(Single value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The SqlString equivalent of the double-precision floating point number.</returns>
        public static SqlString ToSqlString(Double value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A Boolean value.</param>
        /// <returns>The SqlString equivalent of the Boolean.</returns>
        public static SqlString ToSqlString(Boolean value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The SqlString equivalent of the Decimal number.</returns>
        public static SqlString ToSqlString(Decimal value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The SqlString equivalent of the Unicode character.</returns>
        public static SqlString ToSqlString(Char value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The SqlString equivalent of the TimeSpan.</returns>
        public static SqlString ToSqlString(TimeSpan value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The SqlString equivalent of the DateTime.</returns>
        public static SqlString ToSqlString(DateTime value) { return value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The SqlString equivalent of the Guid.</returns>
        public static SqlString ToSqlString(Guid value) { return value.ToString(); }        
        /// <summary>
        /// Converts the specified character array to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A character array.</param>
        /// <returns>The SqlString equivalent of character array.</returns>
        public static SqlString ToSqlString(Char[] value) { return new String(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the value of value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(SByte? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The SqlString equivalent of nullable 16-bit signed integer value.</returns>
        public static SqlString ToSqlString(Int16? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the nullable 32-bit signed integer value.</returns>
        public static SqlString ToSqlString(Int32? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The SqlString equivalent of the nullable 64-bit signed integer value.</returns>
        public static SqlString ToSqlString(Int64? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer  to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the nullable 8-bit unsigned integer value.</returns>
        public static SqlString ToSqlString(Byte? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the nullable 16-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt16? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the nullable 32-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt32? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The SqlString equivalent of the nullable 64-bit unsigned integer value.</returns>
        [CLSCompliant(false)]
        public static SqlString ToSqlString(UInt64? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The SqlString equivalent of the nullable single-precision floating point number.</returns>
        public static SqlString ToSqlString(Single? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The SqlString equivalent of the nullable double-precision floating point number.</returns>
        public static SqlString ToSqlString(Double? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable Boolean value.</param>
        /// <returns>The SqlString equivalent of the nullable Boolean value.</returns>
        public static SqlString ToSqlString(Boolean? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The SqlString equivalent of the nullable Decimal number.</returns>
        public static SqlString ToSqlString(Decimal? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The SqlString equivalent of the nullable Unicode character.</returns>
        public static SqlString ToSqlString(Char? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The SqlString equivalent of the nullable TimeSpan.</returns>
        public static SqlString ToSqlString(TimeSpan? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The SqlString equivalent of the nullable DateTime.</returns>
        public static SqlString ToSqlString(DateTime? value) { return value.HasValue ? value.ToString() : SqlString.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The SqlString equivalent of the nullable Guid.</returns>
        public static SqlString ToSqlString(Guid? value) { return value.HasValue ? value.ToString() : SqlString.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The SqlString equivalent of the SqlByte.</returns>        
        public static SqlString ToSqlString(SqlByte value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The SqlString equivalent of SqlInt16.</returns>        
        public static SqlString ToSqlString(SqlInt16 value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The SqlString equivalent of the SqlInt32.</returns>        
        public static SqlString ToSqlString(SqlInt32 value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The SqlString equivalent of the SqlInt64.</returns>        
        public static SqlString ToSqlString(SqlInt64 value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The SqlString equivalent of the SqlSingle.</returns>        
        public static SqlString ToSqlString(SqlSingle value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The SqlString equivalent of the SqlDouble.</returns>        
        public static SqlString ToSqlString(SqlDouble value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The SqlString equivalent of the SqlDecimal.</returns>        
        public static SqlString ToSqlString(SqlDecimal value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The SqlString equivalent of the SqlMoney.</returns>        
        public static SqlString ToSqlString(SqlMoney value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The SqlString equivalent of the SqlBoolean.</returns>        
        public static SqlString ToSqlString(SqlBoolean value) { return value.ToSqlString(); }
#if !(NET_1_1)
        /// <summary>
        /// Converts the value of the specified SqlChars to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlChars.</param>
        /// <returns>The SqlString equivalent of the SqlChars.</returns>        
        public static SqlString ToSqlString(SqlChars value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlXml to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlXml.</param>
        /// <returns>The SqlString equivalent of the SqlXml.</returns>        
        public static SqlString ToSqlString(SqlXml value) { return value.IsNull ? SqlString.Null : value.Value; }
#endif
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The SqlString equivalent of the SqlGuid.</returns>        
        public static SqlString ToSqlString(SqlGuid value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The SqlString equivalent of the SqlDateTime.</returns>        
        public static SqlString ToSqlString(SqlDateTime value) { return value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The SqlString equivalent of the SqlBinary.</returns>        
        public static SqlString ToSqlString(SqlBinary value) { return value.IsNull ? SqlString.Null : value.ToString(); }
        /// <summary>
        /// Converts the value of the specified Type to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An Type.</param>
        /// <returns>The SqlString equivalent of the Type.</returns>        
        public static SqlString ToSqlString(Type value) { return value == null ? SqlString.Null : value.FullName; }
        /// <summary>
        /// Converts the value of the specified XmlDocument to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An XmlDocument.</param>
        /// <returns>The SqlString equivalent of the XmlDocument.</returns>        
        public static SqlString ToSqlString(XmlDocument value) { return value == null ? SqlString.Null : value.InnerXml; }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlString representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The SqlString equivalent of the Object.</returns>
        public static SqlString ToSqlString(object value)
        {
            if (value == null || value is DBNull) return SqlString.Null;

            if (value is SqlString) return (SqlString)value;

            // Scalar Types.
            //
            if (value is String) return ToSqlString((String)value);

            if (value is Char) return ToSqlString((Char)value);
            if (value is TimeSpan) return ToSqlString((TimeSpan)value);
            if (value is DateTime) return ToSqlString((DateTime)value);
            if (value is Guid) return ToSqlString((Guid)value);
            if (value is Char[]) return ToSqlString((Char[])value);

            // SqlTypes.
            //
#if !(NET_1_1)
            if (value is SqlChars) return ToSqlString((SqlChars)value);
            if (value is SqlXml) return ToSqlString((SqlXml)value);
#endif
            if (value is SqlGuid) return ToSqlString((SqlGuid)value);
            if (value is SqlDateTime) return ToSqlString((SqlDateTime)value);
            if (value is SqlBinary) return ToSqlString((SqlBinary)value);

            if (value is Type) return ToSqlString((Type)value);
            if (value is XmlDocument) return ToSqlString((XmlDocument)value);

            return ToString(value);
        }
#endif
        #endregion

        #region SqlByte
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Byte value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(String value) { return value == null ? SqlByte.Null : SqlByte.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A 8-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(SByte value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Int16 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Int32 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Int64 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt16 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt32 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt64 value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlByte representation.</returns>
        public static SqlByte ToSqlByte(Single value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Double value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Decimal value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Char value) { return checked((Byte)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Boolean value) { return (Byte)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Byte? value) { return value.HasValue ? value.Value : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(SByte? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Int16? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Int32? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Int64? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt16? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt32? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlByte.</returns>
        [CLSCompliant(false)]
        public static SqlByte ToSqlByte(UInt64? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Single? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Double? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Boolean? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Decimal? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(Char? value) { return value.HasValue ? ToByte(value.Value) : SqlByte.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlString value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlInt16 value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlInt32 value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlInt64 value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlSingle value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlDouble value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlDecimal value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlMoney value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlBoolean value) { return value.ToSqlByte(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(SqlDateTime value) { return value.IsNull ? SqlByte.Null : ToByte(value.Value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlByte representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlByte.</returns>
        public static SqlByte ToSqlByte(object value)
        {
            if (value == null || value is DBNull) return SqlByte.Null;

            if (value is SqlByte) return (SqlByte)value;

            // Scalar Types.
            //
            if (value is Byte) return ToSqlByte((Byte)value);
            if (value is String) return ToSqlByte((String)value);

            if (value is Char) return ToSqlByte((Char)value);
            if (value is Boolean) return ToSqlByte((Boolean)value);

            // SqlTypes.
            //
            if (value is SqlDateTime) return ToSqlByte((SqlDateTime)value);

            return ToByte(value);
        }
#endif
        #endregion

        #region SqlInt16
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An 16-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Int16 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(String value) { return value == null ? SqlInt16.Null : SqlInt16.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(SByte value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Int32 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Int64 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Byte value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt16 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt32 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt64 value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Single value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Double value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Decimal value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Char value) { return checked((Int16)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Boolean value) { return (Int16)(value ? 1 : 0); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Int16? value) { return value.HasValue ? value.Value : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(SByte? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Int32? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Int64? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Byte? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt16? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt32? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        [CLSCompliant(false)]
        public static SqlInt16 ToSqlInt16(UInt64? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Single? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Double? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Boolean? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Decimal? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(Char? value) { return value.HasValue ? ToInt16(value.Value) : SqlInt16.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlString value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlByte value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlInt32 value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlInt64 value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlSingle value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlDouble value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlDecimal value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlMoney value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlBoolean value) { return value.ToSqlInt16(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(SqlDateTime value) { return value.IsNull ? SqlInt16.Null : ToInt16(value.Value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlInt16 representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlInt16.</returns>
        public static SqlInt16 ToSqlInt16(object value)
        {
            if (value == null || value is DBNull) return SqlInt16.Null;

            if (value is SqlInt16) return (SqlInt16)value;

            // Scalar Types.
            //
            if (value is Int16) return ToSqlInt16((Int16)value);
            if (value is String) return ToSqlInt16((String)value);

            if (value is Char) return ToSqlInt16((Char)value);
            if (value is Boolean) return ToSqlInt16((Boolean)value);

            // SqlTypes.
            //
            if (value is SqlDateTime) return ToSqlInt16((SqlDateTime)value);

            return ToInt16(value);
        }
#endif
        #endregion

        #region SqlInt32
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An 32-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Int32 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(String value) { return value == null ? SqlInt32.Null : SqlInt32.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(SByte value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Int16 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Int64 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Byte value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt16 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt32 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt64 value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Single value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Double value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Decimal value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Char value) { return checked((Int32)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Boolean value) { return value ? 1 : 0; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Int32? value) { return value.HasValue ? value.Value : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(SByte? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Int16? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Int64? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Byte? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt16? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt32? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        [CLSCompliant(false)]
        public static SqlInt32 ToSqlInt32(UInt64? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Single? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Double? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Boolean? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Decimal? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(Char? value) { return value.HasValue ? ToInt32(value.Value) : SqlInt32.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlString value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlByte value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlInt16 value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlInt64 value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlSingle value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlDouble value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlDecimal value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlMoney value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlBoolean value) { return value.ToSqlInt32(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(SqlDateTime value) { return value.IsNull ? SqlInt32.Null : ToInt32(value.Value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlInt32 representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlInt32.</returns>
        public static SqlInt32 ToSqlInt32(object value)
        {
            if (value == null || value is DBNull) return SqlInt32.Null;

            if (value is SqlInt32) return (SqlInt32)value;

            // Scalar Types.
            //
            if (value is Int32) return ToSqlInt32((Int32)value);
            if (value is String) return ToSqlInt32((String)value);

            if (value is Char) return ToSqlInt32((Char)value);
            if (value is Boolean) return ToSqlInt32((Boolean)value);

            // SqlTypes.
            //
            if (value is SqlDateTime) return ToSqlInt32((SqlDateTime)value);

            return ToInt32(value);
        }
#endif
        #endregion

        #region SqlInt64
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An 64-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Int64 value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(String value) { return value == null ? SqlInt64.Null : SqlInt64.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(SByte value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Int16 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Int32 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Byte value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt16 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt32 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt64 value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Single value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Double value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Decimal value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Char value) { return checked((Int64)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Boolean value) { return value ? 1 : 0; }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(DateTime value) { return (value - DateTime.MinValue).Ticks; }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(TimeSpan value) { return value.Ticks; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Int64? value) { return value.HasValue ? value.Value : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(SByte? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Int16? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Int32? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Byte? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt16? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt32? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        [CLSCompliant(false)]
        public static SqlInt64 ToSqlInt64(UInt64? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Single? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Double? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Boolean? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Decimal? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(Char? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(DateTime? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(TimeSpan? value) { return value.HasValue ? ToInt64(value.Value) : SqlInt64.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlString value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlByte value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlInt16 value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlInt32 value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlSingle value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlDouble value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlDecimal value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlMoney value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlBoolean value) { return value.ToSqlInt64(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(SqlDateTime value) { return value.IsNull ? SqlInt64.Null : ToInt64(value.Value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlInt64 representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlInt64.</returns>
        public static SqlInt64 ToSqlInt64(object value)
        {
            if (value == null || value is DBNull) return SqlInt64.Null;

            if (value is SqlInt64) return (SqlInt64)value;

            // Scalar Types.
            //
            if (value is Int64) return ToSqlInt64((Int64)value);
            if (value is String) return ToSqlInt64((String)value);

            if (value is Char) return ToSqlInt64((Char)value);
            if (value is Boolean) return ToSqlInt64((Boolean)value);
            if (value is DateTime) return ToSqlInt64((DateTime)value);
            if (value is TimeSpan) return ToSqlInt64((TimeSpan)value);

            // SqlTypes.
            //
            if (value is SqlDateTime) return ToSqlInt64((SqlDateTime)value);

            return ToInt64(value);
        }
#endif
        #endregion

        #region SqlSingle
#if! SILVERLIGHT
        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Single value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(String value) { return value == null ? SqlSingle.Null : SqlSingle.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(SByte value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Int16 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Int32 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Int64 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Byte value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt16 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt32 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt64 value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Double value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Decimal value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Char value) { return checked((Single)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Boolean value) { return value ? 1.0f : 0.0f; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Single? value) { return value.HasValue ? value.Value : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(SByte? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Int16? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Int32? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Int64? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Byte? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt16? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt32? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        [CLSCompliant(false)]
        public static SqlSingle ToSqlSingle(UInt64? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Double? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Boolean? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(Decimal? value) { return value.HasValue ? ToSingle(value.Value) : SqlSingle.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlString value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlByte value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlInt16 value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlInt32 value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlInt64 value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlDouble value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlDecimal value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlMoney value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlSingle.</returns>
        public static SqlSingle ToSqlSingle(SqlBoolean value) { return value.ToSqlSingle(); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlSingle representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlSingle representation.</returns>
        public static SqlSingle ToSqlSingle(object value)
        {
            if (value == null || value is DBNull) return SqlSingle.Null;

            if (value is SqlSingle) return (SqlSingle)value;

            // Scalar Types.
            //
            if (value is Single) return ToSqlSingle((Single)value);
            if (value is String) return ToSqlSingle((String)value);

            if (value is Char) return ToSqlSingle((Char)value);
            if (value is Boolean) return ToSqlSingle((Boolean)value);

            return ToSingle(value);
        }
#endif
        #endregion

        #region SqlDouble
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlDouble representation.</returns>
        public static SqlDouble ToSqlDouble(Double value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(String value) { return value == null ? SqlDouble.Null : SqlDouble.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble representation.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(SByte value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Int16 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Int32 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Int64 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Byte value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt16 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt32 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt64 value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Single value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Decimal value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Char value) { return checked((Double)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Boolean value) { return value ? 1.0 : 0.0; }
        public static SqlDouble ToSqlDouble(DateTime value) { return (value - DateTime.MinValue).TotalDays; }
        public static SqlDouble ToSqlDouble(TimeSpan value) { return value.TotalDays; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Double? value) { return value.HasValue ? value.Value : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(SByte? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Int16? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Int32? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Int64? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Byte? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt16? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt32? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        [CLSCompliant(false)]
        public static SqlDouble ToSqlDouble(UInt64? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Single? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Boolean? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(Decimal? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        public static SqlDouble ToSqlDouble(DateTime? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }
        public static SqlDouble ToSqlDouble(TimeSpan? value) { return value.HasValue ? ToDouble(value.Value) : SqlDouble.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlString value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlByte value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlInt16 value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlInt32 value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlInt64 value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlSingle value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlDecimal value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlMoney value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlBoolean value) { return value.ToSqlDouble(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(SqlDateTime value) { return value.IsNull ? SqlDouble.Null : ToDouble(value.Value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlDouble representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlDouble.</returns>
        public static SqlDouble ToSqlDouble(object value)
        {
            if (value == null || value is DBNull) return SqlDouble.Null;

            if (value is SqlDouble) return (SqlDouble)value;

            // Scalar Types.
            //
            if (value is Double) return ToSqlDouble((Double)value);
            if (value is String) return ToSqlDouble((String)value);

            if (value is Char) return ToSqlDouble((Char)value);
            if (value is Boolean) return ToSqlDouble((Boolean)value);
            if (value is DateTime) return ToSqlDouble((DateTime)value);
            if (value is TimeSpan) return ToSqlDouble((TimeSpan)value);

            // SqlTypes.
            //
            if (value is SqlDateTime) return ToSqlDouble((SqlDateTime)value);

            return ToDouble(value);
        }
#endif
        #endregion

        #region SqlDecimal
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified Decimal to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A Decimal.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Decimal value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(String value) { return value == null ? SqlDecimal.Null : SqlDecimal.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(SByte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Int16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Int32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Int64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Byte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Single value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Double value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Char value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Boolean value) { return value ? 1.0m : 0.0m; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Decimal? value) { return value.HasValue ? value.Value : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(SByte? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Int16? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Int32? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Int64? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Byte? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt16? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt32? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        [CLSCompliant(false)]
        public static SqlDecimal ToSqlDecimal(UInt64? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Single? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Double? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(Boolean? value) { return value.HasValue ? ToDecimal(value.Value) : SqlDecimal.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlString value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlByte value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlInt16 value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlInt32 value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlInt64 value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlSingle value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlDouble value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlMoney value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(SqlBoolean value) { return value.ToSqlDecimal(); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlDecimal representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlDecimal.</returns>
        public static SqlDecimal ToSqlDecimal(object value)
        {
            if (value == null || value is DBNull) return SqlDecimal.Null;

            if (value is SqlDecimal) return (SqlDecimal)value;

            // Scalar Types.
            //
            if (value is Decimal) return ToSqlDecimal((Decimal)value);
            if (value is String) return ToSqlDecimal((String)value);

            if (value is Char) return ToSqlDecimal((Char)value);
            if (value is Boolean) return ToSqlDecimal((Boolean)value);

            return ToDecimal(value);
        }
#endif
        #endregion

        #region SqlMoney
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified Decimal to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A Decimal.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Decimal value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(String value) { return value == null ? SqlMoney.Null : SqlMoney.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(SByte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Int16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Int32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Int64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Byte value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt16 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt32 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt64 value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Single value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Double value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Char value) { return checked((Decimal)value); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Boolean value) { return value ? 1.0m : 0.0m; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Decimal? value) { return value.HasValue ? value.Value : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(SByte? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Int16? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Int32? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Int64? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Byte? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt16? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt32? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        [CLSCompliant(false)]
        public static SqlMoney ToSqlMoney(UInt64? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Single? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Double? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(Boolean? value) { return value.HasValue ? ToDecimal(value.Value) : SqlMoney.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlString value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlByte value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlInt16 value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlInt32 value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlInt64 value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlSingle value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlDouble value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlDecimal value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(SqlBoolean value) { return value.ToSqlMoney(); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlMoney representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlMoney.</returns>
        public static SqlMoney ToSqlMoney(object value)
        {
            if (value == null || value is DBNull) return SqlMoney.Null;

            if (value is SqlMoney) return (SqlMoney)value;

            // Scalar Types.
            //
            if (value is Decimal) return ToSqlMoney((Decimal)value);
            if (value is String) return ToSqlMoney((String)value);

            if (value is Char) return ToSqlMoney((Char)value);
            if (value is Boolean) return ToSqlMoney((Boolean)value);

            return ToDecimal(value);
        }
#endif
        #endregion

        #region SqlBoolean
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Boolean value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(String value) { return value == null ? SqlBoolean.Null : SqlBoolean.Parse(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(SByte value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Int16 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Int32 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Int64 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Byte value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt16 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt32 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt64 value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Single value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Double value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Decimal value) { return value != 0; }
        /// <summary>
        /// Converts the value of the specified Unsigned character to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An Unsigned character.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Char value) { return value != 0; }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Boolean to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Boolean? value) { return value.HasValue ? value.Value : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(SByte? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Int16? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Int32? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Int64? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Byte? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt16? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt32? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        [CLSCompliant(false)]
        public static SqlBoolean ToSqlBoolean(UInt64? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Single? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Double? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Decimal? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Unicode character to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">A nullable Unicode character.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(Char? value) { return value.HasValue ? ToBoolean(value.Value) : SqlBoolean.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlString value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlByte value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlInt16 value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlInt32 value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlInt64 value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlSingle value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlDouble value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlDecimal value) { return value.ToSqlBoolean(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(SqlMoney value) { return value.ToSqlBoolean(); }

        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlBoolean representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlBoolean.</returns>
        public static SqlBoolean ToSqlBoolean(object value)
        {
            if (value == null || value is DBNull) return SqlBoolean.Null;

            if (value is SqlBoolean) return (SqlBoolean)value;

            // Scalar Types.
            //
            if (value is Boolean) return ToSqlBoolean((Boolean)value);
            if (value is String) return ToSqlBoolean((String)value);

            if (value is Char) return ToSqlBoolean((Char)value);

            return ToBoolean(value);
        }
#endif
        #endregion

        #region SqlDateTime
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(String value) { return value == null ? SqlDateTime.Null : SqlDateTime.Parse(value); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(DateTime value) { return value; }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(TimeSpan value) { return ToDateTime(value); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(Int64 value) { return ToDateTime(value); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(Double value) { return ToDateTime(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable DateTime to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(DateTime? value) { return value.HasValue ? value.Value : SqlDateTime.Null; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(TimeSpan? value) { return value.HasValue ? ToDateTime(value.Value) : SqlDateTime.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer number to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(Int64? value) { return value.HasValue ? ToDateTime(value.Value) : SqlDateTime.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(Double? value) { return value.HasValue ? ToDateTime(value.Value) : SqlDateTime.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(SqlString value) { return value.ToSqlDateTime(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(SqlInt64 value) { return value.IsNull ? SqlDateTime.Null : ToDateTime(value); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(SqlDouble value) { return value.IsNull ? SqlDateTime.Null : ToDateTime(value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlDateTime representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlDateTime.</returns>
        public static SqlDateTime ToSqlDateTime(object value)
        {
            if (value == null || value is DBNull) return SqlDateTime.Null;

            if (value is SqlDateTime) return (SqlDateTime)value;

            // Scalar Types.
            //
            if (value is String) return ToSqlDateTime((String)value);
            if (value is DateTime) return ToSqlDateTime((DateTime)value);
            if (value is TimeSpan) return ToSqlDateTime((TimeSpan)value);
            if (value is Int64) return ToSqlDateTime((Int64)value);
            if (value is Double) return ToSqlDateTime((Double)value);

            // SqlTypes.
            //
            if (value is SqlString) return ToSqlDateTime((SqlString)value);
            if (value is SqlInt64) return ToSqlDateTime((SqlInt64)value);
            if (value is SqlDouble) return ToSqlDateTime((SqlDouble)value);

            return ToDateTime(value);
        }
#endif
        #endregion

        #region SqlGuid
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified Guid to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(Guid value) { return value; }
        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(String value) { return value == null ? SqlGuid.Null : SqlGuid.Parse(value); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(Guid? value) { return value.HasValue ? value.Value : SqlGuid.Null; }

#endif
        // SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(SqlBinary value) { return value.ToSqlGuid(); }
#if !(NET_1_1)
        /// <summary>
        /// Converts the value of the specified SqlBytes to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">An SqlBytes.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(SqlBytes value) { return value.ToSqlBinary().ToSqlGuid(); }
#endif
        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(SqlString value) { return value.ToSqlGuid(); }

        // Other Types.

        /// <summary>
        /// Converts the value of the specified Type to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(Type value) { return value == null ? SqlGuid.Null : value.GUID; }
        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(Byte[] value) { return value == null ? SqlGuid.Null : new SqlGuid(value); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlGuid representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlGuid.</returns>
        public static SqlGuid ToSqlGuid(object value)
        {
            if (value == null || value is DBNull) return SqlGuid.Null;

            if (value is SqlGuid) return (SqlGuid)value;

            // Scalar Types.
            //
            if (value is Guid) return ToSqlGuid((Guid)value);
            if (value is String) return ToSqlGuid((String)value);

            // SqlTypes.
            //
            if (value is SqlBinary) return ToSqlGuid((SqlBinary)value);
#if !(NET_1_1)
            if (value is SqlBytes) return ToSqlGuid((SqlBytes)value);
#endif
            if (value is SqlString) return ToSqlGuid((SqlString)value);

            // Other Types.
            //
            if (value is Type) return ToSqlGuid((Type)value);
            if (value is Byte[]) return ToSqlGuid((Byte[])value);

            return ToGuid(value);
        }
#endif
        #endregion

        #region SqlBinary
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent SqlBinary representation.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent SqlBinary.</returns>
        public static SqlBinary ToSqlBinary(Byte[] value) { return value; }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent SqlBinary representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The equivalent SqlBinary.</returns>
        public static SqlBinary ToSqlBinary(Guid value) { return value == Guid.Empty ? SqlBinary.Null : new SqlGuid(value).ToSqlBinary(); }

#if !(NET_1_1)
        // Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent SqlBinary representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The equivalent SqlBinary.</returns>
        public static SqlBinary ToSqlBinary(Guid? value) { return value.HasValue ? new SqlGuid(value.Value).ToSqlBinary() : SqlBinary.Null; }

#endif
        // SqlTypes.
#if !(NET_1_1)
        /// <summary>
        /// Converts the value of the specified SqlBytes to its equivalent SqlBinary representation.
        /// </summary>
        /// <param name="value">An SqlBytes.</param>
        /// <returns>The equivalent SqlBinary.</returns>
        public static SqlBinary ToSqlBinary(SqlBytes value) { return value.ToSqlBinary(); }
#endif
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent SqlBinary representation.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The equivalent SqlBinary.</returns>
        public static SqlBinary ToSqlBinary(SqlGuid value) { return value.ToSqlBinary(); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlBinary representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlBinary.</returns>
        public static SqlBinary ToSqlBinary(object value)
        {
            if (value == null || value is DBNull) return SqlBinary.Null;

            if (value is SqlBinary) return (SqlBinary)value;

            // Scalar Types.
            //
            if (value is Byte[]) return ToSqlBinary((Byte[])value);
            if (value is Guid) return ToSqlBinary((Guid)value);

            // SqlTypes.
            //
#if !(NET_1_1)
            if (value is SqlBytes) return ToSqlBinary((SqlBytes)value);
#endif
            if (value is SqlGuid) return ToSqlBinary((SqlGuid)value);

            return ToByteArray(value);
        }
#endif
        #endregion

#if !(NET_1_1)
        #region SqlBytes
#if! SILVERLIGHT

        // Scalar Types.

        /// <summary>
        /// Converts the value of the specified memory buffer to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(Byte[] value) { return value == null ? SqlBytes.Null : new SqlBytes(value); }
        /// <summary>
        /// Converts the value of the specified Stream to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">A Stream.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(Stream value) { return value == null ? SqlBytes.Null : new SqlBytes(value); }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(Guid value) { return value == Guid.Empty ? SqlBytes.Null : new SqlBytes(value.ToByteArray()); }

		// Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable Guid to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(Guid? value) { return value.HasValue ? new SqlBytes(value.Value.ToByteArray()) : SqlBytes.Null; }

		// SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(SqlBinary value) { return value.IsNull ? SqlBytes.Null : new SqlBytes(value); }
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(SqlGuid value) { return value.IsNull ? SqlBytes.Null : new SqlBytes(value.ToByteArray()); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlBytes representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlBytes.</returns>
        public static SqlBytes ToSqlBytes(object value)
		{
            if (value == null || value is DBNull) return SqlBytes.Null;

            if (value is SqlBytes) return (SqlBytes)value;

			// Scalar Types.
			//
            if (value is Byte[]) return ToSqlBytes((Byte[])value);
            if (value is Stream) return ToSqlBytes((Stream)value);
            if (value is Guid) return ToSqlBytes((Guid)value);

			// SqlTypes.
			//
            if (value is SqlBinary) return ToSqlBytes((SqlBinary)value);
            if (value is SqlGuid) return ToSqlBytes((SqlGuid)value);

            return new SqlBytes(ToByteArray(value));
		}
#endif
        #endregion

        #region SqlChars
#if! SILVERLIGHT

		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(String value) { return value == null ? SqlChars.Null : new SqlChars(value.ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified character array to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A character array.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Char[] value) { return value == null ? SqlChars.Null : new SqlChars(value); }
        /// <summary>
        /// Converts the value of the specified 8-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An 8-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
		[CLSCompliant(false)]
        public static SqlChars ToSqlChars(SByte value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 16-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A 16-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Int16 value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 32-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A 32-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Int32 value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 64-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A 64-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Int64 value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 8-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Byte value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 16-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
		[CLSCompliant(false)]
        public static SqlChars ToSqlChars(UInt16 value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 32-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
		[CLSCompliant(false)]
        public static SqlChars ToSqlChars(UInt32 value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified 64-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
		[CLSCompliant(false)]
        public static SqlChars ToSqlChars(UInt64 value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified single-precision floating point number to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A single-precision floating point number.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Single value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified double-precision floating point number to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A double-precision floating point number.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Double value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified Boolean to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A Boolean.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Boolean value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified Decimal number to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A Decimal number.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Decimal value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified Unicode character to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Char value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified TimeSpan to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A TimeSpan.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(TimeSpan value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified DateTime to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A DateTime.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(DateTime value) { return new SqlChars(ToString(value).ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified Guid to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A Guid.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Guid value) { return new SqlChars(ToString(value).ToCharArray()); }

		// Nullable Types.

        /// <summary>
        /// Converts the value of the specified nullable 8-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        [CLSCompliant(false)]
        public static SqlChars ToSqlChars(SByte? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Int16? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Int32? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit signed integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit signed integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Int64? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 8-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 8-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Byte? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 16-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 16-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        [CLSCompliant(false)]
        public static SqlChars ToSqlChars(UInt16? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 32-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 32-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        [CLSCompliant(false)]
        public static SqlChars ToSqlChars(UInt32? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable 64-bit unsigned integer to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable 64-bit unsigned integer.</param>
        /// <returns>The equivalent SqlChars.</returns>
        [CLSCompliant(false)]
        public static SqlChars ToSqlChars(UInt64? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable single-precision floating point number to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable single-precision floating point number.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Single? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable double-precision floating point number to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable double-precision floating point number.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Double? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Boolean to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable Boolean.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Boolean? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Decimal number to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable Decimal number.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Decimal? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the specified nullable character to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable Char.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Char? value) { return value.HasValue ? new SqlChars(new Char[] { value.Value }) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable TimeSpan to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable TimeSpan.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(TimeSpan? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable DateTime to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable DateTime.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(DateTime? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }
        /// <summary>
        /// Converts the value of the specified nullable Guid to the equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A nullable Guid.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Guid? value) { return value.HasValue ? new SqlChars(value.ToString().ToCharArray()) : SqlChars.Null; }

		// SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlString value) { return (SqlChars)value; }
        /// <summary>
        /// Converts the value of the specified SqlByte to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlByte.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlByte value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt16 to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlInt16.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlInt16 value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt32 to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlInt32.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlInt32 value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlInt64 to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlInt64.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlInt64 value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlSingle to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlSingle.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlSingle value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlDouble to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlDouble.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlDouble value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlDecimal to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlDecimal.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlDecimal value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlMoney to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlMoney.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlMoney value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlBoolean to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlBoolean.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlBoolean value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlGuid to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlGuid.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlGuid value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlDateTime to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlDateTime.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlDateTime value) { return (SqlChars)value.ToSqlString(); }
        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(SqlBinary value) { return value.IsNull ? SqlChars.Null : new SqlChars(value.ToString().ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified Type to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">A Type.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(Type value) { return value == null ? SqlChars.Null : new SqlChars(value.FullName.ToCharArray()); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlChars representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlChars.</returns>
        public static SqlChars ToSqlChars(object value) { return new SqlChars(ToString(value).ToCharArray()); }
#endif
        #endregion

        #region SqlXml
#if! SILVERLIGHT
		// Scalar Types.

        /// <summary>
        /// Converts the value of the specified String to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">A String.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(String value) { return value == null ? SqlXml.Null : new SqlXml(new XmlTextReader(new StringReader(value))); }
        /// <summary>
        /// Converts the value of the specified Stream to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">A Stream.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(Stream value) { return value == null ? SqlXml.Null : new SqlXml(value); }
        /// <summary>
        /// Converts the value of the specified XmlReader to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An XmlReader.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(XmlReader value) { return value == null ? SqlXml.Null : new SqlXml(value); }
        /// <summary>
        /// Converts the value of the specified XmlDocument to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An XmlDocument.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(XmlDocument value) { return value == null ? SqlXml.Null : new SqlXml(new XmlTextReader(new StringReader(value.InnerXml))); }

        /// <summary>
        /// Converts the specified character array to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">A character array.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(Char[] value) { return value == null ? SqlXml.Null : new SqlXml(new XmlTextReader(new StringReader(new string(value)))); }
        /// <summary>
        /// Converts the specified memory buffer to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">A memory buffer.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(Byte[] value) { return value == null ? SqlXml.Null : new SqlXml(new MemoryStream(value)); }

		// SqlTypes.

        /// <summary>
        /// Converts the value of the specified SqlString to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An SqlString.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(SqlString value) { return value.IsNull ? SqlXml.Null : new SqlXml(new XmlTextReader(new StringReader(value.Value))); }
        /// <summary>
        /// Converts the value of the specified SqlChars to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An SqlChars.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(SqlChars value) { return value.IsNull ? SqlXml.Null : new SqlXml(new XmlTextReader(new StringReader(value.ToSqlString().Value))); }
        /// <summary>
        /// Converts the value of the specified SqlBinary to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An SqlBinary.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(SqlBinary value) { return value.IsNull ? SqlXml.Null : new SqlXml(new MemoryStream(value.Value)); }
        /// <summary>
        /// Converts the value of the specified SqlBytes to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An SqlBytes.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(SqlBytes value) { return value.IsNull ? SqlXml.Null : new SqlXml(value.Stream); }
        /// <summary>
        /// Converts the value of the specified Object to its equivalent SqlXml representation.
        /// </summary>
        /// <param name="value">An Object.</param>
        /// <returns>The equivalent SqlXml.</returns>
        public static SqlXml ToSqlXml(object value)
		{
            if (value == null || value is DBNull) return SqlXml.Null;

            if (value is SqlXml) return (SqlXml)value;

			// Scalar Types.
			//
            if (value is String) return ToSqlXml((String)value);

            if (value is Stream) return ToSqlXml((Stream)value);
            if (value is XmlReader) return ToSqlXml((XmlReader)value);
            if (value is XmlDocument) return ToSqlXml((XmlDocument)value);

            if (value is Char[]) return ToSqlXml((Char[])value);
            if (value is Byte[]) return ToSqlXml((Byte[])value);

			// SqlTypes.
			//
            if (value is SqlString) return ToSqlXml((SqlString)value);
            if (value is SqlChars) return ToSqlXml((SqlChars)value);
            if (value is SqlBinary) return ToSqlXml((SqlBinary)value);
            if (value is SqlBytes) return ToSqlXml((SqlBytes)value);

            throw CreateInvalidCastException(value.GetType(), typeof(SqlXml));
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

#if !NET_1_1 && !NET_2_0
        public static XmlDocument ToXmlDocument(System.Xml.Linq.XDocument p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p.ToString());
            return doc;
        }

        public static XmlDocument ToXmlDocument(System.Xml.Linq.XElement p)
        {
            if (p == null) return null;

            XmlDocument doc = new XmlDocument();
            doc.Load(p.ToString());
            return doc;
        }
#endif


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
#if !NET_1_1 && !NET_2_0
            if (p is System.Xml.Linq.XDocument) return ToXmlDocument((System.Xml.Linq.XDocument)p);
            if (p is System.Xml.Linq.XElement) return ToXmlDocument((System.Xml.Linq.XElement)p);
#endif
            throw CreateInvalidCastException(p.GetType(), typeof(XmlDocument));
        }
#endif
        #endregion

#if !NET_1_1 && !NET_2_0
        #region XDocument

        // Scalar Types.
        public static XDocument ToXDocument(String p)
        {
            if (p == null) return null;

            XDocument doc = XDocument.Parse(p);
            return doc;
        }

#if! SILVERLIGHT
        public static XDocument ToXDocument(XmlDocument p)
        {
            if (p == null) return null;

            XDocument doc = XDocument.Parse(p.OuterXml);
            return doc;
        }
#endif

        public static XDocument ToXDocument(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XDocument) return (XDocument)p;

            // Scalar Types.
            //
            if (p is String) return ToXDocument((String)p);
#if! SILVERLIGHT
            if (p is XmlDocument) return ToXDocument((XmlDocument)p);
#endif
            throw CreateInvalidCastException(p.GetType(), typeof(XDocument));
        }

        #endregion XDocument

        #region XElement

        // Scalar Types.
        public static XElement ToXElement(String p)
        {
            if (p == null) return null;

            XElement element = XElement.Parse(p);
            return element;
        }

#if! SILVERLIGHT
        public static XElement ToXElement(XmlDocument p)
        {
            if (p == null) return null;

            XElement element = XElement.Parse(p.OuterXml);
            return element;
        }
#endif

        public static XElement ToXElement(object p)
        {
            if (p == null || p is DBNull) return null;

            if (p is XElement) return (XElement)p;

            // Scalar Types.
            //
            if (p is String) return ToXElement((String)p);
#if! SILVERLIGHT
            if (p is XmlDocument) return ToXElement((XmlDocument)p);
#endif
            throw CreateInvalidCastException(p.GetType(), typeof(XElement));
        }


        #endregion XElement

#endif
        #endregion

        private static InvalidCastException CreateInvalidCastException(Type originalType, Type conversionType)
        {
            return new InvalidCastException(string.Format("Invalid cast from {0} to {1}", originalType.FullName, conversionType.FullName));
        }
    }
}
