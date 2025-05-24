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
    }
}
