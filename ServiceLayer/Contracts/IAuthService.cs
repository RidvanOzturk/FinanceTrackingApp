using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IAuthService
    {
        Task<List<Claim>> LoginAsync(string username, string password);
        Task<bool> RegisterAsync(RegisterRequestDTO registerRequestDTO);
        Task LogoutAsync();

    }
}
