using FoodHelper.ViewModels;
using FoodHelper.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodHelper.Repositories;

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

    public async Task<ActionResult> Create()
    {
        var availableFoods = await _unitOfWork.FoodRepository.GetAllAsync();

        var viewModel = new MealViewModel
        {
            NewMeal = new Meal(),
            AvailableFoods = availableFoods.Select(f => new SelectListItem
            {
                Value = f.Id.ToString(),
                Text = f.Name
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(MealViewModel viewModel)
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
