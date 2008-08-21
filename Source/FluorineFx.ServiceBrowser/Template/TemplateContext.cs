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

namespace FluorineFx.CodeGenerator
{
	/// <summary>
	/// Summary description for TemplateContext.
	/// </summary>
	public sealed class TemplateContext
	{
		string					_relativePath;
		string					_templateDirectory;
		ITemplateGeneratorHost	_host;
		Hashtable				_context;
		Hashtable				_directives;
		Hashtable				_imports;
		Hashtable				_assemblies;


		internal TemplateContext(string relativePath, string templateDirectory, ITemplateGeneratorHost host)
		{
			_templateDirectory = templateDirectory;
			_relativePath = relativePath;
			_host = host;
			_context = new Hashtable();
			Hashtable globalContext = host.GetGlobalContext();
			if( globalContext != null )
			{
				foreach(DictionaryEntry entry in globalContext)
					_context.Add(entry.Key, entry.Value);
			}
			_directives = new Hashtable();
			_imports = new Hashtable();
			_assemblies = new Hashtable();
		}

		internal TemplateContext(TemplateContext parentTemplateContext):this(parentTemplateContext.RelativePath, parentTemplateContext.TemplateDirectory, parentTemplateContext.TemplateGeneratorHost)
		{
			//Inherit parent context too
			if( parentTemplateContext.Context != null )
			{
				foreach(DictionaryEntry entry in parentTemplateContext.Context)
				{
					if( !_context.ContainsKey(entry.Key) )
						_context.Add(entry.Key, entry.Value);
				}
			}
		}

		public string TemplateDirectory
		{
			get{ return _templateDirectory; }
		}

		public string RelativePath
		{
			get{ return _relativePath; }
		}

		public Hashtable Context
		{
			get{ return _context; }
		}

		public ITemplateGeneratorHost TemplateGeneratorHost
		{
			get{ return _host; }
		}

		public Hashtable Directives
		{
			get{ return _directives; }
		}

		public Hashtable Imports
		{
			get{ return _imports; }
		}

		public Hashtable Assemblies
		{
			get{ return _assemblies; }
		}
	}
}
