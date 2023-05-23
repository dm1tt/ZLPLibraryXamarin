using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZLPLibrary.Model;
using JsonSerializer = System.Text.Json.JsonSerializer;

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
        public async Task<ObservableCollection<ShortBook>> GetAllShortBooksAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/books/short");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var shortBooks = JsonConvert.DeserializeObject<ObservableCollection<ShortBook>>(content);
                return shortBooks;
            }
            return null;
        }
        public async Task<FullBookResponse> GetFullBookAsync(int bookId)
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/books/{bookId}");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var fullBookResponse = JsonConvert.DeserializeObject<FullBookResponse>(content);
                return fullBookResponse;
            }
            return null;
        }
        public async Task<int> PostNewBookAsync(FullBook fullBook)
        {
            var newJson = JsonSerializer.Serialize(fullBook);
            var content = new StringContent(newJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{BaseUrl}/books", content);
            if (response.IsSuccessStatusCode)
            {
                var addedBookJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<int>(addedBookJson);
            }
            else
            {
                throw new Exception("Failed to add book.");
            }
        }
    }
}