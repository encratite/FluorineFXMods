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

using FluorineFx.Util;

namespace FluorineFx.Messaging.Config
{
    /// <summary>
    /// Contains the properties for configuring message channels.
    /// This is the <b>channel-definition</b> element in the services-config.xml file.
    /// </summary>
    public sealed class ChannelSettings : Hashtable
    {
        /// <summary>
        /// Context Root token.
        /// </summary>
        public const string ContextRoot = "{context.root}";
        public const string PollingEnabledKey = "polling-enabled";
        public const string PollingIntervalSecondsKey = "polling-interval-seconds";
        public const string BindAddressKey = "bind-address";
        public const string PollingIntervalMillisKey = "polling-interval-millis";
        public const string WaitIntervalMillisKey = "wait-interval-millis";
        public const string MaxWaitingPollRequestsKey = "max-waiting-poll-requests";

        UriBase _uri;
        string _id;
        string _endpointClass;
        string _endpointUri;
        int _maxWaitingPollRequests;
        int _waitIntervalMillis;

        internal ChannelSettings()
        {
            _maxWaitingPollRequests = 0;
            _waitIntervalMillis = 0;
        }

        internal ChannelSettings(string id, string endpointClass, string endpointUri)
            : this()
        {
            _id = id;
            _endpointClass = endpointClass;
            _endpointUri = endpointUri;
            _uri = new UriBase(_endpointUri);
        }

        internal ChannelSettings(string id, string endpointClass)
            : this()
        {
            _id = id;
            _endpointClass = endpointClass;
        }

        internal ChannelSettings(XmlNode channelDefinitionNode)
        {
            _id = channelDefinitionNode.Attributes["id"].Value;

            XmlNode endPointNode = channelDefinitionNode.SelectSingleNode("endpoint");
            _endpointClass = endPointNode.Attributes["class"].Value;
            _endpointUri = endPointNode.Attributes["uri"].Value;
            _uri = new UriBase(_endpointUri);

            XmlNode propertiesNode = channelDefinitionNode.SelectSingleNode("properties");
            if (propertiesNode != null)
            {
                foreach (XmlNode propertyNode in propertiesNode.SelectNodes("*"))
                {
                    this[propertyNode.Name] = propertyNode.InnerXml;
                }
            }

            if (this.ContainsKey(MaxWaitingPollRequestsKey))
                _maxWaitingPollRequests = System.Convert.ToInt32(this[MaxWaitingPollRequestsKey]);
            if (this.ContainsKey(WaitIntervalMillisKey))
                _waitIntervalMillis = System.Convert.ToInt32(this[WaitIntervalMillisKey]);
        }
        /// <summary>
        /// Gets or sets the identity of the message channel.
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Gets the message channel type.
        /// </summary>
        public string Class
        {
            get { return _endpointClass; }
        }
        /// <summary>
        /// Sets the endpoint URI of the channel definition.
        /// </summary>
        public string Uri
        {
            set
            {
                _uri = new UriBase(value);
            }
        }
        /// <summary>
        /// Optional channel property. Default value is false.
        /// </summary>
        public bool IsPollingEnabled
        {
            get
            {
                if (this.ContainsKey(PollingEnabledKey))
                    return System.Convert.ToBoolean(this[PollingEnabledKey]);
                return false;
            }
        }

        public int PollingIntervalSeconds
        {
            get
            {
                if (this.ContainsKey(PollingIntervalSecondsKey))
                    return System.Convert.ToInt32(this[PollingIntervalSecondsKey]);
                return 8;
            }
        }

        public string BindAddress
        {
            get
            {
                if (this.ContainsKey(BindAddressKey))
                    return this[BindAddressKey].ToString();
                return null;
            }
        }
        /// <summary>
        /// Optional channel property. Default value is 3000. This parameter specifies the number of milliseconds the client waits before polling the server again. 
        /// When polling-interval-millis is 0, the client polls as soon as it receives a response from the server with no delay.
        /// </summary>
        public int PollingIntervalMillis
        {
            get
            {
                if (this.ContainsKey(PollingIntervalMillisKey))
                    return System.Convert.ToInt32(this[PollingIntervalMillisKey]);
                return 3000;
            }
        }
        /// <summary>
        /// Optional endpoint property. Default value is 0. This parameter specifies the number of milliseconds the server poll response thread waits 
        /// for new messages to arrive when the server has no messages for the client at the time of poll request handling. 
        /// For this setting to take effect, you must use a nonzero value for the max-waiting-poll-requests property.
        /// 
        /// A value of 0 means that server does not wait for new messages for the client and returns an empty acknowledgment as usual. 
        /// A value of -1 means that server waits indefinitely until new messages arrive for the client before responding to the client poll request.
        /// The recommended value is 60000 milliseconds (one minute).
        /// </summary>
        public int WaitIntervalMillis
        {
            get
            {
                return _waitIntervalMillis;
            }
        }
        /// <summary>
        /// Optional endpoint property. Default value is 0. Specifies the maximum number of server poll response threads that can be in wait state. 
        /// When this limit is reached, the subsequent poll requests are treated as having zero wait-interval-millis.
        /// </summary>
        public int MaxWaitingPollRequests
        {
            get
            {
                return _maxWaitingPollRequests;
            }
        }
        
        /// <summary>
        /// Returns the endpoint URI of the channel definition.
        /// </summary>
        /// <returns>The endpoint URI representation of the channel definition.</returns>
        public UriBase GetUri()
        {
            return _uri;
        }

        internal bool Bind(string path, string contextPath)
        {
            // The context root maps requests to the Flex application.
            // For example, the context root in the following URL is /flex:
            // http://localhost:8700/flex/myApp.mxml
            //
            // In the Flex configuration files, the {context.root} token takes the place of 
            // the path to the Flex web application itself. If you are running your MXML apps 
            // inside http://localhost:8100/flex) then "/flex" is the {context.root}. 
            // The value of {context.root} includes the prefix "/". 
            // As a result, you are not required to add a forward slash before the {context.root} token.
            //
            // If {context.root} is used in a nonrelative path, it must not have a leading "/". 
            // For example, instead of this:
            // http://localhost/{context.root}
            // Do this:
            // http://localhost{context.root}

            if (_uri != null)
            {
                string endpointPath = _uri.Path;
                if (!endpointPath.StartsWith("/"))
                    endpointPath = "/" + endpointPath;
                if (contextPath == "/")
                    contextPath = string.Empty;
                if (endpointPath.IndexOf("/" + ChannelSettings.ContextRoot) != -1)
                {
                    //relative path
                    endpointPath = endpointPath.Replace("/" + ChannelSettings.ContextRoot, contextPath);
                }
                else
                {
                    //nonrelative path, but we do not handle these for now
                    endpointPath = endpointPath.Replace(ChannelSettings.ContextRoot, contextPath);
                }
                if (endpointPath.ToLower() == path.ToLower())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Returns a String that represents the current channel settings.
        /// </summary>
        /// <returns>A String that represents the current ChannelSettings.</returns>
        public override string ToString()
        {
            return "Channel id = " + _id + " uri: " + _uri.Uri + " endpointPath: " + _uri.Path;
        }
    }

    /// <summary>
    /// Strongly typed ChannelSettings collection.
    /// </summary>
    public sealed class ChannelSettingsCollection : CollectionBase
    {
        Hashtable _channelDictionary;

        /// <summary>
        /// Initializes a new instance of the ChannelSettingsCollection class.
        /// </summary>
        public ChannelSettingsCollection()
        {
            _channelDictionary = new Hashtable();
        }
        /// <summary>
        /// Adds a ChannelSettings to the collection.
        /// </summary>
        /// <param name="value">The ChannelSettings to add to the collection.</param>
        /// <returns>The position into which the new element was inserted.</returns>        
        public int Add(ChannelSettings value)
        {
            _channelDictionary[value.Id] = value;
            return List.Add(value);
        }
        /// <summary>
        /// Determines the index of a specific item in the collection. 
        /// </summary>
        /// <param name="value">The ChannelSettings to locate in the collection.</param>
        /// <returns>The index of value if found in the collection; otherwise, -1.</returns>
        public int IndexOf(ChannelSettings value)
        {
            return List.IndexOf(value);
        }
        /// <summary>
        /// Inserts a ChannelSettings item to the collection at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index at which value should be inserted.</param>
        /// <param name="value">The ChannelSettings to insert into the collection.</param>
        public void Insert(int index, ChannelSettings value)
        {
            _channelDictionary[value.Id] = value;
            List.Insert(index, value);
        }
        /// <summary>
        /// Removes the first occurrence of a specific ChannelSettings from the collection.
        /// </summary>
        /// <param name="value">The ChannelSettings to remove from the collection.</param>
        public void Remove(ChannelSettings value)
        {
            _channelDictionary.Remove(value.Id);
            List.Remove(value);
        }
        /// <summary>
        /// Determines whether the collection contains a specific ChannelSettings value.
        /// </summary>
        /// <param name="value">The ChannelSettings to locate in the collection.</param>
        /// <returns>true if the ChannelSettings is found in the collection; otherwise, false.</returns>
        public bool Contains(ChannelSettings value)
        {
            return List.Contains(value);
        }
        /// <summary>
        /// Gets or sets the ChannelSettings element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public ChannelSettings this[int index]
        {
            get
            {
                return List[index] as ChannelSettings;
            }
            set
            {
                List[index] = value;
            }
        }
        /// <summary>
        /// Gets or sets the ChannelSettings element with the specified key.
        /// </summary>
        /// <param name="key">The id of the ChannelSettings element to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        public ChannelSettings this[string key]
        {
            get
            {
                return _channelDictionary[key] as ChannelSettings;
            }
            set
            {
                _channelDictionary[key] = value;
            }
        }
    }
}