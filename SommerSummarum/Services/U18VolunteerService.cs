using System.Net;
using Core.Models;
using System.Net.Http.Json;
namespace SommerSummarum.Services;

public class U18VolunteerService : IU18VolunteerService
{ 
    HttpClient http;

    private string serverUrl = "https://msfserver.azurewebsites.net/";


    public U18VolunteerService(HttpClient http)
    {
        this.http = http;
    }

    public async Task AddU18Volunteer(U18Volunteer u18VolunteerItem)
    {
        await http.PostAsJsonAsync<U18Volunteer>($"{serverUrl}/api/u18volunteer/add", u18VolunteerItem);
    }

    public async Task<U18Volunteer[]> FilterByKraew(string kraewnummer)
    {
       return await http.GetFromJsonAsync<U18Volunteer[]>(
            $"{serverUrl}/api/u18volunteer/getbykraevu18?kraevnummerU18={kraewnummer}");
        


    }
}