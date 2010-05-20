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
using System.Web;

namespace FluorineFx.Hosting
{
	[Flags]
	internal enum VirtualPathOptions
	{
		AllowAbsolutePath = 4,
		AllowAllPath = 0x1c,
		AllowAppRelativePath = 8,
		AllowNull = 1,
		AllowRelativePath = 0x10,
		EnsureTrailingSlash = 2,
		FailIfMalformed = 0x20
	}


	/// <summary>
	/// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
	/// </summary>
    [Serializable]
	sealed class VirtualPath : IComparable
	{
		private static readonly char[] IllegalVirtualPathChars;
		internal static VirtualPath RootVirtualPath;

		private string _appRelativeVirtualPath;
		private string _virtualPath;

		static VirtualPath()
		{
			IllegalVirtualPathChars = new char[] { ':', '?', '*', '\0' };
			RootVirtualPath = Create("/");
		}

		private VirtualPath()
		{
		}

		private VirtualPath(string virtualPath)
		{
			if (UrlPath.IsAppRelativePath(virtualPath))
				_appRelativeVirtualPath = virtualPath;
			else
				_virtualPath = virtualPath;
		}
 
		private static bool ContainsIllegalVirtualPathChars(string virtualPath)
		{
			return (virtualPath.IndexOfAny(IllegalVirtualPathChars) >= 0);
		}

		public static VirtualPath Create(string virtualPath)
		{
			return Create(virtualPath, VirtualPathOptions.AllowAllPath);
		}

		public static VirtualPath CreateNonRelative(string virtualPath)
		{
			return Create(virtualPath, VirtualPathOptions.AllowAppRelativePath | VirtualPathOptions.AllowAbsolutePath);
		}

		public static VirtualPath CreateNonRelativeTrailingSlash(string virtualPath)
		{
			return Create(virtualPath, VirtualPathOptions.AllowAppRelativePath | VirtualPathOptions.AllowAbsolutePath | VirtualPathOptions.EnsureTrailingSlash);
		}

        public static VirtualPath CreateAbsolute(string virtualPath)
        {
            return Create(virtualPath, VirtualPathOptions.AllowAbsolutePath);
        }

		public static VirtualPath Create(string virtualPath, VirtualPathOptions options)
		{
			if (virtualPath != null)
				virtualPath = virtualPath.Trim();

			if (StringUtil.IsNullOrEmpty(virtualPath))
			{
				if ((options & VirtualPathOptions.AllowNull) == 0)
					throw new ArgumentNullException("virtualPath");
				return null;
			}
		    if (ContainsIllegalVirtualPathChars(virtualPath))
                throw new Exception(string.Format("Invalid virtual path {0}", new object[] { virtualPath }));
		    string tmp = UrlPath.FixVirtualPathSlashes(virtualPath);
			if (((options & VirtualPathOptions.FailIfMalformed) != 0) && !ReferenceEquals(virtualPath, tmp))
			{
                throw new Exception(string.Format("Invalid virtual path", new object[] { virtualPath }));
			}
			virtualPath = tmp;
			if ((options & VirtualPathOptions.EnsureTrailingSlash) != 0)
			{
				virtualPath = UrlPath.AppendSlashToPathIfNeeded(virtualPath);
			}
			VirtualPath path = new VirtualPath();
			if (UrlPath.IsAppRelativePath(virtualPath))
			{
				virtualPath = UrlPath.ReduceVirtualPath(virtualPath);
				if (virtualPath[0] == '~')
				{
					if ((options & VirtualPathOptions.AllowAppRelativePath) == 0)
					{
						throw new ArgumentException(string.Format("The application relative virtual path '{0}' is not allowed here.", new object[] { virtualPath }));
					}
					path._appRelativeVirtualPath = virtualPath;
					return path;
				}
				if ((options & VirtualPathOptions.AllowAbsolutePath) == 0)
				{
					throw new ArgumentException(string.Format("The absolute virtual path '{0}' is not allowed here.", new object[] { virtualPath }));
				}
				path._virtualPath = virtualPath;
				return path;
			}
		    if (virtualPath != null)
		    {
		        if (virtualPath[0] != '/')
		        {
		            if ((options & VirtualPathOptions.AllowRelativePath) == 0)
		            {
		                throw new ArgumentException(string.Format("The relative virtual path '{0}' is not allowed here.", new object[] { virtualPath }));
		            }
		            path._virtualPath = virtualPath;
		            return path;
		        }
		        if ((options & VirtualPathOptions.AllowAbsolutePath) == 0)
		        {
		            throw new ArgumentException(string.Format("The absolute virtual path '{0}' is not allowed here.", new object[] { virtualPath }));
		        }
		        path._virtualPath = UrlPath.ReduceVirtualPath(virtualPath);
		    }
		    return path;
		}


		#region IComparable Members

		public int CompareTo(object obj)
		{
			VirtualPath path = obj as VirtualPath;
			if (path == null)
				throw new ArgumentException();
			if (path == this)
				return 0;
			return String.Compare(VirtualPathString, path.VirtualPathString, true);
		}

		#endregion

		internal static string GetVirtualPathString(VirtualPath virtualPath)
		{
			if (virtualPath != null)
				return virtualPath.VirtualPathString;
			return null;
		}

		public string VirtualPathString
		{
			get
			{
				if (_virtualPath == null)
				{
				    if (FluorineRuntime.AppDomainAppVirtualPathObject == null)
                        throw new Exception(string.Format("The application relative virtual path '{0}' cannot be made absolute, because the path to the application is not known.", new object[] { _appRelativeVirtualPath }));
                    

				    if (_appRelativeVirtualPath.Length == 1)
				        _virtualPath = FluorineRuntime.AppDomainAppVirtualPath;
				    else
				        _virtualPath = FluorineRuntime.AppDomainAppVirtualPathString + _appRelativeVirtualPath.Substring(2);
				}
				return _virtualPath;
			}
		}

		internal static string GetVirtualPathStringNoTrailingSlash(VirtualPath virtualPath)
		{
		    return virtualPath != null ? virtualPath.VirtualPathStringNoTrailingSlash : null;
		}

	    internal string VirtualPathStringNoTrailingSlash
		{
			get
			{
				return UrlPath.RemoveSlashFromPathIfNeeded(VirtualPathString);
			}
		}
	}
}
