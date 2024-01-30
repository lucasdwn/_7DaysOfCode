using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _7DaysOfCode.Models
{
    public class Mascote
    {
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public List<HabilideInfo> habilidades { get; set; }
    }

    public class MascoteListResponse
    {
        public List<Mascote> Results { get; set; }

        [JsonProperty("Abilities")]
        public List<HabilideInfo> Habilidades { get; set; }
    }

    public class Habilidade : Mascote
    {
    }

    public class HabilideInfo
    {
        [JsonProperty("ability")]
        public Habilidade Habilidade { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public int Slot { get; set; }
    }
}