using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class SubkategoriPage : ContentPage
{
	public SubkategoriPage()
	{
		InitializeComponent();
        this.BindingContext = new SubkategoriVM();
    }
}