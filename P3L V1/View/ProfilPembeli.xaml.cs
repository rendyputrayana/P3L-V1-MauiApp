using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class ProfilPembeli : ContentPage
{
	public ProfilPembeli()
	{
		InitializeComponent();
        this.BindingContext = new ProfilPembeliVM();
    }
}