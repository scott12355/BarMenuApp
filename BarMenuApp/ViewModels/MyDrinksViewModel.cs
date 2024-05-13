using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Maui.Controls;

namespace BarMenuApp.ViewModels;

public partial class MyDrinksViewModel : BaseViewModel, INotifyPropertyChanged
{
    #region Properties
    private ObservableCollection<Drink> userDrinks;
    public ObservableCollection<Drink> UserDrinks
    {
        get { return userDrinks; }
        set { userDrinks = value; OnPropertyChanged(); }
    }

    #endregion
    

    #region Constructor
    public MyDrinksViewModel()
    {

    }


    public async Task LoadDataAsync()
    {

        List<Drink> DrinksFromSqliteDB = await App.MenuRepo.GetAllDrinks();
        UserDrinks = DrinksFromSqliteDB.ToObservableCollection();
    }
    #endregion
    [RelayCommand]
    private async Task GoToDetails(Drink item)
    {
        await Shell.Current.GoToAsync(nameof(MenuDetailPage), true, new Dictionary<string, object>
        {
            { "Item", item }
        });
    }
}
