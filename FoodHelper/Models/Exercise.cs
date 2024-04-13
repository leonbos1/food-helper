using FoodHelper.Data.Models.Base;

namespace FoodHelper.Models
{
    public class Exercise : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
