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
using FluorineFx.Configuration;

namespace FluorineFx.Messaging.Config
{
    /// <summary>
    /// Contains the properties for declaring a security constraint inline(destination) or globally.
    /// This is the <b>security-constraint</b> element in the services-config.xml file.
    /// </summary>
    public sealed class SecurityConstraint
	{
		string		_id;
		string		_authMethod;
		string[]	_roles;

		internal SecurityConstraint(string id, string authMethod, string[] roles)
		{
			_id = id;
			_authMethod = authMethod;
			_roles = roles;
		}
        /// <summary>
        /// Gets the identity of the security constraint.
        /// </summary>
		public string Id{ get{ return _id; } }
        /// <summary>
        /// Gets the authentication method of the security constraint.
        /// </summary>
		public string AuthMethod{ get{ return _authMethod; } }
        /// <summary>
        /// Gets the role memberships of the security constraint.
        /// </summary>
		public string[] Roles{ get{ return _roles; } }
	}

    /// <summary>
    /// Contains the properties for declaring a security constraint reference.
    /// This is the <b>security-constraint</b> element with a ref attribute in the services-config.xml file.
    /// </summary>
    public sealed class SecurityConstraintRef
	{
		string		_reference;

		internal SecurityConstraintRef(string reference)
		{
			_reference = reference;
		}
        /// <summary>
        /// Gets the security constraint reference.
        /// </summary>
		public string Reference{ get{ return _reference; } }
	}

    /// <summary>
    /// Contains the properties for declaring security setting.
    /// This is the <b>security</b> element in the services-config.xml file.
    /// </summary>
    public sealed class SecuritySettings : Hashtable
	{
        LoginCommandCollection _loginCommands;
		SecurityConstraintRef _securityConstraintRef;
		Hashtable _securityConstraints;
		/// <summary>
		/// Null for global security settings.
		/// </summary>
		DestinationSettings _destinationSettings;
		object _objLock = new object();

        private SecuritySettings()
        {
        }

		internal SecuritySettings(DestinationSettings destinationSettings)
		{
			_destinationSettings = destinationSettings;
			_securityConstraints = new Hashtable();
            _loginCommands = new LoginCommandCollection();
		}

        internal SecuritySettings(DestinationSettings destinationSettings, XmlNode securityNode)
		{
			_destinationSettings = destinationSettings;
			_securityConstraints = new Hashtable();
            _loginCommands = new LoginCommandCollection();
            foreach (XmlNode propertyNode in securityNode.SelectNodes("*"))
			{
				if( propertyNode.Name == "security-constraint" )
				{
					if( propertyNode.Attributes["ref"] != null )
					{
						_securityConstraintRef = new SecurityConstraintRef( propertyNode.Attributes["ref"].Value as string );
						continue;
					}
					string id = null;
					if( propertyNode.Attributes["id"] != null )
						id = propertyNode.Attributes["id"].Value as string;
					else
						id = Guid.NewGuid().ToString("N");
					string authMethod = "Custom";
					string[] roles = null;
					foreach(XmlNode node in propertyNode.SelectNodes("*"))
					{
						if( node.Name == "auth-method" )
						{
							authMethod = node.InnerXml;
						}
						if( node.Name == "roles" )
						{
							ArrayList rolesTmp = new ArrayList();
							foreach(XmlNode roleNode in node.SelectNodes("*"))
							{
								if( roleNode.Name == "role" )
								{
									rolesTmp.Add(roleNode.InnerXml);
								}
							}
							roles = rolesTmp.ToArray(typeof(string)) as string[];
						}
					}
					CreateSecurityConstraint(id, authMethod, roles);
				}
				if( propertyNode.Name == "login-command" )
				{
                    LoginCommandSettings loginCommandSettings = new LoginCommandSettings();
                    loginCommandSettings.Server = propertyNode.Attributes["server"].Value;
                    loginCommandSettings.Type = propertyNode.Attributes["class"].Value;
                    _loginCommands.Add(loginCommandSettings);
				}
			}
		}
        /// <summary>
        /// Gets the login commands included in the security section of the Flex services configuration file.
        /// </summary>
        public LoginCommandCollection LoginCommands { get { return _loginCommands; } }
        /// <summary>
        /// Gets the security constraints included in the security section of the Flex services configuration file.
        /// </summary>
		public Hashtable SecurityConstraints{ get{ return _securityConstraints; } }
        /// <summary>
        /// Gets the security constraints reference for a destination security section.
        /// </summary>
		public SecurityConstraintRef SecurityConstraintRef{ get{ return _securityConstraintRef; } }

        internal SecurityConstraint CreateSecurityConstraint(string id, string authMethod, string[] roles)
		{
			lock(_objLock)
			{
				if( !_securityConstraints.ContainsKey(id) )
				{
					SecurityConstraint securityConstraint = new SecurityConstraint( id, authMethod, roles );
					_securityConstraints[id] = securityConstraint;
					return securityConstraint;
				}
				else
					return _securityConstraints[id] as SecurityConstraint;
			}
		}
        /// <summary>
        /// Returns the role memberships from the security section.
        /// </summary>
        /// <returns></returns>
		public string[] GetRoles()
		{
			lock(_objLock)
			{
				if( this.SecurityConstraintRef != null && _destinationSettings != null )
				{
                    if (_destinationSettings.ServiceSettings.ServiceConfigSettings.SecuritySettings != null &&
                        _destinationSettings.ServiceSettings.ServiceConfigSettings.SecuritySettings.SecurityConstraints != null)
					{
                        SecurityConstraint securityConstraint = _destinationSettings.ServiceSettings.ServiceConfigSettings.SecuritySettings.SecurityConstraints[this.SecurityConstraintRef.Reference] as SecurityConstraint;
						if( securityConstraint != null )
							return securityConstraint.Roles;
						else
						{
                            string error = __Res.GetString(__Res.Security_ConstraintRefNotFound, this.SecurityConstraintRef.Reference);
							throw new UnauthorizedAccessException(error);
						}
					}
					else
						throw new UnauthorizedAccessException(__Res.GetString(__Res.Security_ConstraintRefNotFound));
				}
				else
				{
                    ArrayList roles = new ArrayList();
					foreach(DictionaryEntry entry in this.SecurityConstraints)
					{
						SecurityConstraint securityConstraint = entry.Value as SecurityConstraint;
                        roles.AddRange(securityConstraint.Roles);
					}
                    return roles.ToArray(typeof(string)) as string[];
				}
			}
		}
	}
}
