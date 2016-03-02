#if DNXCORE50 || DNX451 || DNX452 || NETFX
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

namespace System.Linq.Dynamic
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AppDomain
    {
        public static AppDomain CurrentDomain { get; private set; }

        static AppDomain()
        {
            CurrentDomain = new AppDomain();
        }

#if DNXCORE50 || DNX451 || DNX452 || DOTNET5_4
        public Assembly[] GetAssemblies()
        {
            var folder = Directory.GetCurrentDirectory();

            var assemblies = new List<Assembly>();
            foreach (string filePath in Directory.EnumerateFiles(folder))
            {
                var file = new FileInfo(filePath);
                if (file.Extension == ".dll" || file.Extension == ".exe")
                {
                    var name = new AssemblyName { Name = Path.GetFileNameWithoutExtension(file.Name) };
                    var asm = Assembly.Load(name);
                    assemblies.Add(asm);
                }
            }

            return assemblies.ToArray();
        }
#else
        public Assembly[] GetAssemblies()
        {
            return GetAssemblyListAsync().Result.ToArray();
        }

        private async System.Threading.Tasks.Task<IEnumerable<Assembly>> GetAssemblyListAsync()
        {
            var folder = Package.Current.InstalledLocation;

            List<Assembly> assemblies = new List<Assembly>();
            foreach (StorageFile file in await folder.GetFilesAsync())
            {
                if (file.FileType == ".dll" || file.FileType == ".exe")
                {
                    AssemblyName name = new AssemblyName() { Name = Path.GetFileNameWithoutExtension(file.Name) };
                    Assembly asm = Assembly.Load(name);
                    assemblies.Add(asm);
                }
            }

            return assemblies;
        }
#endif
        public AssemblyBuilder DefineDynamicAssembly(AssemblyName name, AssemblyBuilderAccess access)
        {
            return AssemblyBuilder.DefineDynamicAssembly(name, access);
        }
    }
}
#endif