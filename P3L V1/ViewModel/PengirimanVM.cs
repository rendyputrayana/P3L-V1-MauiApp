using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;

namespace P3L_V1.ViewModel
{
    public partial class PengirimanVM : BaseVM
    {
        private ApiService _apiService;

        public ObservableCollection<PenjualanPlusAlamat> Pengiriman { get; set; } = new ObservableCollection<PenjualanPlusAlamat>();

        public PengirimanVM()
        {
            this._apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;
                var id_kurir = Preferences.Get("idRole", String.Empty);
                var responsePengiriman = await _apiService.getPenjualanByIdKurir(id_kurir);

                if (responsePengiriman.Count != 0)
                {
                    Pengiriman.Clear();
                    foreach (var penjualan in responsePengiriman)
                    {
                        Pengiriman.Add(penjualan);
                    }
                }

                Console.WriteLine("Done Add");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task Refresh()
        {
            try
            {
                IsBusy = true;
                var id_kurir = Preferences.Get("idRole", String.Empty);
                var responsePengiriman = await _apiService.getPenjualanByIdKurir(id_kurir);

                if (responsePengiriman.Count != 0)
                {
                    Pengiriman.Clear();
                    foreach (var penjualan in responsePengiriman)
                    {
                        Pengiriman.Add(penjualan);
                    }
                }

                Console.WriteLine("Done Add");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        public async Task SelesaikanPengiriman(int nota_penjualan)
        {
            try
            {
                IsBusy = true;
                string nota = nota_penjualan.ToString();
                await _apiService.VerifikasiPengiriman(nota);

                var id_kurir = Preferences.Get("idRole", String.Empty);
                var responsePengiriman = await _apiService.getPenjualanByIdKurir(id_kurir);

                if (responsePengiriman.Count != 0)
                {
                    Pengiriman.Clear();
                    foreach (var penjualan in responsePengiriman)
                    {
                        Pengiriman.Add(penjualan);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
