
namespace BarMenuApp.Tests;

public class UnitTest1
{
	// TODO: Add some unit tests
	[Fact]
	public async Task Test1Async()
	{
		RestDrinkMenuService restService = new RestDrinkMenuService();
		var x = await restService.RefreshDataAsync();
		Assert.NotNull(x);
	}
}
