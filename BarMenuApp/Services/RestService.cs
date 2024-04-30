using System.Text.Json;
using BarMenuApp;
using System.Web;
public class RestService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    
    
    public List<Drink>? Items { get; private set; }
    private string content;
    public RestService()
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
                Items = JsonSerializer.Deserialize<List<Drink>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    
        return Items;
    }
}