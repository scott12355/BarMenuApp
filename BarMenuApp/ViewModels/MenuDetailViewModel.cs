using System.Windows.Input;

namespace BarMenuApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class MenuDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Drink? item;

    public ICommand AddDrink { get; private set; }

	public MenuDetailViewModel() {
		AddDrink = new Command(async () => await App.MenuRepo.AddNewDrink(item));
	}

	private async Task AddDrinkToUserDrinks()
	{
		await App.MenuRepo.AddNewDrink(item);
	}


}
