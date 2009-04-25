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
using System.Web;
using System.Web.Caching;
using log4net;
using FluorineFx.Util;
using FluorineFx.IO;

namespace FluorineFx.IO.Mp3
{
    /// <summary>
    /// Handles mp3 files.
    /// </summary>
    [CLSCompliant(false)]
    public class Mp3File : IMp3File
    {
        private FileInfo _file;

        public Mp3File(FileInfo file)
        {
            _file = file;
	    }

        #region IStreamableFile Members

        public ITagReader GetReader()
        {
            return new Mp3Reader(_file);
        }

        public ITagWriter GetWriter()
        {
            return null;
        }

        public ITagWriter GetAppendWriter()
        {
            return null;
        }

        #endregion
    }
}
