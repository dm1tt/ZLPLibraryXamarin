using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ZLPLibrary.Model;
    


namespace ZLPLibrary.Service
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "http://192.168.0.108:8080/api";
        public ProductService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<ShortBook>> GetAllShortBooksAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/books/short");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var shortBooks = JsonConvert.DeserializeObject<List<ShortBook>>(content);
                return shortBooks;
            }
            return null;
        }
    }
}