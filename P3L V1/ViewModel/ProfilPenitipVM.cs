using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3L_V1.View;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;

namespace P3L_V1.ViewModel
{
    public partial class ProfilPenitipVM : BaseVM
    {
        private ApiService apiService;

        [ObservableProperty] 
        private Penitip myPenitip;

        public ProfilPenitipVM()
        {
            apiService = new ApiService();
        }

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
                MyPenitip = await apiService.getPenitipById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
