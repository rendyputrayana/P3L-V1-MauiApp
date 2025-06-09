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
    public partial class HistoryPengirimanVM : BaseVM
    {
        private ApiService apiService;

        public ObservableCollection<PenjualanPlusAlamat> HistoryPengiriman { get; set; } = new ObservableCollection<PenjualanPlusAlamat>();

        public HistoryPengirimanVM()
        {
            this.apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;
                var id = Preferences.Get("idRole", string.Empty);
                var response = await apiService.GetHistoryPengirimanByIdKurir(id);

                HistoryPengiriman.Clear();

                foreach (var pengiriman in response)
                {
                    HistoryPengiriman.Add(pengiriman);
                }
            }
            catch(Exception e)
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
