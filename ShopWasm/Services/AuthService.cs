using ShopApi.Models;
using System.Net.Http.Json;

namespace ShopWasm.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly TokenStorage _tokenStorage;
        public AuthService(HttpClient httpClient, TokenStorage tokenStorage)
        {
            _httpClient = httpClient;
            _tokenStorage = tokenStorage;
        }

        public async Task<string> LoginAsync(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/auth/login", loginDto);

            if (response.IsSuccessStatusCode)
            {
                // Assuming the API returns a JWT token
                var token = await response.Content.ReadAsStringAsync();
                _tokenStorage.Token = token;
                return token;
            }

            return null; // Or throw an exception depending on your needs
        }

    }
}
