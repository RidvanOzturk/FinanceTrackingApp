using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingApp.Controllers
{
    public class ReportsController : Controller
    {
        [HttpGet("summary")]
        public IActionResult GetSummary(DateTime startDate, DateTime endDate)
        {
            return View();
        }
        [HttpGet("breakdown")]
        public IActionResult GetBreakdown(DateTime startDate, DateTime endDate)
        {
            return View(startDate);
        }


    }
}
