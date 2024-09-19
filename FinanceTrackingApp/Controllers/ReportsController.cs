using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace FinanceTrackingApp.Controllers
{
    public class ReportsController(IReportsService reportsService) : Controller
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
