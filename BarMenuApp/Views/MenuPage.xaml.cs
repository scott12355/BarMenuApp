namespace BarMenuApp.Views;

public partial class MenuPage : ContentPage
{
	MenuViewModel ViewModel;
	RestDrinkMenuService restService;


	public MenuPage(MenuViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}

	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);
		restService = new RestDrinkMenuService();
        var drinksFromAPI = await restService.RefreshDataAsync();
#pragma warning disable CS8604 // Possible null reference argument.
        if (ViewModel.MenuItems.Count() != drinksFromAPI.Count) {
				ViewModel.LoadMenu(drinksFromAPI);
		}
#pragma warning restore CS8604 // Possible null reference argument.
	}

	private void SearchBar_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		SearchBar searchBar = (SearchBar)sender;
		ViewModel.Search(SearchBar.Text);
	}
}
