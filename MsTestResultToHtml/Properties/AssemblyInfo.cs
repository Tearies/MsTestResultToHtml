using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CommandLine;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MsTestResultToHtml")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MsTestResultToHtml")]
[assembly: AssemblyCopyright("Copyright ©  2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("62216c25-7c5c-42ab-9c02-4019dc1436fc")]

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
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyUsage(
    "MsTestResultToHtml.Console.exe TestResult.xml --html",
    "MsTestResultToHtml.Console.exe TestResult.xml --html -o path/to/generated/report",
    "MsTestResultToHtml.Console.exe TestResult.xml --html -a path/to/screenshots -o path/to/generated/report"
)]