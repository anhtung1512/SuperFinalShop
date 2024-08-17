namespace ShopApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } // Ví dụ: "Pending", "Shipped", "Delivered"
        public List<OrderItem> OrderItems { get; set; }
    }
}
