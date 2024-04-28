﻿namespace BarMenuApp.ViewModels;

[QueryProperty(nameof(Item), "Item")]
public partial class MenuDetailViewModel : BaseViewModel
{
	[ObservableProperty]
	Drink? item;
}