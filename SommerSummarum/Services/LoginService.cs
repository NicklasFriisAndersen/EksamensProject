using Core.Models;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson.Serialization;

namespace SommerSummarum.Services;

public class LoginService : ILoginService
{
    private string serverUrl = "https://msfserver.azurewebsites.net/";

    private HttpClient Http;
    private Blazored.LocalStorage.ILocalStorageService localStore;
    private NavigationManager navigationManager;
    
    public LoginService(HttpClient Http, Blazored.LocalStorage.ILocalStorageService localStore, NavigationManager navigationManager)
    {
        this.Http = Http;
        this.localStore = localStore;
        this.navigationManager = navigationManager;
    }

    

    public async Task HandleLogin(string username, string password)
    {
        var queryString = $"?username={username}&password={password}";
        var loginUrl = $"{serverUrl}/api/login/signin{queryString}";

        var response = await Http.GetAsync(loginUrl);

        if (response.IsSuccessStatusCode)
        {
            string responseJson = await response.Content.ReadAsStringAsync();
            User? user = BsonSerializer.Deserialize<User>(responseJson);
            Console.WriteLine(responseJson);

            await localStore.SetItemAsync("userinfo", user);
            navigationManager.NavigateTo("/ProfilePage", forceLoad: true);
        }
        else
        {
            Console.WriteLine("Login failed");
        }

    }
}