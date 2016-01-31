using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("System.Linq.Dynamic")]
[assembly: AssemblyCompany("Nathan Arnott")]
[assembly: AssemblyProduct("System.Linq.Dynamic")]

#if SILVERLIGHT
[assembly: AssemblyConfiguration("Silverlight")]
[assembly: AssemblyDescription("Adds support for Dynamic Linq string expressions, rather than lambda expressions. For Silverlight.")]
#elif NET35
[assembly: AssemblyConfiguration("Net35")]
[assembly: AssemblyDescription("Adds support for Dynamic Linq string expressions, rather than lambda expressions. For .Net 3.5 Framework.")]
#else
[assembly: AssemblyConfiguration("Net40")]
[assembly: AssemblyDescription("Adds support for Dynamic Linq string expressions, rather than lambda expressions. For .Net 4/4.5+ Framework.")]
#endif


[assembly: CLSCompliant(true)]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

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
[assembly: AssemblyVersion("2.0.0.*")]

[assembly: InternalsVisibleTo("System.Linq.Dynamic.Tests")]
[assembly: InternalsVisibleTo("System.Linq.Dynamic.dnx.Tests")]