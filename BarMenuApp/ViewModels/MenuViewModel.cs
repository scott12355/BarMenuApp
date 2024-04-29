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

	public async Task LoadMenu() {
		using var stream = await FileSystem.OpenAppPackageFileAsync("Cocktails.csv");
            using var reader = new StreamReader(stream);
            {
                String line;
                Drink d;
                while((line = reader.ReadLine()) != null)
                {
					TextFieldParser parser = new TextFieldParser(new StringReader(line));

					// You can also read from a file
					// TextFieldParser parser = new TextFieldParser("mycsvfile.csv");

					parser.HasFieldsEnclosedInQuotes = true;
					parser.SetDelimiters(",");

					string[] fields;

					while (!parser.EndOfData)
					{
					    fields = parser.ReadFields();
						
						d = new Drink() {Name = fields[0], Description = fields[1], Ingredients=fields[2]};   
						MenuItems.Add(d);     
 
					} 
					parser.Close();
                    // string[] values = line.Split(",");
                    // d = new Drink();
                    // d.Name = values[0];
                    // d.Description = values[1];
                    // d.Ingredients = values[2];
                    
                }
            }
		
	}
}
