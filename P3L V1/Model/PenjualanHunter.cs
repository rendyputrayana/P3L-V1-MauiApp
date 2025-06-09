using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace P3L_V1.Model
{
    public class PenjualanHunter
    {
        [JsonProperty("nota_penjualan")]
        public int nota_penjualan { get; set; }

        [JsonProperty("tanggal_transaksi")]
        public string tanggal_transaksi { get; set; }

        [JsonProperty("tanggal_lunas")]
        public string tanggal_lunas { get; set; }

        [JsonProperty("total_harga")]
        public int total_harga { get; set; }

        [JsonProperty("status_penjualan")]
        public string status_penjualan { get; set; }

        [JsonProperty("ongkos_kirim")]
        public int ongkos_kirim { get; set; }

        [JsonProperty("poin")]
        public int poin { get; set; }

        [JsonProperty("tanggal_diterima")]
        public string tanggal_diterima { get; set; }

        [JsonProperty("status_pengiriman")]
        public string status_pengiriman { get; set; }

        [JsonProperty("metode_pengiriman")]
        public string metode_pengiriman { get; set; }

        [JsonProperty("jadwal_pengiriman")]
        public string jadwal_pengiriman { get; set; }

        [JsonProperty("bukti_pembayaran")]
        public string bukti_pembayaran { get; set; }

        [JsonProperty("id_pegawai")]
        public int id_pegawai { get; set; }

        [JsonProperty("id_alamat")]
        public int id_alamat { get; set; }

        [JsonProperty("created_at")]
        public DateTime created_at { get; set; }

        [JsonProperty("updated_at")]
        public DateTime updated_at { get; set; }

        [JsonProperty("rincian_penjualans")]
        public List<RincianPenjualan> rincian_penjualans { get; set; }
    }
}
