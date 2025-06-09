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
    public partial class ProfilPembeliVM : BaseVM
    {
        private ApiService apiService;
        public ProfilPembeliVM()
        {
            apiService = new ApiService();
        }

        [ObservableProperty]
        private Pembeli myPembeli;

        //public ObservableCollection<Alamat> Alamats { get; set; } = new ObservableCollection<Alamat>();

        [RelayCommand]
        public async Task Logout()
        {
            try
            {
                IsBusy = true;
                await apiService.Logout();
                Shell.Current.Items.Clear();
                var tabBar = new TabBar();

                tabBar.Items.Add(new ShellContent
                    { Title = "LoginPage", ContentTemplate = new DataTemplate(typeof(LoginPage)) });
                Shell.Current.Items.Add(tabBar);
                await Shell.Current.GoToAsync("LoginPage");
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
        public async Task Appearing()
        {
            try
            {
                var id = Preferences.Get("idRole", string.Empty);
                MyPembeli = await apiService.getPembeliById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [RelayCommand]
        public void GoToHistory()
        {
            try
            {
                Shell.Current.GoToAsync(nameof(HistoryPembelian));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
