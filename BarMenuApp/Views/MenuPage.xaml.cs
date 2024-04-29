namespace BarMenuApp.Views;

public partial class MenuPage : ContentPage
{
	MenuViewModel ViewModel;

	public MenuPage(MenuViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		await ViewModel.LoadMenu();
	}
}
