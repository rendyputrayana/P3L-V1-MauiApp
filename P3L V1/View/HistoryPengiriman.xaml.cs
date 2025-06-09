using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class HistoryPengiriman : ContentPage
{
	public HistoryPengiriman()
	{
		InitializeComponent();
        this.BindingContext = new HistoryPengirimanVM();
    }
}