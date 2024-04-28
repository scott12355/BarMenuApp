namespace BarMenuApp;

public static class MauiProgram
{
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

		builder.Services.AddSingleton<MenuRepository>(s => ActivatorUtilities.CreateInstance<MenuRepository>(s, Constants.DatabasePath));

		builder.Services.AddTransient<MenuDetailViewModel>();
		builder.Services.AddTransient<MenuDetailPage>();

		builder.Services.AddSingleton<MenuViewModel>();

		builder.Services.AddSingleton<MenuPage>();

		builder.Services.AddSingleton<MyDrinksViewModel>();

		builder.Services.AddSingleton<MyDrinksPage>();

		return builder.Build();
	}
}
