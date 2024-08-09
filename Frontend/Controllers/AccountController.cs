using Frontend.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class AccountController : Controller
    {
        private readonly IApiService _apiService;

        public AccountController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var success = await _apiService.LoginAsync(login);

            if (success)
            {
                // Set session, redirect to another page
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid login attempt";
            return View(login);
        }
    }
}
