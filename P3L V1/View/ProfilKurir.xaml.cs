using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class ProfilKurir : ContentPage
{
	public ProfilKurir()
	{
		InitializeComponent();
        this.BindingContext = new ProfilKurirVM();
    }
}