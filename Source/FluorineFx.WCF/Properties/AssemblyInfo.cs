using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("FluorineFx.WCF")]
[assembly: AssemblyDescription("FluorineFx for WCF integration")]
#if DEBUG
[assembly: AssemblyConfiguration("FluorineFx for WCF integration [Debug build]")]
#else
[assembly: AssemblyConfiguration("FluorineFx for WCF integration [Retail]")]
#endif

[assembly: AssemblyCompany("FluorineFx.com")]
[assembly: AssemblyProduct("FluorineFx.WCF")]
[assembly: AssemblyCopyright("FluorineFx.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.CLSCompliant(true)]
// Configure log4net using the .log4net file
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("3043d536-7289-47a6-aca1-73900f06ea50")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]
