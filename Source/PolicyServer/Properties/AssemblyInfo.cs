using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("FluorineFx Silverlight PolicyServer")]
#if DEBUG
[assembly: AssemblyDescription("FluorineFx Silverlight PolicyServer [Debug build]")]
#else
[assembly: AssemblyDescription("FluorineFx Silverlight PolicyServer [Retail]")]
#endif
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif
[assembly: AssemblyCompany("FluorineFx.com")]
[assembly: AssemblyProduct("FluorineFx")]
[assembly: AssemblyCopyright("FluorineFx.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("5fff76e0-f882-4a3c-b98c-4fb48e93da55")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

// Configure log4net using the .log4net file
// The config file will be watched for changes.
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

