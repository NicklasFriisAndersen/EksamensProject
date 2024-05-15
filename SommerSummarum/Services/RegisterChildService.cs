using System;
using Core.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Forms;
using static System.Net.WebRequestMethods;

namespace SommerSummarum.Services
{
	public class RegisterChildService : IRegisterChildService
    {
        HttpClient http;

        private string serverUrl = "https://localhost:7016";

        public RegisterChildService(HttpClient http)
		{
            this.http = http;
		}

        public async Task AddChildItem(RegisteredChild registeredChild)
        {
            await http.PostAsJsonAsync<RegisteredChild>($"{serverUrl}/api/registeredchildren/add", registeredChild);
        }

        public async Task<RegisteredChild[]> FilterByKraev(string kraevnummeru18)
        {
            // Build the URL with the search query
            var url = $"{serverUrl}/api/registeredchildren/getbykraevnr?kraevnr={kraevnummeru18}";
            Console.WriteLine(kraevnummeru18);

            // Fetch data from the API and deserialize into a U18Volunteer array
            return await http.GetFromJsonAsync<RegisteredChild[]>(url);
        }
    }
}

