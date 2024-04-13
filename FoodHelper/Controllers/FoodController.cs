using FoodHelper.Repositories;
using FoodHelper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FoodHelper.Controllers
{
    public class FoodController : Controller
    {
        private readonly IUnitOfWork _uow;

        public FoodController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            var foods = await _uow.FoodRepository.GetAllAsync();

            var vm = new FoodViewModel
            {
                Foods = foods
            };

            return View(vm);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(FoodViewModel vm)
        {
            var food = vm.NewFood;

            food.User = await _uow.UserRepository.GetFirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (food.User == null)
            {
                return BadRequest();
            }

            if (food == null)
            {
                return BadRequest();
            }

            if (vm.ImageFile != null && vm.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await vm.ImageFile.CopyToAsync(memoryStream);
                    vm.NewFood.Image = memoryStream.ToArray();
                }
            }

            await _uow.FoodRepository.AddAsync(food);

            await _uow.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var food = await _uow.FoodRepository.GetByIdWithUserAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            var vm = new FoodViewModel
            {
                SelectedFood = food,
                CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            return View(vm);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            var food = await _uow.FoodRepository.GetByIdAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            var vm = new FoodViewModel
            {
                SelectedFood = food
            };

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(FoodViewModel vm)
        {
            var food = vm.SelectedFood;

            if (food == null)
            {
                return BadRequest();
            }

            if (vm.ImageFile != null && vm.ImageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await vm.ImageFile.CopyToAsync(memoryStream);
                    vm.NewFood.Image = memoryStream.ToArray();
                }
            }

            await _uow.FoodRepository.Update(food);

            await _uow.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            var food = await _uow.FoodRepository.GetByIdAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var food = await _uow.FoodRepository.GetByIdAsync(id);

            if (food == null)
            {
                return NotFound();
            }

            await _uow.FoodRepository.Delete(food);

            await _uow.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
