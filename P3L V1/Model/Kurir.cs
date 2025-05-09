using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Kurir
    {
        [JsonProperty("id_pegawai")]
        public int id_pegawai { get; set; }

        [JsonProperty("nama_pegawai")]
        public string nama_pegawai { get; set; }

        [JsonProperty("tanggal_lahir")]
        public string tanggal_lahir { get; set; }

        [JsonProperty("id_jabatan")]
        public int id_jabatan { get; set; }
    }
}
