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
    public class ChildServiceImpl : IChildService
    {
        
        private readonly string _uri = "https://localhost:7295/api/child/";


        public async Task<IList<Child>> GetAllChildren()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_uri}getAll");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Child>>(responseString);
            }
            else
            {
                throw new Exception($"Error: {response.ReasonPhrase}");
            }
        }

        public async Task CreateChild(Child child)
        {
            using var httpClient = new HttpClient();
            
            var content = new StringContent(
                CustomJsonConvert.SerializeObject(child),
                Encoding.UTF8,
                "application/json"
            );
            
            var response = await httpClient.PostAsync($"{_uri}create", content);
            
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.ReasonPhrase} ");
        }
    }
}