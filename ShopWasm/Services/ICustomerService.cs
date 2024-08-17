using ShopApi.Models;

namespace ShopWasm.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProduct(int id);
        Task AddToCart(Product product);
    }
}
