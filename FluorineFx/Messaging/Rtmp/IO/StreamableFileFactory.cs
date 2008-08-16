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
using System.IO;
using log4net;
using FluorineFx.Collections;
using FluorineFx.Configuration;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Rtmp.IO.Flv;

namespace FluorineFx.Messaging.Rtmp.IO
{
    /// <summary>
    /// Creates streamable file services.
    /// </summary>
    class StreamableFileFactory : IStreamableFileFactory
    {
        private static ILog log = LogManager.GetLogger(typeof(StreamableFileFactory));

        public StreamableFileFactory()
        {
            _services.Add(new FlvService());
        }

        /// <summary>
        /// Set of IStreamableFileService instances.
        /// </summary>
        private Set _services = new Set();

        public void SetServices(Set services)
        {
            _services = services;
        }

        #region IStreamableFileFactory Members

        public void Start(ConfigurationSection configuration)
        {
        }

        public void Shutdown()
        {
        }

        public IStreamableFileService GetService(FileInfo file)
        {
		    log.Info("Get service for file: " + file.Name);
		    // Return first service that can handle the passed file
		    foreach(IStreamableFileService service in _services)
            {
			    if (service.CanHandle(file)) 
                {
				    log.Info("Found service");
				    return service;
			    }
		    }
		    return null;
        }

        public Set GetServices()
        {
            log.Info("StreamableFileFactory get services.");
            return _services;
        }

        #endregion
    }
}
