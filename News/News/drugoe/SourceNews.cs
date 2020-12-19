using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace News.drugoe
{
    public class Source
    {   //название статьи
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
