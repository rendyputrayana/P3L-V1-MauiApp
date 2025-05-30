// HistoryPembelianVM.cs
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using P3L_V1.Model;
using P3L_V1.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace P3L_V1.ViewModel
{
    public partial class HistoryPembelianVM : BaseVM
    {
        private ApiService apiService;

        public HistoryPembelianVM()
        {
            apiService = new ApiService();
        }

        public ObservableCollection<Penjualan> Penjualan { get; set; } = new ObservableCollection<Penjualan>();

        [RelayCommand]
        public async Task Appearing()
        {
            try
            {
                IsBusy = true;
                var id = Preferences.Get("idRole", string.Empty);

                if (string.IsNullOrEmpty(id))
                {
                    Console.WriteLine("Error: Customer ID (idRole) not found in preferences.");
                    // Consider showing a user-friendly message
                    return;
                }

                var penjualans = await apiService.getPenjualanById(id);

                Penjualan.Clear();

                if (penjualans != null && penjualans.Any())
                {
                    // Sort by tanggal_transaksi from newest to oldest
                    // Assuming tanggal_transaksi is in a format that can be parsed directly (e.g., "yyyy-MM-dd" or "yyyy-MM-dd HH:mm:ss")
                    // If it's a different format, you might need DateTime.ParseExact
                    var sortedPenjualans = penjualans.OrderByDescending(p => DateTime.Parse(p.tanggal_transaksi)).ToList();

                    foreach (var penjualan in sortedPenjualans)
                    {
                        Penjualan.Add(penjualan);
                    }
                }
                else
                {
                    Console.WriteLine("API returned null or empty list of sales.");
                }
            }
            catch (FormatException fex)
            {
                Console.WriteLine($"Date parsing error: {fex.Message}. Check tanggal_transaksi format.");
                // Handle invalid date format specifically
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching sales history: {e.Message}");
                Console.WriteLine(e.ToString());
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}