using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Penitipan
    {
        [JsonProperty("nota_penitipan")]
        public int nota_penitipan { get; set; }

        [JsonProperty("tanggal_penitipan")]
        public string tanggal_penitipan { get; set; }

        [JsonProperty("id_penitip")]
        public int id_penitip { get; set; }

        [JsonProperty("id_pegawai")]
        public int? id_pegawai { get; set; }

        [JsonProperty("id_hunter")]
        public int? id_hunter { get; set; }

        [JsonProperty("penitip")]
        public Penitip penitip { get; set; }
    }
}
