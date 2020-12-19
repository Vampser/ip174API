using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace News.drugoe
{
    public class NewsInfo
    {
        [JsonProperty("time")]
        public int Time { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }
}
