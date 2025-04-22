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
        public int IdHunter { get; set; }

        [JsonProperty("nama_hunter")]
        public string NamaHunter { get; set; }

        [JsonProperty("saldo")]
        public int Saldo { get; set; }

        [JsonProperty("no_telepon")]
        public string NoTelepon { get; set; }
    }
}
