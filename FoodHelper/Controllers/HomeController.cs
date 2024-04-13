using FoodHelper.Models;
using FoodHelper.Repositories;
using FoodHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace food_helper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var vm = new HomeViewModel
            {
                FiveLatestAddedFoods = await _unitOfWork.FoodRepository.GetFiveLatestAddedFoodsAsync(),
                FiveProteinHighFoods = await _unitOfWork.FoodRepository.GetFiveProteinHighFoods(),
            };

            return View(vm);
        }

        [Route("add")]
        public async Task<IActionResult> Add()
        {
            var food = new Food { Name = "Bread" };

            await _unitOfWork.FoodRepository.AddAsync(food);

            await _unitOfWork.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
