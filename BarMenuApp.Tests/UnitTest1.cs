
using System.Collections.ObjectModel;
using BarMenuApp.Models;

namespace BarMenuApp.Tests;

public class UnitTest1
{
	// TODO: Add some unit tests
	[Fact]
	public async Task Test1Async()
	{
		RestDrinkMenuService restService = new RestDrinkMenuService();
		List<Drink> x = await restService.RefreshDataAsync();
		Assert.True(x.Count > 10);
	}
}
