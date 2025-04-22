using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class MerchandisePage : ContentPage
{
	public MerchandisePage()
	{
		InitializeComponent();
        this.BindingContext = new MerchandiseVM();
    }
}