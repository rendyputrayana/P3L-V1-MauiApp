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
    public partial class HistoryPenitipWM : BaseVM
    {
        private ApiService apiService;

        public HistoryPenitipWM()
        {
            this.apiService = new ApiService();
        }

        public ObservableCollection<BarangPlusRincianPenjualan> Penitipans { get; set; } = new ObservableCollection<BarangPlusRincianPenjualan>();

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;
                var id = Preferences.Get("idRole", string.Empty);
                var penitipans = await apiService.GetPenitipanById(id);
                Penitipans.Clear();
                foreach (var penitipan in penitipans)
                {
                    Penitipans.Add(penitipan);
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
