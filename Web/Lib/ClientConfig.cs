using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Lib
{
    public class ClientConfig
    {
        [JsonProperty("ClientId")]
        public string ClientId { get; set; }
        [JsonProperty("Files")]
        public string[] Files { get; set; }
        [JsonProperty("Format")]
        public string Format { get; set; }
    }
}
