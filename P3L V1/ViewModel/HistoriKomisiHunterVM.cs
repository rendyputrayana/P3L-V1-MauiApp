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
    public partial class HistoriKomisiHunterVM:BaseVM
    {
        public ObservableCollection<PenjualanHunter> dataHistory { get; set; } = new ObservableCollection<PenjualanHunter>();


        private ApiService apiService;

        public HistoriKomisiHunterVM()
        {
            apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;
                var id = Preferences.Get("idRole", string.Empty);
                var data = await apiService.getHistoryHunterByIdHunter(id);
                dataHistory.Clear();
                foreach (var item in data)
                {
                    dataHistory.Add(item);
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
