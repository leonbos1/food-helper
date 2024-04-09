using FoodHelper.Logic.Helpers;
using FoodHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodHelper.Controllers
{
    public class CalculatorController : Controller
    {
        public CalculatorController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateBMI(CalculateViewModel vm)
        {
            var bmi = BmiCalculator.Calculate(vm.BodyHeight, vm.BodyWeight);

            return Json(bmi);
        }

        [HttpPost]
        public IActionResult CalculateCalories(CalculateViewModel vm)
        {
            var calories = CaloriesCalculator.Calculate(vm.BodyHeight, vm.BodyWeight, vm.Age, vm.ExercisesPerWeek, vm.Gender ?? "Man");

            return Json(calories);
        }

        [HttpPost]
        public IActionResult Calculate1rm(CalculateViewModel vm)
        {
            var oneRepMax = OneRmCalculator.Calculate(vm.Weight, vm.Reps);

            return Json(oneRepMax);
        }
    }
}
