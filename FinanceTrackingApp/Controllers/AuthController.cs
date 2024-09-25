using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ServiceLayer.Contracts;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ServiceLayer.Implementations;
using ServiceLayer.DTOs;
using FinanceTrackingApp.Models.Requests;

namespace FinanceTrackingApp.Controllers;

[Route("Auth")]
public class AuthController(IAuthService authService) : Controller
{
    [HttpGet("login")]
    public IActionResult Login()
    {
        return View(); 
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        if (!ModelState.IsValid)
        {
            return View(); 
        }
        var claims = await authService.LoginAsync(username, password);
        if (claims.Count > 0)
        {
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index", "Home"); 
        }
        else
        {
            ModelState.AddModelError("", "Invalid username or password");
            return View(); 
        }
    }

    [HttpGet("register")]
    public IActionResult Register()
    {
        return View(); 
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestModel requestModel)
    {
        if (!ModelState.IsValid)
        {
            return View(requestModel);
        }
        var requestDTO = new RegisterRequestDTO
        {
            username = requestModel.username,
            email = requestModel.mail,
            password = requestModel.password
        };
        var result = await authService.RegisterAsync(requestDTO);
        if (result)
        {
            return RedirectToAction("Login");
        }
        else
        {
            ModelState.AddModelError("", "User already exists");
            return View(requestModel);
        }
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await authService.LogoutAsync();
        return RedirectToAction("Login", "Auth");
    }
}
