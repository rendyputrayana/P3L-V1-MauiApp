using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
        this.BindingContext = new HomePageVM();
    }
}