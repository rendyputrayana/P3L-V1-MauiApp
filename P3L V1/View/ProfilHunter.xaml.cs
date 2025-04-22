using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class ProfilHunter : ContentPage
{
	public ProfilHunter()
	{
		InitializeComponent();
        this.BindingContext = new ProfilHunterVM();
    }
}