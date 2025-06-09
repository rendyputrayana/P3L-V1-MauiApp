using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class Pengiriman : ContentPage
{
	public Pengiriman()
	{
		InitializeComponent();
        this.BindingContext = new PengirimanVM();
    }
}