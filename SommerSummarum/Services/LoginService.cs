using Core.Models;
using System.Net.Http.Json;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MongoDB.Bson.Serialization;

namespace SommerSummarum.Services;

public class LoginService : ILoginService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManager;
    private readonly ILocalStorageService _localStorageService;
    private string serverUrl = "https://localhost:7016"; // Adjust the URL based on your configuration

    public LoginService(HttpClient httpClient, NavigationManager navigationManager, ILocalStorageService localStorageService)
    {
        _httpClient = httpClient;
        _navigationManager = navigationManager;
        _localStorageService = localStorageService;
    }

    public async Task<User?> LoginAsync(string username, string password)
    {
        var queryString = $"?username={username}&password={password}";
        var loginUrl = $"{serverUrl}/api/login/signin{queryString}";

        var response = await _httpClient.GetAsync(loginUrl);

        if (response.IsSuccessStatusCode)
        {
            string responseJson = await response.Content.ReadAsStringAsync();
            var user = JsonSerializer.Deserialize<User>(responseJson);
            if (user != null)
            {
                await _localStorageService.SetItemAsync("userinfo", user);
                _navigationManager.NavigateTo("/ProfilePage", forceLoad: true);
            }
            return user;
        }
        else
        {
            Console.WriteLine("Login failed");
            return null;
        }
    }
}
