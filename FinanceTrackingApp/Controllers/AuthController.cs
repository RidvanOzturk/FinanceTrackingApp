using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Claims;

namespace FinanceTrackingApp.Controllers
{
    public class AuthController(IAuthService authService) : Controller
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(string username, string password)
        {
            if (!ModelState.IsValid)
            {
                return View(username,password);
            }
            var claims = await authService.LoginAsync(username, password);

            if (claims.Count != 0)
            {
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Hatalı giriş olursa buraya düşsün
                ModelState.AddModelError("", "Invalid username or password");
                return View();
            }
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
