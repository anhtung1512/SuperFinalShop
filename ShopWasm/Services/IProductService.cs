using ShopApi.Models;

namespace ShopApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        Task<Product> AddProduct(Product product); // Định nghĩa phương thức AddProduct
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
