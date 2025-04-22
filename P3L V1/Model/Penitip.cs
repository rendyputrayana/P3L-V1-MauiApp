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
        public int IdPenitip { get; set; }

        [JsonProperty("nama_penitip")]
        public string NamaPenitip { get; set; }

        [JsonProperty("no_ktp")]
        public string NoKtp { get; set; }

        [JsonProperty("no_telepon")]
        public string NoTelepon { get; set; }

        [JsonProperty("alamat_penitip")]
        public string AlamatPenitip { get; set; }

        [JsonProperty("foto_ktp")]
        public string FotoKtp { get; set; }

        [JsonProperty("saldo")]
        public int Saldo { get; set; }
    }
}
