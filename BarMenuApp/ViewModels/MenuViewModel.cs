using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Input;
using System.Xml.Linq;
using FileSystem = Microsoft.Maui.Storage.FileSystem;


namespace BarMenuApp.ViewModels;

public partial class MenuViewModel : BaseViewModel, INotifyPropertyChanged
{

	[ObservableProperty]
	bool isRefreshing;

	[ObservableProperty]
	ObservableCollection<Drink>? items;

	private ObservableCollection<Drink>? menuItems;
	public ObservableCollection<Drink>? MenuItems
	{
		get { return menuItems; }
		set { menuItems = value; OnPropertyChanged(); }
	}
    private ObservableCollection<Drink> searchResult;
    public ObservableCollection<Drink> SearchResult { get { return searchResult; } set { searchResult = value; OnPropertyChanged(); } }

    public List<Drink>? MenuItemsList;
	

	public MenuViewModel()
	{
		this.MenuItems = new ObservableCollection<Drink>();
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
	    RestDrinkMenuService restService = new RestDrinkMenuService();
	    var drinksFromAPI = await restService.RefreshDataAsync();
	    LoadMenu(drinksFromAPI);
    }

    [RelayCommand]
	private async Task GoToDetails(Drink item)
	{
		await Shell.Current.GoToAsync(nameof(MenuDetailPage), true, new Dictionary<string, object>
		{
			{ "Item", item }
		});
	}



    public ICommand PerformSearch => new Command<string>((string query) =>
    {
        query = query.ToUpper();
        var buff = MenuItems.Where(x => x.Name.ToUpper().Contains(query));

        if (buff.Any())
        {
            SearchResult = buff.ToObservableCollection<Drink>();
        }else
        {
            SearchResult = MenuItems;
        }
    });

    public void Search(string query)
    {
	    query = query.ToUpper();
	    var buff = MenuItems.Where(x => x.Name.ToUpper().Contains(query));

	    if (buff.Any())
	    {
		    SearchResult = buff.ToObservableCollection<Drink>();
	    }else
	    {
		    SearchResult = MenuItems;
	    }
    }


    public void LoadMenu(List<Drink> drinks) {
		MenuItems = drinks.ToObservableCollection<Drink>();
        SearchResult = MenuItems;
	}

	
		
}
