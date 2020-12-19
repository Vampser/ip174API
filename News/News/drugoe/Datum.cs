using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace News.drugoe
{
    public class Datum
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("fields")]
        public AllIsNews AllIsNews { get; set; }
        
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
