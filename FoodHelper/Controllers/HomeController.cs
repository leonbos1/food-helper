using FoodHelper.Data;
using FoodHelper.Data.Models;
using FoodHelper.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace food_helper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly FoodRepository foodRepository;

        public HomeController(ILogger<HomeController> logger, FoodRepository foodRepository)
        {
            _logger = logger;
            this.foodRepository = foodRepository;
        }

        public IActionResult Index()
        {
            var foods = foodRepository.GetAll();

            return View(foods);
        }

        [Route("add")]
        public async Task<IActionResult> Add()
        {
            var food = new Food { Name = "Bread" };

            await foodRepository.Add(food);

            foodRepository.Save();

            return RedirectToAction("Index");
        }
    }
}
