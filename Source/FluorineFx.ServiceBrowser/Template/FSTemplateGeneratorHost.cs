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
	/// Summary description for FSTemplateGeneratorHost.
	/// </summary>
	public class FSTemplateGeneratorHost : MarshalByRefObject, ITemplateGeneratorHost
	{
		string _outDirectory;
		Hashtable _globalContext;

		public FSTemplateGeneratorHost(Hashtable globalContext, string outDirectory)
		{
			_outDirectory = outDirectory;
			_globalContext = globalContext;
		}

		#region ITemplateGeneratorHost Members

		public void AddFile(string directory, string file, string content)
		{
			CheckDirectory(directory);
			string destFile = GetDestinationFile(directory, file);
			using( StreamWriter sw = new StreamWriter(destFile, false) )
			{
				sw.Write(content);
				sw.Flush();
				sw.Close();
			}
		}

		public void AddFile(string directory, string file)
		{
			CheckDirectory(directory);
			string destFile = GetDestinationFile(directory, file);
			File.Copy(file, destFile, true);
		}

		public Hashtable GetGlobalContext()
		{
			return _globalContext;
		}

		public void CreateDirectory(string directory)
		{
			CheckDirectory(directory);
		}

		public void Open()
		{
			//NI
		}

		public void Close()
		{
			//NI
		}

		#endregion

		private string RemoveTrailingSeparator(string directory)
		{
			if( directory != null && directory != string.Empty )
			{
				if( directory[0] == Path.DirectorySeparatorChar )
					return directory.Substring(1);
			}
			return directory;
		}

		private void CheckDirectory(string directory)
		{
			string path = Path.Combine(_outDirectory, RemoveTrailingSeparator(directory));
			if( !Directory.Exists(path) )
				Directory.CreateDirectory(path);
		}

		private string GetDestinationFile(string directory, string file)
		{
			string path = Path.Combine(_outDirectory, RemoveTrailingSeparator(directory));
			path = Path.Combine(path, Path.GetFileName(file));
			return path;
		}
	}
}
