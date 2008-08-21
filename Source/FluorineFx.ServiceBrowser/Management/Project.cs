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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

using FluorineFx.Management.Data;
using FluorineFx.Management.Web;
using FluorineFx.Util;
using FluorineFx.ServiceBrowser.Sql;

namespace FluorineFx.Management
{
	/// <summary>
	/// Summary description for Project.
	/// </summary>
	[Serializable]
	public class Project : NamedObject
	{
        private string _applicationRoot;
        //private string _applicationVirtualPath;
        private string _applicationUrl;
        private Uri _uri;
        private AssemblyDescriptor[] _assemblies;
        private string[] _assemblyPaths;
        private string _contextRoot;

        DataDomain[] _dataDomains;
        DataAssembler[] _dataAssemblers;

        string _package;
        string[] _packagePath;
        bool _locked;
        bool _requiresAuthentication;

		Application[] _applications;

        public Project()
        {
            //for serialization
            _assemblies = new AssemblyDescriptor[0];
            _applications = new Application[0];
            _dataDomains = new DataDomain[0];
            _dataAssemblers = new DataAssembler[0];
        }

        public Project(string applicationUrl, string url, string applicationRoot, /*string applicationVirtualPath, */string[] assemblyPaths)
		{
            _uri = new Uri(url);
            _applicationRoot = applicationRoot;
            //_applicationVirtualPath = applicationVirtualPath;
            _applicationUrl = applicationUrl;
            _assemblyPaths = assemblyPaths;

            _assemblies = new AssemblyDescriptor[0];
			_applications = new Application[0];
			_dataDomains = new DataDomain[0];
            _dataAssemblers = new DataAssembler[0];
		}


        [XmlIgnore]
        [Transient]
        public Uri Uri
        {
            get { return _uri; }
        }

        public string Url
        {
            get { return _uri.ToString(); }
            set { _uri = new Uri(value); }
        }

        public string ContextRoot
        {
            get { return _contextRoot; }
            set { _contextRoot = value; }
        }

        public string ApplicationUrl
        {
            get { return _applicationUrl; }
            set { _applicationUrl = value; }
        }

        //[XmlIgnore]
        public string ApplicationRoot
        {
            get { return _applicationRoot; }
            set { _applicationRoot = value; }
        }

        //[XmlIgnore]
        public string[] AssemblyPaths
        {
            get { return _assemblyPaths; }
            set { _assemblyPaths = value; }
        }

        [XmlElement(Type = typeof(AssemblyDescriptor))]
        public AssemblyDescriptor[] Assemblies
        {
            get { return _assemblies; }
            set { _assemblies = value; }
        }

        [XmlElement(Type = typeof(DataDomain))]
		public DataDomain[] DataDomains
		{
			get{ return _dataDomains; }
			set{ _dataDomains = value; }
		}

        [XmlElement(Type = typeof(DataAssembler))]
        public DataAssembler[] DataAssemblers
        {
            get { return _dataAssemblers; }
            set { _dataAssemblers = value; }
        }

		public bool Contains(DataDomain dataDomain)
		{
			foreach(DataDomain dataDomainTmp in _dataDomains)
			{
				if( dataDomainTmp.DomainUrl.Url == dataDomain.DomainUrl.Url )
					return true;
			}
			return false;
		}

        public DataDomain GetDataDomain(string url)
        {
            foreach (DataDomain dataDomain in _dataDomains)
            {
                if (dataDomain.DomainUrl.Url == url)
                    return dataDomain;
            }
            return null;
        }

		public void AddDataDomain(DataDomain dataDomain)
		{
			if( !Contains(dataDomain) )
			{
                _dataDomains = ArrayUtils.Resize(_dataDomains, _dataDomains.Length + 1) as DataDomain[];
				_dataDomains[_dataDomains.Length-1] = dataDomain;
			}
		}

		public void RemoveDataDomain(string url)
		{
			for(int i = 0; i < _dataDomains.Length; i++)
			{
				if( url == _dataDomains[i].DomainUrl.Url )
				{
					Array.Copy(_dataDomains, i+1, _dataDomains, i, _dataDomains.Length-1 - i );
                    _dataDomains = ArrayUtils.Resize(_dataDomains, _dataDomains.Length - 1) as DataDomain[];
					return;
				}
			}
		}

        public bool Contains(DataAssembler dataAssembler)
        {
            if (_dataAssemblers == null)
                return false;
            foreach (DataAssembler dataAssemblerTmp in _dataAssemblers)
            {
                if (dataAssemblerTmp.Select == dataAssembler.Select)
                    return true;
            }
            return false;
        }

        public void AddDataAssembler(DataAssembler dataAssembler)
        {
            if (_dataAssemblers == null)
                _dataAssemblers = new DataAssembler[0];
            _dataAssemblers = ArrayUtils.Resize(_dataAssemblers, _dataAssemblers.Length + 1) as DataAssembler[];
            _dataAssemblers[_dataAssemblers.Length - 1] = dataAssembler;
        }

        public DataAssembler CreateDataAssembler(string url, string query)
        {
            DataDomain dataDomain = GetDataDomain(url);
            DataAssembler dataAssembler = DataAssembler.FromQuery(dataDomain, query);
            if( dataAssembler != null )
                AddDataAssembler(dataAssembler);
            return dataAssembler;
        }

        public DataAssembler RemoveDataAssembler(string id)
        {
            if (_dataAssemblers == null)
                return null;
            Guid guid = new Guid(id);
            for (int i = 0; i < _dataAssemblers.Length; i++)
            {
                if (guid == _dataAssemblers[i].Guid)
                {
                    DataAssembler dataAssembler = _dataAssemblers[i];
                    Array.Copy(_dataAssemblers, i + 1, _dataAssemblers, i, _dataAssemblers.Length - 1 - i);
                    _dataAssemblers = ArrayUtils.Resize(_dataAssemblers, _dataAssemblers.Length - 1) as DataAssembler[];
                    return dataAssembler;
                }
            }
            return null;
        }

        public DataDomain GetAssemblerDataDomain(DataAssembler dataAssembler)
        {
            DataDomain dataDomain = GetDataDomain(dataAssembler.DomainUrl);
            return dataDomain;
        }

        public bool Contains(Application application)
        {
            foreach (Application applicationTmp in _applications)
            {
                if (applicationTmp.Name == application.Name)
                    return true;
            }
            return false;
        }

        public void AddApplication(Application application)
        {
            if (!Contains(application))
            {
                _applications = ArrayUtils.Resize(_applications, _applications.Length + 1) as Application[];
                _applications[_applications.Length - 1] = application;
            }
        }

        public void ClearApplications()
        {
            _applications = new Application[0];
        }

		public Application[] Applications
		{
			get{ return _applications; }
			set{ _applications = value; }
		}

		public bool Locked
		{
			get{ return _locked; }
			set{ _locked = value; }
		}

        public bool RequiresAuthentication
        {
            get { return _requiresAuthentication; }
            set { _requiresAuthentication = value; }
        }

		public string Package
		{
			get { return _package; }
			set
			{ 
				_package = value;
				_packagePath = _package.Split(new char[] {'.'});
			}
		}

		public string[] PackagePath
		{
			get{ return _packagePath; }
			set{ _packagePath = value; }
		}

		public void Save(string filename)
		{
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Project));
				using( StreamWriter writer = new StreamWriter(filename) )
				{
					serializer.Serialize(writer, this);
					writer.Close();
				}
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

		public static Project Load(string filename)
		{
			XmlSerializer serializer = new XmlSerializer(typeof(Project));
			using( StreamReader reader = new StreamReader(filename) )
			{
				return serializer.Deserialize(reader) as Project;
			}
		}


        public TypeDescriptor GetType(object type)
        {
            string typeName = type.ToString();
            foreach (AssemblyDescriptor assemblyDescriptor in _assemblies)
            {
                foreach (TypeDescriptor typeDescriptor in assemblyDescriptor.Types)
                    if (typeDescriptor.FullName == typeName)
                        return typeDescriptor;
            }
            return null;
        }

        public void Build()
        {
            Build(new Type[0]);
        }

        public void Build(Type[] excludedTypes)
        {
            Build(excludedTypes, new Type[0], true);
        }

        public void Build(Type[] excludedTypes, Type[] attributes, bool includeEmptyAssemblies)
        {
            Hashtable typeDescriptorDictionary = new Hashtable();
            ArrayList result = new ArrayList();
            foreach (string path in _assemblyPaths)
            {
                //Uri uri = new Uri( tmp );
                //string path = uri.LocalPath;

                ArrayList tmpResult = BuildAssemblyDescriptors(path, excludedTypes, attributes, typeDescriptorDictionary);
                foreach (AssemblyDescriptor assemblyDescriptor1 in tmpResult)
                {
                    bool found = false;
                    foreach (AssemblyDescriptor assemblyDescriptor2 in result)
                    {
                        if (assemblyDescriptor1.FullName == assemblyDescriptor2.FullName)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                        result.Add(assemblyDescriptor1);
                }
                if (!includeEmptyAssemblies)
                {
                    for (int i = result.Count - 1; i >= 0; i--)
                    {
                        AssemblyDescriptor assemblyDescriptor = result[i] as AssemblyDescriptor;
                        if (assemblyDescriptor.Types == null || assemblyDescriptor.Types.Length == 0)
                            result.RemoveAt(i);
                    }
                }
            }
            result.AddRange(BuildWebServceAssemblyDescriptors(_applicationRoot, typeDescriptorDictionary));
            _assemblies = result.ToArray(typeof(AssemblyDescriptor)) as AssemblyDescriptor[];

            //Detect ActionScript types too for our TypeDescriptors
            MapTypes();
        }

        private ArrayList BuildAssemblyDescriptors(string path, Type[] excludedTypes, Type[] attributes, Hashtable typeDescriptorDictionary)
        {
            ArrayList result = new ArrayList();
            foreach (string file in Directory.GetFiles(path, "*.dll"))
            {
                Assembly assembly = null;
                try
                {
                    assembly = Assembly.LoadFrom(file);
                }
                catch
                {
                }
                if (assembly != null)
                {
                    AssemblyDescriptor assemblyDescriptor = new AssemblyDescriptor();
                    assemblyDescriptor.Build(assembly, excludedTypes, attributes, typeDescriptorDictionary);
                    result.Add(assemblyDescriptor);
                }
            }
            foreach (string dir in Directory.GetDirectories(path))
            {
                if (dir.EndsWith("_vti_cnf"))
                    continue;
                result.AddRange(BuildAssemblyDescriptors(dir, excludedTypes, attributes, typeDescriptorDictionary));
            }
            return result;
        }

        private ArrayList BuildWebServceAssemblyDescriptors(string path, Hashtable typeDescriptorDictionary)
        {
            ArrayList result = new ArrayList();
            try
            {
                foreach (string file in Directory.GetFiles(path, "*.asmx"))
                {
                    string fileName = Path.GetFileName(file);
                    Assembly assembly = null;
                    try
                    {
                        assembly = WsdlHelper.GetAssemblyFromAsmx(fileName);
                        if (assembly != null)
                        {
                            AssemblyDescriptor assemblyDescriptor = new AssemblyDescriptor();
                            assemblyDescriptor.Build(assembly, true, typeDescriptorDictionary);
                            assemblyDescriptor.Name = fileName;
                            assemblyDescriptor.IsWebServiceProxy = true;
                            result.Add(assemblyDescriptor);
                        }
                    }
                    catch (Exception ex)
                    {
                        AssemblyDescriptor assemblyDescriptor = AssemblyDescriptor.GetNullAssemblyDescriptor(fileName);
                        assemblyDescriptor.Description = ex.ToString();
                        assemblyDescriptor.IsWebServiceProxy = true;
                        result.Add(assemblyDescriptor);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
            }

            try
            {
                foreach (string dir in Directory.GetDirectories(path))
                {
                    if (dir.EndsWith("_vti_cnf"))
                        continue;
                    result.AddRange(BuildWebServceAssemblyDescriptors(dir, typeDescriptorDictionary));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            return result;
        }

        internal void MapTypes()
        {
            foreach (AssemblyDescriptor assemblyDescriptor in _assemblies)
            {
                foreach (TypeDescriptor typeDescriptor in assemblyDescriptor.Types)
                {
                    ActionScriptType actionScriptType = TypeMapper.GetActionScriptType(typeDescriptor, this);
                    typeDescriptor.ActionScriptType = actionScriptType;

                    foreach (PropertyDescriptor propertyDescriptor in typeDescriptor.Properties)
                    {
                        actionScriptType = TypeMapper.GetActionScriptType(propertyDescriptor.Type, this);
                        propertyDescriptor.Type.ActionScriptType = actionScriptType;
                    }

                    foreach (FieldDescriptor fieldDescriptor in typeDescriptor.Fields)
                    {
                        actionScriptType = TypeMapper.GetActionScriptType(fieldDescriptor.Type, this);
                        fieldDescriptor.Type.ActionScriptType = actionScriptType;
                    }
                }
            }
        }
	}
}
