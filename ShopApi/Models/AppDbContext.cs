using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace ShopApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<LoginDto> LoginDtos { get; set; }

        public DbSet<RegisterDto> RegisterDtos { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<AuthResponseDto> AuthResponseDtos { get; set; }

    }
}
