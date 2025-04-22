using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class SubKategori
    {
        [JsonProperty("id_subkategori")]
        public int IdSubkategori { get; set; }

        [JsonProperty("nama_subkategori")]
        public string NamaSubkategori { get; set; }

        [JsonProperty("id_kategori")]
        public int IdKategori { get; set; }
    }
}
