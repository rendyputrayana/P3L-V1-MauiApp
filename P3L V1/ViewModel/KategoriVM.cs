using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using P3L_V1.View;

namespace P3L_V1.ViewModel
{
    public partial class KategoriVM : BaseVM
    {
        public ObservableCollection<Kategori> Kategori { get; set; } = new ObservableCollection<Kategori>();


        private readonly ApiService apiService;

        public KategoriVM()
        {
            apiService = new ApiService();
        }

        [RelayCommand]
        public async Task SelectingKategori(Kategori selectedKategori)
        {
            await Shell.Current.GoToAsync($"{nameof(SubkategoriPage)}?id={selectedKategori.id_kategori}");
        }

        [RelayCommand]
        public async Task Appearing()
        {
            var allKategori = await apiService.getAllKategori();

            foreach (var item in allKategori)
            {
                Kategori.Add(item);
            }
        }

        [RelayCommand]
        public void Disappearing()
        {
            Kategori.Clear();
        }
    }
}
