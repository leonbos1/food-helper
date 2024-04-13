using FoodHelper.Models;

namespace FoodHelper.ViewModels
{
    public class HomeViewModel
    {
        public List<Food>? FiveLatestAddedFoods { get; set; }
        public List<Food>? FiveProteinHighFoods { get; set; }
    }
}
