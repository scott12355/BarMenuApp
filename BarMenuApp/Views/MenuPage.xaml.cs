namespace BarMenuApp.Views;

public partial class MenuPage : ContentPage
{
	MenuViewModel ViewModel;
	RestService restService;


	public MenuPage(MenuViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = ViewModel = viewModel;
		restService = new RestService();
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		if (ViewModel.MenuItems.Count() == 0) {
				var x = await restService.RefreshDataAsync();
				await ViewModel.LoadMenu(x);
		}
	}
}
