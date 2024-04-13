using FoodHelper.Models;

namespace FoodHelper.ViewModels
{
    public class FoodViewModel
    {
        public List<Food>? Foods { get; set; }
        public Food NewFood { get; set; }
        public Food? SelectedFood { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? CurrentUserId { get; set; }

        public FoodViewModel()
        {
            NewFood = new Food();
        }
    }
}
