using FoodHelper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHelper.ViewModels
{
    public class MealViewModel
    {
        public List<Meal> Meals { get; set; }
        public Meal NewMeal { get; set; }
        public List<SelectListItem> AvailableFoods { get; set; }
        public int[] SelectedFoods { get; set; }
    }
}
