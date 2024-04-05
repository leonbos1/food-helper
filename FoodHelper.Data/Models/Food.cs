using Microsoft.EntityFrameworkCore;

namespace FoodHelper.Data.Models
{
    public class Food
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
