using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;

namespace FinanceTrackingApp.Controllers;

public class ReportController(IReportService reportService) : Controller
{
    

    [HttpGet("report-summary")]
    public IActionResult GetSummary()
    {
        return View();
    }

    [HttpGet("get-report")]
    public IActionResult GetReport(DateTime startDate, DateTime endDate)
    {
        return View(startDate);
    }
}
