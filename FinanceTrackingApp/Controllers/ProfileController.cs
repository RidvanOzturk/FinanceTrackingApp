using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingApp.Controllers
{
    public class ProfileController : Controller
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
