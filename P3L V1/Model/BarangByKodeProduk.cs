using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.Model
{
    public class BarangByKodeProduk
    {
        [JsonProperty("kode_produk")]
        public int kode_produk { get; set; }

        [JsonProperty("id_subkategori")]
        public int id_subkategori { get; set; }

        [JsonProperty("id_donasi")]
        public int? id_donasi { get; set; }

        [JsonProperty("nota_penitipan")]
        public int nota_penitipan { get; set; }

        [JsonProperty("berat_barang")]
        public int berat_barang { get; set; }

        [JsonProperty("nama_barang")]
        public string nama_barang { get; set; }

        [JsonProperty("harga_barang")]
        public int harga_barang { get; set; }

        [JsonProperty("masa_penitipan")]
        public string masa_penitipan { get; set; }

        [JsonProperty("rating_barang")]
        public object? rating_barang { get; set; }

        [JsonProperty("status_barang")]
        public string status_barang { get; set; }

        [JsonProperty("komisi_penitip")]
        public int komisi_penitip { get; set; }

        [JsonProperty("komisi_reuseMart")]
        public int komisi_reuseMart { get; set; }

        [JsonProperty("komisi_hunter")]
        public int komisi_hunter { get; set; }

        [JsonProperty("perpanjang")]
        public bool perpanjang { get; set; }

        [JsonProperty("garansi")]
        public object? garansi { get; set; }

        [JsonProperty("penitipan")]
        public Penitipan penitipan { get; set; }

        [JsonProperty("foto_barangs")]
        public List<FotoBarang> foto_barangs { get; set; }

        [JsonProperty("subkategori")]
        public SubKategoriByKodeProduk subkategori { get; set; }
    }
}
