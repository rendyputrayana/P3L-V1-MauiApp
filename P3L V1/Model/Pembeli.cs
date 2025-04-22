using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Pembeli
    {
        [JsonProperty("id_pembeli")]
        public int IdPembeli { get; set; }

        [JsonProperty("nama_pembeli")]
        public string NamaPembeli { get; set; }

        [JsonProperty("poin_reward")]
        public int PoinReward { get; set; }
    }
}
