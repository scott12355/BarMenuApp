﻿namespace BarMenuApp;

public partial class App : Application
{
	public static MenuRepository MenuRepo { get; private set; }
	public App(MenuRepository repo)
	{
		InitializeComponent();

		MainPage = new AppShell();

		MenuRepo = repo;
	}
}
