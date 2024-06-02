using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarMenuApp.Views;

public partial class AddDrinkPage : ContentPage
{
    AddDrinkViewModel ViewModel;
    public AddDrinkPage(AddDrinkViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = ViewModel = viewModel;
        
    }
    
}