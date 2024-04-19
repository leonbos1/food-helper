using FoodHelper.Models;
using FoodHelper.Repositories;
using FoodHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class MealController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public MealController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ActionResult> Index()
    {
        var meals = await _unitOfWork.MealRepository.GetAllAsync();

        var vm = new MealViewModel { Meals = meals };

        return View(vm);
    }

    public async Task<ActionResult> Create(MealViewModel viewModel)
    {
        var foods = await _unitOfWork.FoodRepository.GetAllAsync();

        viewModel.AvailableFoods = foods;

        foreach (var food in foods)
        {
            viewModel.AvailableFoodsList.Add(new SelectListItem
            {
                Text = food.Name,
                Value = food.Id.ToString()
            });
        }

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Meal/Create")]
    public async Task<ActionResult> CreatePost(MealViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        await _unitOfWork.MealRepository.AddAsync(viewModel.NewMeal);

        await _unitOfWork.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
