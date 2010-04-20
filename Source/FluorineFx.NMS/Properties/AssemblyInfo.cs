using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if (NET_1_1)
[assembly: AssemblyTitle("FluorineFx.NMS for .NET Framework 1.1")]
#elif (NET_2_0)
[assembly: AssemblyTitle("FluorineFx.NMS for .NET Framework 2.0")]
#elif (NET_3_5)
[assembly: AssemblyTitle("FluorineFx.NMS for .NET Framework 3.5")]
#else
[assembly: AssemblyTitle("FluorineFx.NMS")]
#endif

#if DEBUG
[assembly: AssemblyDescription("FluorineFx.NMS for .NET [Debug build]")]
#else
[assembly: AssemblyDescription("FluorineFx.NMS for .NET [Retail]")]
#endif

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif
[assembly: AssemblyCompany("FluorineFx.com")]
[assembly: AssemblyProduct("FluorineFx.NMS")]
[assembly: AssemblyCopyright("FluorineFx.com")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a65d63a3-50c0-484d-9598-d89282a5febf")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]

#if STRONG
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("..\\..\\..\\snk\\fluorine.snk")]
[assembly: AssemblyKeyName("")]
#endif
