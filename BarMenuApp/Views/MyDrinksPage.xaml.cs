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
}
