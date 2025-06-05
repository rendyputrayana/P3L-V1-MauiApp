using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3L_V1.ViewModel
{
    public partial class MerchandiseVM : BaseVM
    {
        public ObservableCollection<MerchandisePlusFoto> ListMerchandise { get; set; } = new ObservableCollection<MerchandisePlusFoto>();

        private readonly ApiService apiService;

        public MerchandiseVM()
        {
            apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            var response = await apiService.getAllMerchandise();
            if (response != null)
            {
                ListMerchandise.Clear();
                foreach (var item in response)
                {
                    ListMerchandise.Add(item);
                }
            }
        }

        [RelayCommand]
        public async Task Penukaran(int id_merch)
        {
            try
            {
                IsBusy = true;
                var id = Preferences.Get("idRole", string.Empty);
                var selectedMerchandise = ListMerchandise.FirstOrDefault(m => m.id_merchandise == id_merch );
                if (selectedMerchandise != null)
                {
                    await apiService.PostPenukaranReward(int.Parse(id), selectedMerchandise.id_merchandise);
                    await App.Current.MainPage.DisplayAlert("Success", "Penukaran berhasil dilakukan.", "OK");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "Silakan pilih merchandise yang ingin ditukar.", "OK");
                }
                var response = await apiService.getAllMerchandise();
                if (response != null)
                {
                    ListMerchandise.Clear();
                    foreach (var item in response)
                    {
                        ListMerchandise.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await App.Current.MainPage.DisplayAlert("Error", "Terjadi kesalahan saat melakukan penukaran.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
