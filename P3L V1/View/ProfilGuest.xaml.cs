using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class ProfilGuest : ContentPage
{
	public ProfilGuest()
	{
		InitializeComponent();
        this.BindingContext = new ProfilGuestVM();
    }
}