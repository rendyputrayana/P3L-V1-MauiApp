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
using P3L_V1.View;

namespace P3L_V1.ViewModel
{
    public partial class HomePageVM : BaseVM
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty] 
        private bool isRefreshing;

        public ObservableCollection<Kategori> Kategori { get; set; } = new ObservableCollection<Kategori>();

        public ObservableCollection<Barang> Barang { get; set; } = new ObservableCollection<Barang>();

        public ObservableCollection<CarouselItemHomePage> CarouselItems { get; set; } = new ObservableCollection<CarouselItemHomePage>();

		private ApiService _apiService;

        public HomePageVM()
        {
            _apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Refresh()
        {
            try
            {
                this.IsRefreshing = true;
                this.IsBusy = true;

                if (Barang.Count != 0)
                {
                    Barang.Clear();

                    var responseBarang = await this._apiService.getAllBarang();
                    foreach (var item in responseBarang)
                    {
                        Barang.Add(item);
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
                this.IsBusy = false;
                this.IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task SelectingBarang(Barang SelectedBarang)
        {
            Barang.Clear();
            await Shell.Current.GoToAsync($"{nameof(DetailBarang)}?id={SelectedBarang.kode_produk}");
        }

        [RelayCommand]
        public async Task RefreshByKategori(Kategori SelectedKategori)
        {
            try
            {
                IsRefreshing = true;

                var responseBarangByIdKategori = await _apiService.getBarangByIdKategori(SelectedKategori.id_kategori);
                Barang.Clear();
                foreach (var item in responseBarangByIdKategori)
                {
                    Barang.Add(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task Appearing()
        {

            try
            {
                this.IsBusy = true;
                CarouselItems.Clear();
                CarouselItems.Add(new CarouselItemHomePage
                {
                    title ="cr1.png",
                    image = "cr1.png"
				});
				CarouselItems.Add(new CarouselItemHomePage
				{
					title = "cr2.png",
					image = "cr2.png"
				});
				CarouselItems.Add(new CarouselItemHomePage
				{
					title = "cr3.png",
					image = "cr3.png"
				});
				CarouselItems.Add(new CarouselItemHomePage
				{
					title = "cr4.png",
					image = "cr4.png"
				});

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
