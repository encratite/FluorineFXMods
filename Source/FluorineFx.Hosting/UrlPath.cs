/*
	FluorineFx open source library 
	Copyright (C) 2007-2010 Zoltan Csibi, zoltan@TheSilentGroup.com, FluorineFx.com 
	
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
using System.Text;
using System.Collections;
using System.Web;

namespace FluorineFx.Hosting
{
	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
	sealed class UrlPath
	{
		internal const char AppRelativeCharacter = '~';
		internal const string AppRelativeCharacterString = "~/";
		private static char[] _slashChars;

		static UrlPath()
		{
			_slashChars = new char[] { '\\', '/' };
		}

		public static string FixVirtualPathSlashes(string virtualPath)
		{
			virtualPath = StringUtil.Replace(virtualPath, '\\', '/');
			while (true)
			{
				string text = virtualPath.Replace("//", "/");
				if (text == virtualPath)
					return virtualPath;
				virtualPath = text;
			}
		}

		internal static string AppendSlashToPathIfNeeded(string path)
		{
			if (path == null)
				return null;
			int length = path.Length;
			if ((length != 0) && (path[length - 1] != '/'))
				path = path + '/';
			return path;
		}

		internal static bool IsAppRelativePath(string path)
		{
			if (path == null)
				return false;
			int length = path.Length;
			if (length == 0)
				return false;
			if (path[0] != '~')
				return false;
			if ((length != 1) && (path[1] != '\\'))
				return (path[1] == '/');
			return true;
		}

		internal static string ReduceVirtualPath(string path)
		{
			int length = path.Length;
			int startIndex = 0;
			while (true)
			{
				startIndex = path.IndexOf('.', startIndex);
				if (startIndex < 0)
					return path;
				if (((startIndex == 0) || (path[startIndex - 1] == '/')) && ((((startIndex + 1) == length) || (path[startIndex + 1] == '/')) || ((path[startIndex + 1] == '.') && (((startIndex + 2) == length) || (path[startIndex + 2] == '/')))))
				{
					break;
				}
				startIndex++;
			}
			ArrayList list = new ArrayList();
			StringBuilder builder = new StringBuilder();
			startIndex = 0;
			do
			{
				int i = startIndex;
				startIndex = path.IndexOf('/', i + 1);
				if (startIndex < 0)
				{
					startIndex = length;
				}
				if ((((startIndex - i) <= 3) && ((startIndex < 1) || (path[startIndex - 1] == '.'))) && (((i + 1) >= length) || (path[i + 1] == '.')))
				{
					if ((startIndex - i) == 3)
					{
						if (list.Count == 0)
							throw new Exception("Cannot exit up top directory");
						if ((list.Count == 1) && IsAppRelativePath(path))
						{
							return ReduceVirtualPath(MakeVirtualPathAppAbsolute(path));
						}
						builder.Length = (int) list[list.Count - 1];
						list.RemoveRange(list.Count - 1, 1);
					}
				}
				else
				{
					list.Add(builder.Length);
					builder.Append(path, i, startIndex - i);
				}
			}
			while (startIndex != length);

			string text = builder.ToString();
			if (text.Length != 0)
				return text;

			if ((length > 0) && (path[0] == '/'))
				return "/";
			return ".";
		}

		internal static string MakeVirtualPathAppAbsolute(string virtualPath)
		{
			return MakeVirtualPathAppAbsolute(virtualPath, FluorineRuntime.AppDomainAppVirtualPathString);
		}

		internal static string MakeVirtualPathAppAbsolute(string virtualPath, string applicationPath)
		{
			if ((virtualPath.Length == 1) && (virtualPath[0] == '~'))
				return applicationPath;

			if (((virtualPath.Length >= 2) && (virtualPath[0] == '~')) && ((virtualPath[1] == '/') || (virtualPath[1] == '\\')))
			{
				if (applicationPath.Length > 1)
					return (applicationPath + virtualPath.Substring(2));
				return ("/" + virtualPath.Substring(2));
			}
			if(!IsRooted(virtualPath))
				throw new ArgumentOutOfRangeException("virtualPath");

			return virtualPath;
		}

		internal static bool IsRooted(string basepath)
		{
			if (!StringUtil.IsNullOrEmpty(basepath) && (basepath[0] != '/'))
				return (basepath[0] == '\\');
			return true;
		}

		internal static string RemoveSlashFromPathIfNeeded(string path)
		{
			if (StringUtil.IsNullOrEmpty(path))
				return null;
			int length = path.Length;
			if ((length > 1) && (path[length - 1] == '/'))
			{
				return path.Substring(0, length - 1);
			}
			return path;
		}
	}
}
