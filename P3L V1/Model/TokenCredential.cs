using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class TokenCredential
    {
        [JsonProperty("fcm_token")]
        public string fcm_token { get; set; }

        [JsonProperty("id_pengguna")]
        public string id_pengguna { get; set; }
    }
}
