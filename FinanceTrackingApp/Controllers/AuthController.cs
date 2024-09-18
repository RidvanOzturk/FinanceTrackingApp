using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingApp.Controllers
{
    public class AuthController : Controller
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
