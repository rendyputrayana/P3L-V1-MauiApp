using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Kategori
    {
        [JsonProperty("id_kategori")]
        public int IdKategori { get; set; }

        [JsonProperty("nama_kategori")]
        public string NamaKategori { get; set; }
    }
}
