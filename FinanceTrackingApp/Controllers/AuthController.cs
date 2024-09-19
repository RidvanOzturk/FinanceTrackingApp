using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace FinanceTrackingApp.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
           return View();
        }


        [HttpPost("register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
