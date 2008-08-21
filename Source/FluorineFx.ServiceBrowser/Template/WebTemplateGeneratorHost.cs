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
using System.Text;

using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace FluorineFx.CodeGenerator
{
	/// <summary>
	/// Summary description for WebTemplateGeneratorHost.
	/// </summary>
	public class WebTemplateGeneratorHost : AbstractTemplateGeneratorHost
	{
		Stream			_outputStream;
		ZipOutputStream _zipOutput;
		ZipNameTransform _zipNameTransform;
		Hashtable		_globalContext;

		public WebTemplateGeneratorHost():this(new Hashtable())
		{
		}

		public WebTemplateGeneratorHost(Hashtable globalContext)
		{
			_globalContext = globalContext;
			_outputStream = new MemoryStream();
			_zipOutput = new ZipOutputStream(_outputStream); 
			_zipOutput.SetLevel(9);
			_zipNameTransform = new ZipNameTransform();
		}

		public WebTemplateGeneratorHost(Hashtable globalContext, string outDirectory)
		{
			_globalContext = globalContext;
			string fileName = Path.Combine(outDirectory, "output.zip");
			_outputStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
			_zipOutput = new ZipOutputStream(_outputStream); 
			_zipOutput.SetLevel(7);
		}

		public byte[] GetBuffer()
		{
			_zipOutput.Flush();
			if( _outputStream is MemoryStream )
				return (_outputStream as MemoryStream).ToArray();
			return null;
		}

		#region ITemplateGeneratorHost Members

		public override void Open()
		{
			base.Open();
		}

		public override void Close()
		{
			if( this.IsOpen )
			{
				_zipOutput.Close();
				_outputStream.Close();
			}
			base.Close();
		}

		public override void AddFile(string directory, string file, string content)
		{
			if( this.IsOpen )
			{
				if( content == null )
					content = string.Empty;
				file = Path.Combine(directory, file);
				file = _zipNameTransform.TransformFile(file);
				ZipEntry entry = new ZipEntry(file);
				System.Diagnostics.Trace.WriteLine("Adding file: " + file);

				UTF8Encoding utf8Encoding = new UTF8Encoding();
				byte[] buffer = utf8Encoding.GetBytes(content);
				entry.DateTime = DateTime.Now;
				entry.Size = buffer.Length;
				_zipOutput.PutNextEntry(entry);
				_zipOutput.Write(buffer, 0, buffer.Length);
				entry.Size = buffer.Length;
			}
		}

		public override void AddFile(string directory, string file)
		{
			if( this.IsOpen )
			{
				string fileName = Path.GetFileName(file);
				string outFile = Path.Combine(directory, fileName);
				outFile = _zipNameTransform.TransformFile(outFile);
				System.Diagnostics.Trace.WriteLine("Adding file: " + outFile);

				
				using(FileStream fileStream = File.OpenRead(file)) 
				{
					ZipEntry entry = new ZipEntry(outFile);
					entry.DateTime = DateTime.Now;
					entry.Size = fileStream.Length;
					_zipOutput.PutNextEntry(entry);
					StreamUtils.Copy(fileStream, _zipOutput, new byte[2048]);
				}
				/*				
				byte[] buffer = new byte[4096];
				using (FileStream fs = File.OpenRead(file)) 
				{
					ZipEntry entry = new ZipEntry(outFile);
					entry.DateTime = DateTime.Now;
					entry.Size = fs.Length;
					_zipOutput.PutNextEntry(entry);
					byte[] buffer = new byte[fs.Length];
					int bytesRead;
					do 
					{
						bytesRead = fs.Read(buffer, 0, buffer.Length);
						_zipOutput.Write(buffer, 0, bytesRead);
					} while ( bytesRead > 0 );
				}
				*/
			}
		}

		public override Hashtable GetGlobalContext()
		{
			return _globalContext;
		}

		public override void CreateDirectory(string directory)
		{
			if( this.IsOpen )
			{
				directory = _zipNameTransform.TransformDirectory(directory);
				System.Diagnostics.Trace.WriteLine("Adding directory: " + directory);
				ZipEntry entry = new ZipEntry(directory);
				_zipOutput.PutNextEntry(entry);
			}
		}

		#endregion
	}
}
