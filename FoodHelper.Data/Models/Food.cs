using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace FoodHelper.Data.Models
{
    public class Food
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public double? Carbohydrates { get; set; }

        public double? Proteins { get; set; }

        public double? Fats { get; set; }

        public double? Fibres { get; set; }

        public double? Alcohol { get; set; }

        public double? Calories => (Carbohydrates * 4) + (Proteins * 4) + (Fats * 9) + (Alcohol * 7) + (Fibres * 2);

        public double? Weight { get; set; }

        public double? Price { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public Guid? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
