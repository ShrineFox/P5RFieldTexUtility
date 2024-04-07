using Newtonsoft.Json;
using System.IO;

namespace P5RFieldTexUtility
{
    public class Config
    {
        public string DuplicateExportPath { get; set; } = "./Duplicates";
        public string BinExportPath { get; set; } = "./Export";
        public bool IgnoreBinaryDiff { get; set; } = true;
        public bool OverwriteSameName { get; set; } = true;
        public bool IgnoreNameDiff { get; set; } = false;
        public bool EnableOutputLog { get; set; } = true;


        public void SaveJson(Config settings)
        {
            File.WriteAllText("Config.json", JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented));
        }

        public Config LoadJson()
        {
            if (!File.Exists("Config.json"))
                return new Config();

            string jsonText = File.ReadAllText(Path.GetFullPath("./Config.json"));
            Config config = JsonConvert.DeserializeObject<Config>(jsonText);
            return config;
        }
    }
}
