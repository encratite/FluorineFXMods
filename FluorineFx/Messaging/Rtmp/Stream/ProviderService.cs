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
using System.Collections;
using log4net;
using FluorineFx.Configuration;
using FluorineFx.Messaging.Api.Messaging;
using FluorineFx.Messaging.Api.Stream;
using FluorineFx.Messaging.Api;
using FluorineFx.Messaging.Rtmp.IO;
using FluorineFx.Messaging.Rtmp.Stream.Provider;

namespace FluorineFx.Messaging.Rtmp.Stream
{
    class ProviderService : IProviderService
    {
        private static ILog log = LogManager.GetLogger(typeof(ProviderService));

        #region IProviderService Members

        public void Start(ConfigurationSection configuration)
        {
        }

        public void Shutdown()
        {
        }

        public IMessageInput GetProviderInput(IScope scope, string name)
        {
            IMessageInput msgIn = GetLiveProviderInput(scope, name, false);
            if (msgIn == null)
                return GetVODProviderInput(scope, name);
            return msgIn;
        }

        public IMessageInput GetLiveProviderInput(IScope scope, string name, bool needCreate)
        {
		    IBasicScope basicScope = scope.GetBasicScope(Constants.BroadcastScopeType, name);
		    if (basicScope == null) 
            {
			    if (needCreate) 
                {
				    lock(scope.SyncRoot)
                    {
					    // Re-check if another thread already created the scope
					    basicScope = scope.GetBasicScope(Constants.BroadcastScopeType, name);
					    if (basicScope == null) 
                        {
						    basicScope = new BroadcastScope(scope, name);
						    scope.AddChildScope(basicScope);
					    }
				    }
			    } 
                else
				    return null;
		    }
		    if (!(basicScope is IBroadcastScope))
			    return null;
            return basicScope as IBroadcastScope;
        }

        public IMessageInput GetVODProviderInput(IScope scope, string name)
        {
            FileInfo file = GetVODProviderFile(scope, name);
            if (file == null)
                return null;
            IPipe pipe = new InMemoryPullPullPipe();
            pipe.Subscribe(new FileProvider(scope, file), null);
            return pipe;
        }

        public FileInfo GetVODProviderFile(IScope scope, String name)
        {
            FileInfo file = null;
            try
            {
                log.Info("GetVODProviderFile scope path: " + scope.ContextPath + " name: " + name);
                file = GetStreamFile(scope, name);
            }
            catch (IOException ex)
            {
                log.Error("Problem getting file: " + name, ex);
            }
            if (file == null || !file.Exists)
                return null;
            return file;
        }

        public bool RegisterBroadcastStream(IScope scope, string name, IBroadcastStream broadcastStream)
        {
		    bool status = false;
		    lock(scope.SyncRoot) 
            {
			    IBasicScope basicScope = scope.GetBasicScope(Constants.BroadcastScopeType, name);
			    if (basicScope == null) 
                {
				    basicScope = new BroadcastScope(scope, name);
				    scope.AddChildScope(basicScope);
			    }
			    if (basicScope is IBroadcastScope) 
                {
                    (basicScope as IBroadcastScope).Subscribe(broadcastStream.Provider, null);
				    status = true;
			    }
		    }
		    return status;
        }

        public IEnumerator GetBroadcastStreamNames(IScope scope)
        {
            return scope.GetBasicScopeNames(Constants.BroadcastScopeType);
        }

        public bool UnregisterBroadcastStream(IScope scope, string name)
        {
		    bool status = false;
		    lock(scope.SyncRoot) 
            {
			    IBasicScope basicScope = scope.GetBasicScope(Constants.BroadcastScopeType, name);
			    if (basicScope is IBroadcastScope) 
                {
				    scope.RemoveChildScope(basicScope);
				    status = true;
			    }
		    }
		    return status;
        }

        #endregion

	    private FileInfo GetStreamFile(IScope scope, String name)
        {
            IStreamableFileFactory factory = ScopeUtils.GetScopeService(scope, typeof(IStreamableFileFactory)) as IStreamableFileFactory;
            if (name.IndexOf(':') == -1 && name.IndexOf('.') == -1) 
            {
			    // Default to .flv files if no prefix and no extension is given.
			    name = "flv:" + name;
		    }
		    log.Info("GetStreamFile null check - factory: " + factory + " name: " + name);
		    foreach(IStreamableFileService service in factory.GetServices()) 
            {
			    if (name.StartsWith(service.Prefix + ':')) 
                {
				    name = service.PrepareFilename(name);
				    break;
			    }
		    }
            IStreamFilenameGenerator filenameGenerator = ScopeUtils.GetScopeService(scope, typeof(IStreamFilenameGenerator)) as IStreamFilenameGenerator;
		    string filename = filenameGenerator.GenerateFilename(scope, name, GenerationType.PLAYBACK);
		    FileInfo file;
		    if(filenameGenerator.ResolvesToAbsolutePath) 
			    file = new FileInfo(filename);
		    else 
			    file = scope.Context.GetResource(filename).File;
		    return file;
	    }     
    }
}
