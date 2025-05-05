using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;

namespace P3L_V1.ViewModel
{
    public partial class HomePageVM : BaseVM
    {
        [ObservableProperty]
        private string username;

        public ObservableCollection<Kategori> Kategori { get; set; } = new ObservableCollection<Kategori>();

        public ObservableCollection<Barang> Barang { get; set; } = new ObservableCollection<Barang>();

        public ObservableCollection<string> CarouselImage { get; set; }

        private ApiService _apiService;

        public HomePageVM()
        {
            _apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {

            try
            {
                this.IsBusy = true;
                CarouselImage = new ObservableCollection<string>()
                {
                    "cr1.png",
                    "cr2.png",
                    "cr3.png",
                    "cr4.png",
                };

                var response = await this._apiService.getAllKategori();
                if (Kategori.Count != 0)
                {
                    Kategori.Clear();
                    foreach (var item in response)
                    {
                        Kategori.Add(item);
                    }
                }
                else
                {
                    foreach (var item in response)
                    {
                        Kategori.Add(item);
                    }
                }

                var responseBarang = await this._apiService.getAllBarang();
                if (Barang.Count != 0)
                {
                    Barang.Clear();
                    foreach (var item in responseBarang)
                    {
                        Barang.Add(item);
                    }
                }
                else
                {
                    foreach (var item in responseBarang)
                    {
                        Barang.Add(item);
                    }
                }

                Username = Preferences.Get("username", string.Empty);
            }
            finally
            {
                this.IsBusy = false;
            }
            
        }
    }
}
