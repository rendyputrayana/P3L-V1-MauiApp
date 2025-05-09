using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Organisasi
    {
        [JsonProperty("id_organisasi")]
        public int id_organisasi { get; set; }

        [JsonProperty("nama_organisasi")]
        public string nama_organisasi { get; set; }

        [JsonProperty("alamat_organisasi")]
        public string alamat_organisasi { get; set; }
    }
}
