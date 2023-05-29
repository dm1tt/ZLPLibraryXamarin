using Newtonsoft.Json;
using System;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZLPLibrary.Model;

namespace ZLPLibrary.Service
{
    public class ReaderService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "http://192.168.0.108:8080/api";
        public ReaderService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ObservableCollection<Reader>> GetAllReadersAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/readers");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var readers = JsonConvert.DeserializeObject<ObservableCollection<Reader>>(content);
                return readers;
            }
            return null;
        }
        public async Task PostNewBookAsync(Reader newReader)
        {
            string newJson = JsonSerializer.Serialize(newReader);
            var content = new StringContent(newJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync($"{BaseUrl}/readers", content);
        }
    }
}
