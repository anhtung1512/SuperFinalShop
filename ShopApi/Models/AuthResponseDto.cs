using System.ComponentModel.DataAnnotations;

namespace ShopApi.Models
{
    public class AuthResponseDto
    {
        [Key]
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
