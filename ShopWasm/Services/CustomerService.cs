using ShopApi.Models;
using System.Collections.Concurrent;
using System.Net.Http.Json;

namespace ShopWasm.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly ConcurrentBag<Product> cartItems = new ConcurrentBag<Product>();


        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Product>>("api/products");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/products/{id}");
        }

        public Task AddToCart(Product product)
        {
            var existingItem = cartItems.FirstOrDefault(p => p.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += product.Quantity;
            }
            else
            {
                cartItems.Add(product);
            }
            return Task.CompletedTask;
        }
    }
}
