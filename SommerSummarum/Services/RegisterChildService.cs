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

        //private string serverUrl = "https://localhost:7016";
        private string serverUrl = "https://msfserver.azurewebsites.net/";



        public RegisterChildService(HttpClient http)
		{
            this.http = http;
		}

        public async Task<HttpResponseMessage> AddChildItem(RegisteredChild registeredChild)
        {
            var result = await http.PostAsJsonAsync<RegisteredChild>($"{serverUrl}/api/registeredchildren/add", registeredChild);
            return result;
        }

        public async Task<RegisteredChild[]?> FilterByNewsletter()
        {
          return await http.GetFromJsonAsync<RegisteredChild[]>($"{serverUrl}/api/registeredchildren/getbynewsletter");
            
        }

        public async Task EditChildItem(RegisteredChild registeredChild)
        {
            await http.PostAsJsonAsync<RegisteredChild>($"{serverUrl}/api/registeredchildren/edit", registeredChild);
        }

        public async Task<RegisteredChild[]?> GetAllChildren()
        {
            var childList = await http.GetFromJsonAsync<RegisteredChild[]>($"{serverUrl}/api/registeredchildren/getall");
            return childList;
        }

        public async Task<RegisteredChild[]?> GetAllChildrenPrioSort()
        {
            var childList = await http.GetFromJsonAsync<RegisteredChild[]>($"{serverUrl}/api/registeredchildren/getallprio");
            return childList;
        }
    }
}

