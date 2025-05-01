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
        public int IdPegawai { get; set; }

        [JsonProperty("nama_pegawai")]
        public string NamaPegawai { get; set; }

        [JsonProperty("tanggal_lahir")]
        public string TanggalLahir { get; set; }

        [JsonProperty("id_jabatan")]
        public int IdJabatan { get; set; }
    }
}
