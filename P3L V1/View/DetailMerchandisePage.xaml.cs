using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class DetailMerchandisePage : ContentPage
{
	public DetailMerchandisePage()
	{
		InitializeComponent();
        this.BindingContext = new MerchandiseDetailVM();
    }
}