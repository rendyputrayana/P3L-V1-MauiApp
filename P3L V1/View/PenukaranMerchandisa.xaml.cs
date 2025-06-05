using P3L_V1.ViewModel;

namespace P3L_V1.View;

public partial class PenukaranMerchandisa : ContentPage
{
	public PenukaranMerchandisa()
	{
		InitializeComponent();
		this.BindingContext = new PenukaranMerchandiseVM();
    }
}