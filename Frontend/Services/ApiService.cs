
using Frontend.Models;

namespace Frontend.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiUrl"]);
            _configuration = configuration;
        }

        public async Task<List<MsStorageLocation>> GetLocationsAsync()
        {
            var response = await _httpClient.GetAsync(_configuration["ApiUrl"] + "bpkb/locations");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<List<MsStorageLocation>>();
        }

        public async Task<bool> CreateBpkbAsync(TrBpkb bpkb)
        {
            var response = await _httpClient.PostAsJsonAsync(_configuration["ApiUrl"] + "bpkb", bpkb);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(Login login)
        {
            var response = await _httpClient.PostAsJsonAsync(_configuration["ApiUrl"] + "auth/login", login);
            return response.IsSuccessStatusCode;
        }
    }
}
