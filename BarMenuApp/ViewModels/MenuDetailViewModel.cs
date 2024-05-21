using System.Windows.Input;

namespace BarMenuApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class MenuDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Drink? item;

	public bool RemoveEnabled = true;
    public ICommand AddDrink { get; private set; }
    public ICommand RemoveDrink { get; private set; }

	public MenuDetailViewModel() {
		AddDrink = new Command(async () => await App.MenuRepo.AddNewDrink(item));
		RemoveDrink = new Command(async () => await App.MenuRepo.RemoveDrink(item));

	}




}
