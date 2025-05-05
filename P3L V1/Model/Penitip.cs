using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Penitip
    {
        [JsonProperty("id_penitip")]
        public int id_penitip { get; set; }

        [JsonProperty("nama_penitip")]
        public string nama_penitip { get; set; }

        [JsonProperty("no_ktp")]
        public string no_ktp { get; set; }

        [JsonProperty("no_telepon")]
        public string no_telepon { get; set; }

        [JsonProperty("alamat_penitip")]
        public string alamat_penitip { get; set; }

        [JsonProperty("foto_ktp")]
        public string foto_ktp { get; set; }

        [JsonProperty("saldo")]
        public int saldo { get; set; }
    }
}
