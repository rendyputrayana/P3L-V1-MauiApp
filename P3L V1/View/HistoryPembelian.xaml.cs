using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class HistoryPembelian : ContentPage
{
	public HistoryPembelian()
	{
		InitializeComponent();
        this.BindingContext = new HistoryPembelianVM();
    }
}