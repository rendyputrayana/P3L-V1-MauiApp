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
        public int IdOrganisasi { get; set; }

        [JsonProperty("nama_organisasi")]
        public string NamaOrganisasi { get; set; }

        [JsonProperty("alamat_organisasi")]
        public string AlamatOrganisasi { get; set; }
    }
}
