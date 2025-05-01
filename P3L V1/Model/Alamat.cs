using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Alamat
    {
        [JsonProperty("id_alamat")]
        public int IdAlamat { get; set; }

        [JsonProperty("detail_alamat")]
        public string DetailAlamat { get; set; }

        [JsonProperty("id_pembeli")]
        public int IdPembeli { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
    }
}
