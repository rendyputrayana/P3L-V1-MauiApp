using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;

namespace P3L_V1.ViewModel
{
    [QueryProperty(nameof(SelectedKodeProduk), "id")]

    public partial class DetailBarangVM : BaseVM
    {
        [ObservableProperty]
        private int selectedKodeProduk;

        [ObservableProperty] 
        private BarangByKodeProduk selectedBarang;
        
        private readonly ApiService _apiService;

        [ObservableProperty]
        private bool isGaransi;

        public DetailBarangVM()
        {
            this._apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;

                var response = await _apiService.getBarangByKodeProduk(SelectedKodeProduk);
                if (response != null)
                {
                    foreach (var item in response.foto_barangs)
                    {
                        item.foto_barang = "http://10.0.2.2:8000/" + item.foto_barang;
                    }
                    SelectedBarang = response;
                }

                var kategoriSelectedBarang = selectedBarang.id_subkategori;
                if(kategoriSelectedBarang > 7)
                {
                    IsGaransi = false;
                }
                else
                {
                    IsGaransi = true;
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
