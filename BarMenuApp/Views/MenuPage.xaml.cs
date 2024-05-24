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
#pragma warning disable CS8604 // Possible null reference argument.
		ViewModel.LoadDataAsync();
#pragma warning restore CS8604 // Possible null reference argument.
	}

	private void SearchBar_OnTextChanged(object? sender, TextChangedEventArgs e)
	{
		SearchBar searchBar = (SearchBar)sender;
		ViewModel.Search(SearchBar.Text);
	}
}
