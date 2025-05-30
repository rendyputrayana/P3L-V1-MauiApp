using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class AlamatPlusPembeli
    {
        [JsonProperty("id_alamat")]
        public int id_alamat { get; set; }

        [JsonProperty("detail_alamat")]
        public string detail_alamat { get; set; }

        [JsonProperty("id_pembeli")]
        public int id_pembeli { get; set; }

        [JsonProperty("is_default")]
        public bool is_default { get; set; }

        [JsonProperty("pembeli")]
        public Pembeli pembeli { get; set; }
    }
}
