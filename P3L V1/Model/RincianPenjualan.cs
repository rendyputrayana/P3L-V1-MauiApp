using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class RincianPenjualan
    {
        [JsonProperty("id_rincian_penjualan")]
        public int id_rincian_penjualan { get; set; }

        [JsonProperty("nota_penjualan")]
        public int nota_penjualan { get; set; }

        [JsonProperty("kode_produk")]
        public int kode_produk { get; set; }

        [JsonProperty("barang")]
        public Barang barang { get; set; }
    }
}