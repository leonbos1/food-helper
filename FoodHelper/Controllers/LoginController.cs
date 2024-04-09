using FoodHelper.Logic.Services.Base;
using FoodHelper.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FoodHelper.Controllers
{
    [Route("")]
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _authService.Login(loginViewModel.Email, loginViewModel.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("Email", "Invalid email or password");
            }




            return View();
        }

        [Route("register")]
        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(LoginViewModel loginViewModel)
        {
            return View();
        }
    }
}
