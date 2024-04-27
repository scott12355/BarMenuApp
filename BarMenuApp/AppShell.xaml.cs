namespace BarMenuApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(MenuDetailPage), typeof(MenuDetailPage));
	}
}
