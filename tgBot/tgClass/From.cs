using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace tgBot.tgClass
{
    class From
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
