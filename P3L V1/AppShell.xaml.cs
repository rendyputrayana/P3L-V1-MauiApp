using P3L_V1.View;

namespace P3L_V1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(ProfilPenitip), typeof(ProfilPenitip));
            Routing.RegisterRoute(nameof(KategoriPage), typeof(KategoriPage));
            Routing.RegisterRoute(nameof(SubkategoriPage), typeof(SubkategoriPage));
            Routing.RegisterRoute(nameof(DetailMerchandisePage), typeof(DetailMerchandisePage));
            Routing.RegisterRoute(nameof(DetailBarang), typeof(DetailBarang));
            Routing.RegisterRoute(nameof(HistoriKomisiHunter), typeof(HistoriKomisiHunter));
            Routing.RegisterRoute(nameof(ProfilGuest), typeof(ProfilGuest));
            Routing.RegisterRoute(nameof(HistoryPembelian), typeof(HistoryPembelian));
            Routing.RegisterRoute(nameof(HistoryPenitip), typeof(HistoryPenitip));
            Routing.RegisterRoute(nameof(HistoryPengiriman), typeof(HistoryPengiriman));

        }
    }
}
