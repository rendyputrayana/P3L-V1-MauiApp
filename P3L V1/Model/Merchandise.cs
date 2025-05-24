using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class Merchandise
    {
        [JsonProperty("id_merchandise")]
        public int id_merchandise { get; set; }

        [JsonProperty("nama_merchandise")]
        public string nama_merchandise { get; set; }

        [JsonProperty("poin")]
        public int poin { get; set; }

        [JsonProperty("stok")]
        public int stok { get; set; }
    }
}
