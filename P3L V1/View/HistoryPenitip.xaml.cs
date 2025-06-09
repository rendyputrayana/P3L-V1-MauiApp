using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class HistoryPenitip : ContentPage
{
	public HistoryPenitip()
	{
		InitializeComponent();
        this.BindingContext = new HistoryPenitipWM();
    }
}