using RealEstateMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace Service.Service
{
    internal class PropertyService
    {
        private readonly HttpClient client;
        public PropertyService(/*HttpClient client*/)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5130/api/");
        }
        public async Task<IEnumerable<PropertyViewModel>> GetAllPropertiesAsync()
        {
            var response = await client.GetAsync("Property");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<PropertyViewModel>>();
                return result;
            }
           return Array.Empty<PropertyViewModel>();
        }
    }
}
