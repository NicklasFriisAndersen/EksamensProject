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

        public async Task<RegisteredChild[]?> FilterByNewsletter()
        {
          return await http.GetFromJsonAsync<RegisteredChild[]>($"{serverUrl}/api/registeredchildren/getbynewsletter");
            
        }


        public async Task EditChildItem(RegisteredChild registeredChild)
        {
            await http.PostAsJsonAsync<RegisteredChild>($"{serverUrl}/api/registeredchildren/edit", registeredChild);
        }
    }
}

