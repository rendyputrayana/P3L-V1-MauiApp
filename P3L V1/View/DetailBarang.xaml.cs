using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class DetailBarang : ContentPage
{
	public DetailBarang()
	{
		InitializeComponent();
        this.BindingContext = new DetailBarangVM();
    }
}