using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class ProfilPenitip : ContentPage
{
	public ProfilPenitip()
	{
		InitializeComponent();
        this.BindingContext = new ProfilPenitipVM();
    }
}