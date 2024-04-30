using System.Text.Json;
using BarMenuApp;
using System.Web;
using Newtonsoft.Json;
public class RestDrinkMenuService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    
    
    public List<Drink> Items { get; private set; }
    private string content;
    public RestDrinkMenuService()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        content = String.Empty;
    }

    public async Task<List<Drink>> RefreshDataAsync()
    {
        Items = new List<Drink>();
        Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
        try
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                _serializerOptions.AllowTrailingCommas = false;
                content = await response.Content.ReadAsStringAsync();
                Items = System.Text.Json.JsonSerializer.Deserialize<List<Drink>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
        if (Items != null)
        {
            return Items;
        }
        else { throw new Exception("No data recived from api"); }
    }
}