using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.VisualBasic.FileIO;
using FileSystem = Microsoft.Maui.Storage.FileSystem;


namespace BarMenuApp.ViewModels;

public partial class MenuViewModel : BaseViewModel
{

	[ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<Drink>? items;

	private ObservableCollection<Drink>? menuItems;
	public ObservableCollection<Drink>? MenuItems
	{
		get { return menuItems; }
		set { menuItems = value; }
	}

	public List<Drink>? MenuItemsList;
	

	public MenuViewModel()
	{

		this.MenuItems = new ObservableCollection<Drink>();
		Console.WriteLine(MenuItems);

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
		//List<Drink> x = await App.MenuRepo.GetAllDrinks();
		//Items = x.ToObservableCollection();
	}


	[RelayCommand]
	private async Task GoToDetails(Drink item)
	{
		await Shell.Current.GoToAsync(nameof(MenuDetailPage), true, new Dictionary<string, object>
		{
			{ "Item", item }
		});
	}

	public async Task LoadMenu(List<Drink> drinks) {
		foreach (Drink d in drinks) {
			MenuItems.Add(d);
		}
	}
		
}
