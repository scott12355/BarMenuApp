using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace BarMenuApp.ViewModels
{
    public partial class AddDrinkViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private string _drinkName;
        private string _drinkDescription;
        private string _newIngredient;
        private ObservableCollection<string> _ingredients;

        public string DrinkName
        {
            get => _drinkName;
            set
            {
                _drinkName = value;
                OnPropertyChanged(nameof(DrinkName));
            }
        }

        public string DrinkDescription
        {
            get => _drinkDescription;
            set
            {
                _drinkDescription = value;
                OnPropertyChanged(nameof(DrinkDescription));
            }
        }

        public string NewIngredient
        {
            get => _newIngredient;
            set
            {
                _newIngredient = value;
                OnPropertyChanged(nameof(NewIngredient));
            }
        }

        public ObservableCollection<string> Ingredients
        {
            get => _ingredients;
            private set
            {
                _ingredients = value;
                OnPropertyChanged(nameof(Ingredients));
            }
        }
        
        public ICommand AddIngredientCommand { get; private set; }
        public ICommand SaveCommand { get; set; }



        public AddDrinkViewModel()
        {
            Ingredients = new ObservableCollection<string>();
            AddIngredientCommand = new Command(() => AddIngredient(NewIngredient));
            SaveCommand = new Command(() => PostDrinkRequest()); 
            
        }

        private async void PostDrinkRequest()
        {
            RestDrinkMenuService api = new RestDrinkMenuService();
            StringBuilder ingredients = new StringBuilder();
            foreach (string ingredient in Ingredients)
            {
                ingredients.Append(ingredient);
                ingredients.Append(",");
            }
            ingredients.Remove(ingredients.Length - 1, 1);
            DrinkPostJson newDrink = new DrinkPostJson()
            {
                Description = this.DrinkDescription, Ingredients = ingredients.ToString(), Name = this.DrinkName
            };
            await api.PostDrinkAsync(newDrink);
            await Shell.Current.Navigation.PopAsync();
        }


        [RelayCommand]
        private async Task RemoveIngredient(string item)
        {
            await Task.Run(() => Ingredients.Remove(item));
        }


        private void AddIngredient(string ingredient)
        {
            if (String.IsNullOrEmpty(ingredient)) {return;}
            Ingredients.Add(ingredient);
            NewIngredient = String.Empty; 
        }


    }
}