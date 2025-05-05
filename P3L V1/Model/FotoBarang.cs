using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class FotoBarang
    {
        [JsonProperty("id_foto")]
        public int id_foto { get; set; }

        [JsonProperty("kode_produk")]
        public int kode_produk { get; set; }

        [JsonProperty("foto_barang")]
        public string foto_barang { get; set; }
    }
}
