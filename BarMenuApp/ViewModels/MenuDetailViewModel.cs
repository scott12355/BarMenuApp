using System.Windows.Input;

namespace BarMenuApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class MenuDetailViewModel : BaseViewModel, INotifyPropertyChanged
{
	[ObservableProperty] public Drink? item;


    private bool removeDrinkEnabled;
    public bool RemoveDrinkEnabled
    {
        get { return removeDrinkEnabled; }
        set
        {
            removeDrinkEnabled = value;
            OnPropertyChanged();
        }
    }
    
    private bool favoriteDrinkEnabled;
    public bool FavoriteDrinkEnabled {
        get { return favoriteDrinkEnabled; }
        set
        {
            favoriteDrinkEnabled = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddDrink { get; private set; }
    public ICommand RemoveDrink { get; private set; }

	public MenuDetailViewModel() {
		AddDrink = new Command(async () =>
        {
            await App.MenuRepo.AddNewDrink(item);
            FavoriteDrinkEnabled = false;
            RemoveDrinkEnabled = true;
        });
        RemoveDrink = new Command(async () =>
        {
            await App.MenuRepo.RemoveDrink(item);
            RemoveDrinkEnabled = false;
            FavoriteDrinkEnabled = true;
        });
    }

    public void SetButtons(bool isDrinkFavorite)
    {
        if (isDrinkFavorite)
        {
        	FavoriteDrinkEnabled = false;
        	RemoveDrinkEnabled = true;
        }
        else
        {
        	FavoriteDrinkEnabled = true;
            RemoveDrinkEnabled = false;
        }
    }
}

