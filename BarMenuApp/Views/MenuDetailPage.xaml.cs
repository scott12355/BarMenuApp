namespace BarMenuApp.Views;

public partial class MenuDetailPage : ContentPage
{
	
	MenuDetailViewModel ViewModel;

	public MenuDetailPage(MenuDetailViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
	
	protected override async void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		ViewModel.SetButtons(await App.MenuRepo.IsDrinkFavorite(ViewModel.item));
	}
}
