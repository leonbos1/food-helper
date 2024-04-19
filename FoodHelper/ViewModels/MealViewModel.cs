using FoodHelper.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodHelper.ViewModels
{
    public class MealViewModel
    {
        public Meal NewMeal { get; set; }
        public List<Food> AvailableFoods { get; set; }
        public List<SelectListItem> AvailableFoodsList { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Food> SelectedFoods { get; set; }

        public MealViewModel()
        {
            NewMeal = new Meal();
            AvailableFoods = new List<Food>();
            AvailableFoodsList = new List<SelectListItem>();
            Meals = new List<Meal>();
            SelectedFoods = new List<Food>();
        }
    }
}
