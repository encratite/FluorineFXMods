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
using System.Text;
using System.Web;

namespace FluorineFx.CodeGenerator.Parser
{
	public class TagAttributes
	{
		Hashtable atts_hash;
		Hashtable tmp_hash;
		ArrayList keys;
		ArrayList values;
		bool got_hashed;

		public TagAttributes ()
		{
			got_hashed = false;
			keys = new ArrayList ();
			values = new ArrayList ();
		}

		void MakeHash ()
		{
#if (NET_1_1)
			atts_hash = new Hashtable (CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
#else
            atts_hash = new Hashtable(StringComparer.OrdinalIgnoreCase);
#endif

			for (int i = 0; i < keys.Count; i++) 
			{
				CheckServerKey (keys [i]);
				atts_hash.Add (keys [i], values [i]);
			}
			got_hashed = true;
			keys = null;
			values = null;
		}
		
		public bool IsRunAtServer ()
		{
			return got_hashed;
		}

		public void Add (object key, object value)
		{
			if (key != null && value != null &&
				0 == String.Compare ((string) key,  "runat", true)) 
			{
				if (0 != String.Compare ((string) value,  "server", true))
					throw new HttpException ("runat attribute must have a 'server' value");

				if (got_hashed)
					return; // ignore duplicate runat="server"

				MakeHash ();
			}

			if (value != null)
				value = HttpUtility.HtmlDecode (value.ToString ());

			if (got_hashed) 
			{
				CheckServerKey (key);
				if (atts_hash.ContainsKey (key))
					throw new HttpException ("Tag contains duplicated '" + key +
						"' attributes.");
				atts_hash.Add (key, value);
			} 
			else 
			{
				keys.Add (key);
				values.Add (value);
			}
		}
		
		public ICollection Keys 
		{
			get { return (got_hashed ? atts_hash.Keys : keys); }
		}

		public ICollection Values 
		{
			get { return (got_hashed ? atts_hash.Values : values); }
		}

		private int CaseInsensitiveSearch (string key)
		{
			// Hope not to have many attributes when the tag is not a server tag...
			for (int i = 0; i < keys.Count; i++)
			{
				if (0 == String.Compare ((string) keys [i], key, true))
					return i;
			}
			return -1;
		}
		
		public object this [object key]
		{
			get 
			{
				if (got_hashed)
					return atts_hash [key];

				int idx = CaseInsensitiveSearch ((string) key);
				if (idx == -1)
					return null;
						
				return values [idx];
			}

			set 
			{
				if (got_hashed) 
				{
					CheckServerKey (key);
					atts_hash [key] = value;
				} 
				else 
				{
					int idx = CaseInsensitiveSearch ((string) key);
					keys [idx] = value;
				}
			}
		}
		
		public int Count 
		{
			get { return (got_hashed ? atts_hash.Count : keys.Count);}
		}

		public bool IsDataBound (string att)
		{
			if (att == null || !got_hashed)
				return false;

			return (att.StartsWith("<%#") && att.EndsWith ("%>"));
		}
		
		public Hashtable GetDictionary (string key)
		{
			if (got_hashed)
				return atts_hash;

            if (tmp_hash == null)
            {
#if (NET_1_1)
                tmp_hash = new Hashtable(CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant);
#else
                tmp_hash = new Hashtable(StringComparer.OrdinalIgnoreCase);
#endif

            }
			tmp_hash.Clear ();
			for (int i = keys.Count - 1; i >= 0; i--)
				if (key == null || String.Compare (key, (string) keys [i], true) == 0)
					tmp_hash [keys [i]] = values [i];

			return tmp_hash;
		}
		
		public override string ToString ()
		{
			StringBuilder result = new StringBuilder ();
			string value;
			foreach (string key in Keys)
			{
				result.Append (key);
				value = this [key] as string;
				if (value != null)
					result.AppendFormat ("=\"{0}\"", value);

				result.Append (' ');
			}

			if (result.Length > 0 && result [result.Length - 1] == ' ')
				result.Length--;
				
			return result.ToString ();
		}
		
		void CheckServerKey (object key)
		{
			if (key == null || ((string)key).Length == 0)
				throw new HttpException ("The server tag is not well formed.");
		}
	}
}
