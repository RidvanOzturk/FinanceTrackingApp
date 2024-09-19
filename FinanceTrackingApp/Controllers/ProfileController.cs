using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace FinanceTrackingApp.Controllers
{
    public class ProfileController(IProfileService profileService) : Controller
    {
        public IActionResult GetProfile()
        {
            return View();
        }
        [HttpPut]
        public IActionResult UpdateProfile()
        {
           return View();
        }
        [HttpPost("change-password")]
        public IActionResult ChangePassword()
        {
            return BadRequest();    
        }
    }
}
