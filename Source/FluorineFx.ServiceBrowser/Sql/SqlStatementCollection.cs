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
    public sealed class SqlStatementCollection : CollectionBase
    {
        public SqlStatementCollection()
        {
        }

        public int Add(ISqlStatement value)
        {
            return List.Add(value);
        }

        public int IndexOf(ISqlStatement value)
        {
            return List.IndexOf(value);
        }

        public void Insert(int index, ISqlStatement value)
        {
            List.Insert(index, value);
        }

        public void Remove(ISqlStatement value)
        {
            List.Remove(value);
        }

        public bool Contains(ISqlStatement value)
        {
            return List.Contains(value);
        }

        public ISqlStatement this[int index]
        {
            get
            {
                return List[index] as ISqlStatement;
            }
            set
            {
                List[index] = value;
            }
        }
    }
}
