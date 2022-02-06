using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Client.Utility;
using Newtonsoft.Json;
using WebAPI.Model;

namespace Blazor.Service
{
    public class ToyServiceImpl : IToyService
    {

        private readonly HttpClient _httpClient;
        private readonly string _uri = "https://localhost:7295/api/toy/";

        public async Task<IList<Toy>> GetAllToys()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_uri}getAll");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Toy>>(responseString);
            }
            else
            {
                throw new Exception($"Error: {response.ReasonPhrase}");
            }
        }

        public async Task CreateToy(Toy toy, int childId)
        {
            using var httpClient = new HttpClient();
            
            var content = new StringContent(
                CustomJsonConvert.SerializeObject(toy),
                Encoding.UTF8,
                "application/json"
            );
            
            var response = await httpClient.PostAsync($"{_uri}create?childId={childId}", content);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.ReasonPhrase} ");
        }

        public async Task DeleteToy(int id)
        {
            using var httpClient = new HttpClient();

            var response = await httpClient.DeleteAsync($"{_uri}delete?id={id}");

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.ReasonPhrase}");
        }
    }
}