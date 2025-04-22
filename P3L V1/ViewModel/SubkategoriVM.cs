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
    [QueryProperty(nameof(SelectedId), "id")]
    public partial class SubkategoriVM : BaseVM
    {
        public ObservableCollection<SubKategori> SubkategoriList { get; set; } =
            new ObservableCollection<SubKategori>();

        private readonly ApiService _apiService;

        [ObservableProperty] 
        private int selectedId;

        public SubkategoriVM()
        {
            this._apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;
                if (SubkategoriList.Count != 0)
                    SubkategoriList.Clear();

                var response = await _apiService.getAllSubKategoriByIdKategori(SelectedId.ToString());

                foreach (var item in response)
                {
                    SubkategoriList.Add(item);
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

        [RelayCommand]
        public async Task Disappearing()
        {
            if (SubkategoriList.Count == 0)
                return;

            SubkategoriList.Clear();
        }
    }
}
