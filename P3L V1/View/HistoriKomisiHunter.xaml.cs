using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class HistoriKomisiHunter : ContentPage
{
	public HistoriKomisiHunter()
	{
		InitializeComponent();
		this.BindingContext = new HistoriKomisiHunterVM();
	}
}