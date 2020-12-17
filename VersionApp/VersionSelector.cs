using System;
using System.Collections.Generic;
using System.Reflection;

namespace VersionApp
{
    public static class VersionSelector
    {
        static Assembly versionAssembly;

        static readonly Dictionary<Version, Type> assemblyReferenceTypes = new Dictionary<Version, Type> 
        {
            { new Version("20.1.0"), typeof(v20_1_0.StartUp) },
            { new Version("20.1.1"), typeof(v20_1_1.StartUp) },
        };

        static Version currentVersion;

        public static string Version => currentVersion?.ToString();

        public static string VersionNameSpace => VersionAssembly.GetName().Name;

        public static Assembly VersionAssembly => versionAssembly ?? (versionAssembly = Assembly.GetAssembly(assemblyReferenceTypes[currentVersion]));

        public static void SetVersion(Version version)
        {
            versionAssembly = null;
            currentVersion = version;
        }
    }
}
