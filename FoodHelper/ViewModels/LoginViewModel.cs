using FoodHelper.Data.Models;

namespace FoodHelper.ViewModels
{
    public class LoginViewModel
    {
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public User? User { get; set; }
    }
}
