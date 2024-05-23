namespace BarMenuApp.Views;

public partial class MyDrinksPage : ContentPage
{
    MyDrinksViewModel ViewModel;

    public MyDrinksPage(MyDrinksViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = ViewModel = viewModel;

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await ViewModel.LoadDataAsync();
    }

    private async void OnDeleteSwipeItemInvoked(object? sender, EventArgs e)
    {
        SwipeItem item = (SwipeItem)sender;
        Drink d = (Drink)item.BindingContext;
        await App.MenuRepo.RemoveDrink(d);
        ViewModel.UserDrinks.Remove(d);
        //item.Close();
    }
}
