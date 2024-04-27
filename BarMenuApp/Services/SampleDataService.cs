namespace BarMenuApp.Services;

public class SampleDataService
{
	public async Task<IEnumerable<Drink>> GetItems()
	{
		await Task.Delay(1000); // Artifical delay to give the impression of work

		var random = new Random().Next();

		var result = new List<Drink>();


		return result;
	}
}
