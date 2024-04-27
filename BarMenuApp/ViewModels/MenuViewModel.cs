using CommunityToolkit.Maui.Core.Extensions;

namespace BarMenuApp.ViewModels;

public partial class MenuViewModel : BaseViewModel
{
	readonly SampleDataService dataService;

	[ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<Drink>? items;

	public MenuViewModel(SampleDataService service)
	{
		dataService = service;
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

	[RelayCommand]
	public async Task LoadMore()
	{
		if (Items is null)
		{
			return;
		}

		var moreItems = await dataService.GetItems();

		foreach (var item in moreItems)
		{
			Items.Add(item);
		}
	}

	public async Task LoadDataAsync()
	{

		Items = MauiProgram.db.GetDrinks().ToObservableCollection();
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
