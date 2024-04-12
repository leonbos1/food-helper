using FoodHelper.Data.Models.Base;

namespace FoodHelper.Data.Models
{
    public class Profile : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
    }
}
