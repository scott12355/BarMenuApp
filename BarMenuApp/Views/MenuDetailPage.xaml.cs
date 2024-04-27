namespace BarMenuApp.Views;

public partial class MenuDetailPage : ContentPage
{
	public MenuDetailPage(MenuDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
