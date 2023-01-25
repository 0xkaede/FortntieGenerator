using Newtonsoft.Json;

namespace FortniteGenerator.Models
{
    public class EpicInstalled
    {
        [JsonProperty("InstallationList")]
        public List<EpicInstallation> InstallationList { get; set; }
    }

    public class EpicInstallation
    {
        [JsonProperty("InstallLocation")]
        public string InstallLocation { get; set; }

        [JsonProperty("AppVersion")]
        public string AppVersion { get; set; }

        [JsonProperty("AppName")]
        public string AppName { get; set; }
    }

}
