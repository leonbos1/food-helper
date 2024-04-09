using Microsoft.AspNetCore.Mvc;

namespace FoodHelper.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
