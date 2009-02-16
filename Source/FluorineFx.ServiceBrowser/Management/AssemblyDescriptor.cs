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
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using log4net;

namespace FluorineFx.Management
{
	/// <summary>
	/// Summary description for AssemblyDescriptor.
	/// </summary>
	[Serializable]
	public class AssemblyDescriptor : NamedObject
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(AssemblyDescriptor));

		private string _fullName;
		private NamespaceCollection _namespaceCollection;
		private TypeDescriptor[] _types;
        private bool _isWebServiceProxy;

		public AssemblyDescriptor()
		{
			_namespaceCollection = new NamespaceCollection();
            _types = new TypeDescriptor[0];
		}

        public static AssemblyDescriptor GetNullAssemblyDescriptor(string name)
        {
            AssemblyDescriptor assemblyDescriptor = new AssemblyDescriptor();
            assemblyDescriptor.Name = name;
            return assemblyDescriptor;
        }

		public string FullName
		{
			get{ return _fullName; }
			set{ _fullName = value; }
		}

        [XmlIgnore]
        public Namespace[] NamespacesCollection
        {
            get
            {
                //For SB only
                ArrayList list = new ArrayList(_namespaceCollection.Values);
                return list.ToArray(typeof(Namespace)) as Namespace[];
            }
        }

		[Transient]
        //[XmlIgnore]
		public NamespaceCollection Namespaces
		{
			get{ return _namespaceCollection; }
			set
            { 
                _namespaceCollection = value;
                BuildNamespaceHierarchy();
            }
		}

		public TypeDescriptor[] Types
		{
			get{ return _types; }
			set
            { 
                _types = value;
                BuildNamespaceHierarchy();
            }
		}

        public bool IsWebServiceProxy
        {
            get { return _isWebServiceProxy; }
            set { _isWebServiceProxy = value; }
        }

		public TypeDescriptor GetType(object type)
		{
			string typeName = type.ToString();
			foreach(TypeDescriptor typeDescriptor in _types)
				if( typeDescriptor.FullName == typeName )
					return typeDescriptor;
			return null;
		}

        internal void Build(Assembly assembly, Hashtable typeDescriptorDictionary)
        {
            Build(assembly, false, typeDescriptorDictionary);
        }

        internal void Build(Assembly assembly, bool isWebServiceProxy, Hashtable typeDescriptorDictionary)
		{
            Build(assembly, isWebServiceProxy, new Type[0], new Type[0], typeDescriptorDictionary);
		}

        internal void Build(Assembly assembly, Type[] excludedTypes, Type[] attributes, Hashtable typeDescriptorDictionary)
        {
            Build(assembly, false, excludedTypes, attributes, typeDescriptorDictionary);
        }

        internal void Build(Assembly assembly, bool isWebServiceProxy, Type[] excludedTypes, Type[] attributes, Hashtable typeDescriptorDictionary)
		{
            _isWebServiceProxy = isWebServiceProxy;
			_fullName = assembly.FullName;
			_name = assembly.GetName().Name;

			Hashtable excludeTypesDictionary = new Hashtable();
			foreach(Type type in excludedTypes)
				excludeTypesDictionary.Add(type, null);

			ArrayList types = new ArrayList();
            try
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (excludeTypesDictionary.ContainsKey(type))
                        continue;
                    if (type.BaseType != null && excludeTypesDictionary.ContainsKey(type.BaseType))
                        continue;
                    //do not check accesibility with TypeHelper as the input custom attributes will filter
                    //if( !TypeHelper.GetTypeIsAccessible(type) )
                    //	continue;
                    //do not reflect servicebrowser classes                    
                    if (type.FullName.StartsWith("FluorineFx.") && !type.FullName.StartsWith(FluorineFx.Configuration.FluorineConfiguration.Instance.FluorineSettings.WsdlProxyNamespace))
                        continue;
                    bool match = attributes != null && attributes.Length > 0 ? false : true;
                    foreach (Type attributeType in attributes)
                    {
                        object[] attrs = type.GetCustomAttributes(attributeType, true);
                        if (attrs != null && attrs.Length > 0)
                        {
                            match = true;
                            break;
                        }
                    }
                    if (match)
                    {
                        TypeDescriptor typeDescriptor = new TypeDescriptor();
                        typeDescriptor.Build(type, typeDescriptorDictionary);
                        types.Add(typeDescriptor);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Error building assembly descriptor {0}", assembly.FullName), ex);
            }
			_types = types.ToArray(typeof(TypeDescriptor)) as TypeDescriptor[];
			BuildNamespaceHierarchy();
		}

		private void BuildNamespaceHierarchy()
		{
			for(int i = 0; i < _types.Length; i++)
			{
				TypeDescriptor typeDescriptor = _types[i] as TypeDescriptor;
				//_BuildNamespaceHierarchy(typeDescriptor, _namespaces);

				Namespace ns = null;
				if( !_namespaceCollection.Contains(typeDescriptor.Namespace) )
				{
					ns = new Namespace();
					ns.Name = typeDescriptor.Namespace;
					_namespaceCollection.Add(typeDescriptor.Namespace, ns);
				}
				else
					ns = _namespaceCollection[typeDescriptor.Namespace];
                if( !ns.Contains(typeDescriptor) )
				    ns.AddTypeDescriptor(typeDescriptor);
			}
		}
	}
}
