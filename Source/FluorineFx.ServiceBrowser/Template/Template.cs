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

namespace FluorineFx.CodeGenerator
{
	/// <summary>
	/// Summary description for Template.
	/// </summary>
	public class Template
	{
		private TemplateEngine			_templateEngine;
		private ITemplateGeneratorHost	_host;
		private TemplateContext			_templateContext;

		public Template(TemplateEngine templateEngine, ITemplateGeneratorHost host, TemplateContext templateContext)
		{
			_templateEngine = templateEngine;
			_host = host;
			_templateContext = templateContext;
		}

		public Hashtable Context
		{
			get{ return _templateContext.Context; }
		}

		public void Generate(string templateFileName, string outFileName)
		{
			_templateEngine.ProcessTemplate(templateFileName, outFileName);
		}
		/// <summary>
		/// Parse templates from specified directory.
		/// </summary>
		/// <param name="templateDirectory">A sub-directory of the current template's directory.</param>
		/// <param name="outDirectory">A sub-directory of the current output directory.</param>
		public void ParseDirectory(string templateDirectory, string outDirectory)
		{
			_templateEngine.ParseSubDirectory(templateDirectory, outDirectory);
		}
		/// <summary>
		/// Creates a sub-directory in the current output directory.
		/// </summary>
		/// <param name="directory">A sub-directory of the current output directory.</param>
		public void CreateDirectory(string directory)
		{
            if (directory == null || directory == string.Empty)
                return;
			_host.CreateDirectory(Path.Combine(_templateContext.RelativePath, directory));
		}

		public void Echo(object obj)
		{
			string txt = obj.ToString();
			_templateEngine.Echo(txt);
		}

		public string EnsureDirectory(string[] pathParts)
		{
			string directory = string.Empty;
			foreach(string path in pathParts)
			{
				directory = Path.Combine(directory, path);
			}
			CreateDirectory(directory);
			return directory;
		}

        public string EnsureDirectory(string namespaceName)
        {
            string[] pathParts = namespaceName.Split(new char[] { '.' });
            return EnsureDirectory(pathParts);
        }

		public string GetSafeString(string txt)
		{
			string str = txt.Trim();
			str = str.TrimStart(new char[]{ '/', '\\'});
			str = str.Replace( ' ', '_');
			str = str.Replace( '/', '_');
			str = str.Replace( '.', '_');
			return str;
		}

	}
}
