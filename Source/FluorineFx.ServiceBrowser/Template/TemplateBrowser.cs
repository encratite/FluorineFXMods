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
using System.IO;

namespace FluorineFx.CodeGenerator
{
	[Serializable]
	public class TemplateInfo
	{
		string	_name;
		string	_directory;

		public TemplateInfo()
		{
		}

		public TemplateInfo(string name, string directory)
		{
			_name = name;
			_directory = directory;
		}

		public string Name
		{
			get{ return _name; } 
			set{ _name = value; } 
		}

		public string Directory
		{ 
			get{ return _directory; }
			set{ _directory = value; }
		}

		public override string ToString()
		{
			return _name;
		}

	}

	/// <summary>
	/// Summary description for TemplateBrowser.
	/// </summary>
	public class TemplateBrowser
	{
		string _templateFolder;

		public TemplateBrowser(string templateFolder)
		{
			_templateFolder = templateFolder;
		}

		public TemplateInfo[] ReadTemplates()
		{
			ArrayList result = new ArrayList();
			if(Directory.Exists(_templateFolder))
			{
				foreach(string dir in Directory.GetDirectories(_templateFolder))
				{
					string templateFile = Path.Combine(dir, "template.xml");
					if( File.Exists(templateFile ) )
					{
						XmlTextReader reader = new XmlTextReader(templateFile);
						try
						{
							reader.Read();
							reader.ReadStartElement("Template");
							reader.ReadStartElement("TemplateData");
							reader.ReadStartElement("Name");
							string name = reader.ReadString();
							DirectoryInfo directoryInfo = new DirectoryInfo(dir);
							TemplateInfo templateInfo = new TemplateInfo(name, directoryInfo.Name );
							result.Add(templateInfo);
						}
						finally
						{
							reader.Close();
						}
					}
				}
			}
			return (TemplateInfo[])result.ToArray(typeof(TemplateInfo));
		}
	}
}
