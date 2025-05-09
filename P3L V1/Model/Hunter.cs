using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Hunter
    {
        [JsonProperty("id_hunter")]
        public int id_hunter { get; set; }

        [JsonProperty("nama_hunter")]
        public string nama_hunter { get; set; }

        [JsonProperty("saldo")]
        public int saldo { get; set; }

        [JsonProperty("no_telepon")]
        public string no_telepon { get; set; }
    }
}
