using Core.Models;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson.Serialization;

namespace SommerSummarum.Services;

public class LoginService : ILoginService
{
    private HttpClient Http;
    private Blazored.LocalStorage.ILocalStorageService localStore;
    private NavigationManager navigationManager;
    
    public LoginService(HttpClient Http, Blazored.LocalStorage.ILocalStorageService localStore, NavigationManager navigationManager)
    {
        this.Http = Http;
        this.localStore = localStore;
        this.navigationManager = navigationManager;
    }
    
    private string serverUrl = "https://localhost:7016";

    

    public async Task HandleLogin(string username, string password)
    {
        // Construct the login URL with query string parameters
        var queryString = $"?username={username}&password={password}";
        var loginUrl = $"{serverUrl}/api/login/signin{queryString}";

        // Perform GET request
        var response = await Http.GetAsync(loginUrl);

        if (response.IsSuccessStatusCode)
        {

            // Redirect to profile page upon successful login

            string responseJson = await response.Content.ReadAsStringAsync();
            //User? user = JsonSerializer.Deserialize<User>(responseJson);
            User? user = BsonSerializer.Deserialize<User>(responseJson);
            Console.WriteLine(responseJson);

            await localStore.SetItemAsync("userinfo", user);
            navigationManager.NavigateTo("/ProfilePage", forceLoad: true);
        }
        else
        {
            // Display error message or handle failed login
            Console.WriteLine("Login failed");
        }

    }
}