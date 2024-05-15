using Core.Models;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace SommerSummarum.Services
{
    public class UserService : IUserService
     {
      HttpClient http;
        private string serverUrl = "https://localhost:7016";

        public UserService(HttpClient http)
        {
            this.http = http;
        }
        public async Task AddUser(User userItem)
        {
            await http.PostAsJsonAsync<User>($"{serverUrl}/api/user/add", userItem);
            userItem = new(); // clear fields in form
        }

        public async Task<User[]> GetAllUsers()
        {
            return await http.GetFromJsonAsync<User[]>($"{serverUrl}/api/user/getall");
        }

        public async Task UpdateUserRole(User user)
        {
            Console.WriteLine("entered updateuserrole");
            await http.PostAsJsonAsync($"{serverUrl}/api/user/update", user);
        }
     }
}
