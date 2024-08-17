// Services/CartService.cs
using ShopApi.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CartService : ICartService
{
    private readonly ConcurrentBag<Product> cartItems = new ConcurrentBag<Product>();

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

    public Task<IEnumerable<Product>> GetCartItems()
    {
        return Task.FromResult(cartItems.AsEnumerable());
    }

    public Task RemoveFromCart(Product product)
    {
        var itemToRemove = cartItems.FirstOrDefault(p => p.Id == product.Id);
        if (itemToRemove != null)
        {
            if (itemToRemove.Quantity > product.Quantity)
            {
                itemToRemove.Quantity -= product.Quantity;
            }
            else
            {
                cartItems.TryTake(out itemToRemove); // Xóa sản phẩm khỏi danh sách
            }
        }
        return Task.CompletedTask;
    }

    public Task UpdateQuantity(int productId, int quantity)
    {
        var existingItem = cartItems.FirstOrDefault(p => p.Id == productId);
        if (existingItem != null)
        {
            if (quantity <= 0)
            {
                cartItems.TryTake(out existingItem); // Xóa sản phẩm nếu số lượng <= 0
            }
            else
            {
                existingItem.Quantity = quantity;
            }
        }
        return Task.CompletedTask;
    }

    public Task UpdateCartItem(Product product)
    {
        var existingItem = cartItems.FirstOrDefault(p => p.Id == product.Id);
        if (existingItem != null)
        {
            existingItem.Quantity = product.Quantity;
        }
        return Task.CompletedTask;
    }

    public Task ClearCart()
    {
        cartItems.Clear(); // Xóa tất cả sản phẩm trong giỏ hàng
        return Task.CompletedTask;
    }
}
