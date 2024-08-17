// Services/ICartService.cs
using ShopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICartService
{
    Task AddToCart(Product product);
    Task<IEnumerable<Product>> GetCartItems();
    Task RemoveFromCart(Product product);
    Task UpdateQuantity(int productId, int quantity);
    Task UpdateCartItem(Product product); // Thêm phương thức này
}
