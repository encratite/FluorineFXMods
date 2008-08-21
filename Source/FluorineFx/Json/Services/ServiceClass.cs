//JSON RPC based on Jayrock - JSON and JSON-RPC for Microsoft .NET Framework and Mono
//http://jayrock.berlios.de/
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using FluorineFx.Util;

namespace FluorineFx.Json.Services
{
    /// <summary>
    /// This type supports the Fluorine infrastructure and is not intended to be used directly from your code.
    /// </summary>
    public sealed class ServiceClass
    {
        private readonly string _serviceName;
        private readonly string _description;
        private readonly Hashtable _methods;
        
        internal ServiceClass(Type type)
        {
            _serviceName = type.Name;
            _description = null;
            // Set up methods and their names.
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            _methods = new Hashtable();
            foreach (MethodInfo methodInfo in publicMethods)
            {
                if (ShouldBuild(methodInfo))
                {
                    Method method = Method.FromMethodInfo(methodInfo);
                    if (_methods.Contains(method.Name))
                        throw new DuplicateMethodException(string.Format("The method '{0}' cannot be exported as '{1}' because this name has already been used by another method on the '{2}' service.", method.Name, method.Name, _serviceName));
                    _methods.Add(method.Name, method);
                }
            }
        }

        private static bool ShouldBuild(MethodInfo method)
        {
            Debug.Assert(method != null);
            return !method.IsAbstract && Attribute.IsDefined(method, typeof(JsonRpcMethodAttribute));
        }

        public string Name
        {
            get { return _serviceName; }
        }

        public string Description
        {
            get { return _description; }
        }

        public ICollection GetMethods()
        {
            return _methods.Values;
        }

        public Method FindMethodByName(string name)
        {
            return _methods[name] as Method;
        }

        public Method GetMethodByName(string name)
        {
            Method method = FindMethodByName(name);
            if (method == null)
                throw new MissingMethodException(this.Name, name);
            return method;
        }
    }
}

