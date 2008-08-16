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
using System.Collections.Specialized;

namespace FluorineFx.ServiceBrowser.Sql
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class SqlTableCollection : CollectionBase
    {
        public SqlTableCollection()
        {
        }

        public int Add(SqlTable value)
        {
            return List.Add(value);
        }

        public void AddRange(SqlTableCollection value)
        {
            foreach(SqlTable table in value )
                List.Add(table);
        }

        public int IndexOf(SqlTable value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, SqlTable value)
        {
            List.Insert(index, value);
        }

        public void Remove(SqlTable value)
        {
            List.Remove(value);
        }

        public bool Contains(SqlTable value)
        {
            return List.Contains(value);
        }

        public SqlTable this[int index]
        {
            get
            {
                return List[index] as SqlTable;
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
