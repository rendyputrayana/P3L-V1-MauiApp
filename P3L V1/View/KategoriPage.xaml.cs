using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class KategoriPage : ContentPage
{
	public KategoriPage()
	{
		InitializeComponent();

        this.BindingContext = new KategoriVM();
    }
}