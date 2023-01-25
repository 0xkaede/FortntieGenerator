using FortniteGenerator.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteGenerator.Models
{
    public class Items
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("options")]
        public List<Options> Options { get; set; }
    }

    public class Options
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("assets")]
        public List<Assets> Assets { get; set; }
    }

    public class Assets
    {
        [JsonProperty("parentAsset")]
        public string ParentAsset { get; set; }

        [JsonProperty("swaps")]
        public List<Swaps> Swaps { get; set; }
    }

    public class Swaps
    {
        [JsonProperty("search")]
        public string Search { get; set; }

        [JsonProperty("replace")]
        public string Replace { get; set; }

        [JsonProperty("swapType")]
        public SwapTypes SwapType { get; set; }
    }
}
