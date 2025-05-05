using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Services;
using P3L_V1.View;

namespace P3L_V1.ViewModel
{
    public partial class LoginPageViewModel : BaseVM
    {
        [ObservableProperty] 
        private string username;

        [ObservableProperty] 
        private string password;

        private readonly ApiService apiService;

        public LoginPageViewModel()
        {
            apiService = new ApiService();
        }

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                IsBusy = true;
                var result = await apiService.Login(Username, Password);
                if (result != "Login Gagal")
                {
                    MainThread.BeginInvokeOnMainThread(() => SetTabs(result));
                }
                else
                {
                    await Shell.Current.DisplayAlert("Error", "Login Gagal", "OK");
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

        private void SetTabs(string role)
        {
            Preferences.Set("username", Username);
            Shell.Current.Items.Clear();

            var tabBar = new TabBar();

            tabBar.Items.Add(new ShellContent{Title = "Home", ContentTemplate = new DataTemplate(typeof(HomePage)), Icon = "home.png"});

            switch (role)
            {
                case "Pembeli":
                    tabBar.Items.Add(new ShellContent { Title = "Merchandise", ContentTemplate = new DataTemplate(typeof(MerchandisePage)), Icon = "gift.png" });
                    tabBar.Items.Add(new ShellContent { Title = "Profil", ContentTemplate = new DataTemplate(typeof(ProfilPembeli)), Icon = "circle_user.svg"});
                    break;
                case "Penitip":
                    tabBar.Items.Add(new ShellContent {Title = "Kategori", ContentTemplate = new DataTemplate(typeof(KategoriPage)), Icon = "list.svg"});
                    tabBar.Items.Add(new ShellContent { Title = "Profil", ContentTemplate = new DataTemplate(typeof(ProfilPenitip)), Icon = "circle_user.svg" });
                    break;
                case "Pegawai":
                    tabBar.Items.Add(new ShellContent { Title = "Profil", ContentTemplate = new DataTemplate(typeof(ProfilKurir)), Icon = "circle_user.svg" });
                    break;
                case "Hunter":
                    tabBar.Items.Add(new ShellContent { Title = "Profil", ContentTemplate = new DataTemplate(typeof(ProfilHunter)), Icon = "circle_user.svg" });
                    break;
                default:
                    tabBar.Items.Add(new ShellContent { Title = "Profil", ContentTemplate = new DataTemplate(typeof(ProfilPembeli)), Icon = "circle_user.svg" });
                    break;
            }
            Shell.Current.Items.Add(tabBar);
        }
    }
}
