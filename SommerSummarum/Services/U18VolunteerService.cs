using System.Net;
using Core.Models;
using System.Net.Http.Json;
namespace SommerSummarum.Services;

public class U18VolunteerService : IU18VolunteerService
{ 
    HttpClient http;

    private string serverUrl = "https://localhost:7016";

    public U18VolunteerService(HttpClient http)
    {
        this.http = http;
    }

    public async Task AddU18Volunteer(U18Volunteer u18VolunteerItem)
    {
        await http.PostAsJsonAsync<U18Volunteer>($"{serverUrl}/api/u18volunteer/add", u18VolunteerItem);
    }

    public async Task<U18Volunteer[]> FilterByU18Kraev(string kraevnummeru18)
    {
        // Build the URL with the search query
        var url = $"{serverUrl}/api/u18volunteer/getbykraevu18?kraevnummerU18={kraevnummeru18}";
        Console.WriteLine(kraevnummeru18);

        // Fetch data from the API and deserialize into a U18Volunteer array
        return await http.GetFromJsonAsync<U18Volunteer[]>(url);
    }
}