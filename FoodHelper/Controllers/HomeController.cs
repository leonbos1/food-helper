using FoodHelper.Data.Models;
using FoodHelper.Data.Repositories;
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
            var foods = await _unitOfWork.FoodRepository.GetAllAsync();

            return View(foods);
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
