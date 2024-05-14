using Core.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;



namespace SommerSummarum.Services
{
    public class PeriodService : IPeriodService
    {
        HttpClient http;

        private string serverUrl = "https://localhost:7016";

        public PeriodService(HttpClient http)
        {
            this.http = http;
        }

        public async Task <List<Period>> GetAllPeriod()
        {
            var periodList = await http.GetFromJsonAsync<List<Period>>($"{serverUrl}/api/period/getAll");
           return periodList;
        } 
      
    }
}

