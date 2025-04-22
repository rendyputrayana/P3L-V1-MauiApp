using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
        this.BindingContext = new LoginPageViewModel();
    }
}