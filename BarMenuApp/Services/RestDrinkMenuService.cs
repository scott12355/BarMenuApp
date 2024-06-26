using System.Text;
using System.Text.Json;
using BarMenuApp;
using System.Web;
using Newtonsoft.Json;
public class RestDrinkMenuService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _serializerOptions;
    
    private List<Drink> Items { get; set; }
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

    /// <summary>
    /// This method is responsible for fetching drink menu data from a REST API.
    /// </summary>
    /// <returns>A list of Drink objects.</returns>
    /// <exception cref="Exception">Thrown when no data is received from the API.</exception>
    public async Task<List<Drink>> RefreshDataAsync()
    {
        // Initialize the list of Drinks
        Items = new List<Drink>();
    
        // Construct the API endpoint URI
        Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
    
        try
        {
            // Send a GET request to the API
            HttpResponseMessage response = await _client.GetAsync(uri);
    
            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Configure JSON deserialization options
                _serializerOptions.AllowTrailingCommas = false;
    
                // Read the response content as a string
                content = await response.Content.ReadAsStringAsync();
    
                // Deserialize the JSON response into a list of Drink objects
                Items = System.Text.Json.JsonSerializer.Deserialize<List<Drink>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            // Log the error message
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }
    
        // Check if any data was received from the API
        if (Items!= null)
        {
            // Return the list of Drink objects
            return Items;
        }
        else
        {
            // Throw an exception if no data was received from the API
            throw new Exception("No data received from API");
        }
    }
    
    public async Task<HttpResponseMessage> PostDrinkAsync(DrinkPostJson drink)
    {
        Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
        string jsonContent = JsonConvert.SerializeObject(drink);
        HttpContent httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
        httpContent.Headers.Add("Auth", "30112001");
        try
        {
            HttpResponseMessage response = await _client.PostAsync(uri, httpContent);
            return response;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
            return null;
        }
    }
}