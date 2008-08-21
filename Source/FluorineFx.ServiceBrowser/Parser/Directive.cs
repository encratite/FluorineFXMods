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
using System.Globalization;

namespace FluorineFx.CodeGenerator.Parser
{
	sealed class Directive
	{
		static Hashtable _directivesHash;
		static string [] _tempateAttributes = {  "Language", "TargetLanguage", "Description",
										 "OutputType", "LinePragmas" };

		static string [] _importAttributes = { "Namespace" };

		static string [] _assemblyAttributes = { "Name", "Src" };

		static Directive ()
		{
			InitHash ();
		}
		
		private static void InitHash ()
		{
#if (NET_1_1)
			CaseInsensitiveHashCodeProvider provider = new CaseInsensitiveHashCodeProvider (CultureInfo.InvariantCulture);
			CaseInsensitiveComparer comparer =  new CaseInsensitiveComparer (CultureInfo.InvariantCulture);
            _directivesHash = new Hashtable (provider, comparer); 

            // Use Hashtable 'cause is O(1) in Contains (ArrayList is O(n))
			Hashtable valid_attributes = new Hashtable (provider, comparer);
			foreach (string att in _tempateAttributes) valid_attributes.Add (att, null);
			_directivesHash.Add ("CodeTemplate", valid_attributes);

			valid_attributes = new Hashtable (provider, comparer);
			foreach (string att in _importAttributes) valid_attributes.Add (att, null);
			_directivesHash.Add ("Import", valid_attributes);

			valid_attributes = new Hashtable (provider, comparer);
			foreach (string att in _assemblyAttributes) valid_attributes.Add (att, null);
			_directivesHash.Add ("Assembly", valid_attributes);

#else
            _directivesHash = new Hashtable(StringComparer.OrdinalIgnoreCase);

            // Use Hashtable 'cause is O(1) in Contains (ArrayList is O(n))
            Hashtable valid_attributes = new Hashtable(StringComparer.OrdinalIgnoreCase);
            foreach (string att in _tempateAttributes) valid_attributes.Add(att, null);
            _directivesHash.Add("CodeTemplate", valid_attributes);

            valid_attributes = new Hashtable(StringComparer.OrdinalIgnoreCase);
            foreach (string att in _importAttributes) valid_attributes.Add(att, null);
            _directivesHash.Add("Import", valid_attributes);

            valid_attributes = new Hashtable(StringComparer.OrdinalIgnoreCase);
            foreach (string att in _assemblyAttributes) valid_attributes.Add(att, null);
            _directivesHash.Add("Assembly", valid_attributes);
#endif
		}
		
		private Directive () { }

		public static bool IsDirective (string id)
		{
			return _directivesHash.Contains (id);
		}
	}
}
