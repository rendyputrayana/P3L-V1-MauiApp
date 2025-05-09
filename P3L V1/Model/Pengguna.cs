using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Pengguna
    {
        [JsonProperty("id_pengguna")]
        public int id_pengguna { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("id_organisasi")]
        public int? id_organisasi { get; set; }

        [JsonProperty("id_hunter")]
        public int? id_hunter { get; set; }

        [JsonProperty("id_pembeli")]
        public int? id_pembeli { get; set; }

        [JsonProperty("id_pegawai")]
        public int? id_pegawai { get; set; }

        [JsonProperty("id_penitip")]
        public int? id_penitip { get; set; }
    }
}
