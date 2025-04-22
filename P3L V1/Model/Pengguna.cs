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
        public int IdPengguna { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("id_organisasi")]
        public int? IdOrganisasi { get; set; }

        [JsonProperty("id_hunter")]
        public int? IdHunter { get; set; }

        [JsonProperty("id_pembeli")]
        public int? IdPembeli { get; set; }

        [JsonProperty("id_pegawai")]
        public int? IdPegawai { get; set; }

        [JsonProperty("id_penitip")]
        public int? IdPenitip { get; set; }
    }
}
