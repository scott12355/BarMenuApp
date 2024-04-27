namespace BarMenuApp;

public static class MauiProgram
{
	public static DbAccess db;
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		db = new DbAccess(Constants.DatabasePath, true);
        //db.InitializeDatabase();
        builder.Services.AddTransient<SampleDataService>();
		builder.Services.AddTransient<MenuDetailViewModel>();
		builder.Services.AddTransient<MenuDetailPage>();

		builder.Services.AddSingleton<MenuViewModel>();

		builder.Services.AddSingleton<MenuPage>();

		builder.Services.AddSingleton<MyDrinksViewModel>();

		builder.Services.AddSingleton<MyDrinksPage>();

		return builder.Build();
	}
}
