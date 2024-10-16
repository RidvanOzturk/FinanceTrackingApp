using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using BCrypt.Net;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using DataLayer.Repositories.Contracts;
using DataLayer.Repositories.Implementations;


namespace ServiceLayer.Implementations
{
    public class AuthService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IConfiguration configuration) : IAuthService
    {
        public async Task<bool> RegisterAsync(RegisterRequestDTO requestDTO)
        {
            var user = await userRepository.GetByNameandEmailAsync(requestDTO.username,requestDTO.email);
            if (user != null)
            {
                return false;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(requestDTO.password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Username = requestDTO.username,
                Email = requestDTO.email,
                PasswordHash = hashedPassword 
            };

            await userRepository.Create(newUser);
            var result = userRepository.CommitAsync();

            return result != null;
        }

        public async Task<List<Claim>> LoginAsync(string username, string password)
        {
            var user = await userRepository.GetByNameandEmailAsync(username, password);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return new List<Claim>();
            }


            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("UserId", user.Id.ToString()) 
        };
            var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true, 
            };

            await httpContextAccessor.HttpContext.SignInAsync(
                "Cookies",
                new ClaimsPrincipal(claimsIdentity),
                authProperties
            );
            return claims;



        }

        public async Task LogoutAsync()
        {
            await httpContextAccessor.HttpContext.SignOutAsync("Cookies");
        }
    }
}
