using Newtonsoft.Json;
using System.IO;

namespace P5RFieldTexUtility
{
    public class Config
    {
        public string ExtractedOutputDir { get; set; } = "./Extracted"; // Destination for textures from .BIN
        public string LastInputExtractedBinDir { get; set; } = ""; // Last known directory of .BIN to extract
        public string RepackedBinDir { get; set; } = "./Repacked"; // Destination for repacked .BIN files
        public string LastTexToRepackDir { get; set; } = ""; // Last known directory of Tex to repack
        public string CustomTexDir { get; set; } = "./CustomTex"; // Directory of textures to replace with
        public string ReplaceTexDir { get; set; } = ""; // Last known directory of Tex to replace
        public bool MatchPartialNames { get; set; } = false; // Whether or not to match filenames fully or partially
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
