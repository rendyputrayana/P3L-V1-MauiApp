using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class ProfilKurirVM : BaseVM
    {
        private ApiService apiService;

        public ProfilKurirVM()
        {
            apiService = new ApiService();
        }

        [ObservableProperty]
        private Kurir myKurir;


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
                IsBusy = true;
                var id = Preferences.Get("idRole", string.Empty);
                MyKurir = await apiService.getKurirByIdPegawai(id);

                MyKurir.TanggalLahir = DateTime.Parse(MyKurir.TanggalLahir)
                    .ToString("dddd, dd MMMM yyyy", new CultureInfo("id-ID"));

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
