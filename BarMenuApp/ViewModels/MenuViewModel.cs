using CommunityToolkit.Maui.Core.Extensions;


namespace BarMenuApp.ViewModels;

public partial class MenuViewModel : BaseViewModel
{

	[ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<Drink>? items;

	public MenuViewModel()
	{

	}

	[RelayCommand]
	private async Task OnRefreshing()
	{
		IsRefreshing = true;

		try
		{
			await LoadDataAsync();
		}
		finally
		{
			IsRefreshing = false;
		}
	}

	public async Task LoadDataAsync()
	{

		List<Drink> x = await App.MenuRepo.GetAllDrinks();
		Items = x.ToObservableCollection();
	}


	[RelayCommand]
	private async Task GoToDetails(SampleItem item)
	{
		await Shell.Current.GoToAsync(nameof(MenuDetailPage), true, new Dictionary<string, object>
		{
			{ "Item", item }
		});
	}
}
