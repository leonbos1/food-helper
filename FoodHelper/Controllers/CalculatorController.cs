using FoodHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FoodHelper.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CalculateBMI(CalculateViewModel vm)
        {
            var height = vm.BodyHeight;
            var weight = vm.BodyWeight;

            if (height <= 0 || weight <= 0)
            {
                ModelState.AddModelError("BodyHeight", "Height and weight must be greater than 0");
                return BadRequest("Height and weight must be greater than 0");
            }

            if (height > 3)
            {
                height /= 100;
            }

            var bmi = Math.Round(weight / (height * height), 2);

            return Json(bmi);
        }

        [HttpPost]
        public IActionResult CalculateCalories(CalculateViewModel vm)
        {
            var height = vm.BodyHeight;
            var weight = vm.BodyWeight;
            var age = vm.Age;
            var exercisesPerWeek = vm.ExercisesPerWeek;
            var gender = vm.Gender;

            if (height <= 0 || weight <= 0)
            {
                ModelState.AddModelError("BodyHeight", "Height and weight must be greater than 0");
                return BadRequest("Height and weight must be greater than 0");
            }

            if (height > 3)
            {
                height /= 100;
            }

            double bmr;
            if (gender == "Man")
            {
                bmr = 88.362 + (13.397 * weight) + (4.799 * height * 100) - (5.677 * age);
            }
            else if (gender == "Woman")
            {
                bmr = 447.593 + (9.247 * weight) + (3.098 * height * 100) - (4.330 * age);
            }
            else
            {
                return BadRequest("Invalid gender");
            }

            double activityFactor;
            switch (exercisesPerWeek)
            {
                case 0:
                    activityFactor = 1.2;
                    break;
                case 1:
                case 2:
                case 3:
                    activityFactor = 1.375;
                    break;
                case 4:
                case 5:
                case 6:
                    activityFactor = 1.55;
                    break;
                default:
                    activityFactor = 1.725;
                    break;
            }

            int calories = (int)(bmr * activityFactor);

            return Json(calories);
        }

        [HttpPost]
        public IActionResult Calculate1rm(CalculateViewModel vm)
        {
            var weight = vm.Weight;
            var reps = vm.Reps;

            if (weight <= 0 || reps <= 0)
            {
                ModelState.AddModelError("BodyWeight", "Weight and reps must be greater than 0");
                return BadRequest("Weight and reps must be greater than 0");
            }

            double oneRepMax = weight * (1 + reps / 30.0);

            return Json(oneRepMax);
        }
    }
}
