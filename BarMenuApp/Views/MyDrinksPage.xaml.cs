namespace BarMenuApp.Views;

public partial class MyDrinksPage : ContentPage
{
	public MyDrinksPage(MyDrinksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
