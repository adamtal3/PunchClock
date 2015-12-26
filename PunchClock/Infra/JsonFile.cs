using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace PunchClock.Infra
{
    public class JsonFile<T>
    {
        private static readonly object _syncRoot = new object();
        private const string _basePath = "Data\\";

        public JsonFile(string filename)
        {
            var dir = Path.Combine(AssemblyDirectory, _basePath);
            lock (_syncRoot)
            {
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            }
            FileName = filename;
            FilePath = Path.Combine(dir, filename + ".json");
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public bool Exists()
        {
            lock (_syncRoot)
            {
                return File.Exists(FilePath);
            }
        }

        public T Load()
        {
            lock (_syncRoot)
            {
                if (File.Exists(FilePath))
                    return JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath));
            }
            return default(T);
        }

        public void Save(T obj)
        {
            lock (_syncRoot)
            {
                File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj));
            }
        }
    }
}
