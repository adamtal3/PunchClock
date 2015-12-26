using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace PunchClock.Infra
{
    public class JsonFile<T>
    {
        private const string _basePath = "Data\\";

        public JsonFile(string filename)
        {
            var dir = Path.Combine(AssemblyDirectory, _basePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            FileName = filename;
            FilePath = Path.Combine(dir, filename + ".json");
        }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public bool Exists()
        {
            return File.Exists(FilePath);
        }

        public T Load()
        {
            if (File.Exists(FilePath))
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(FilePath));
            return default(T);
        }

        public void Save(T obj)
        {
            File.WriteAllText(FilePath, JsonConvert.SerializeObject(obj));
        }
    }
}
