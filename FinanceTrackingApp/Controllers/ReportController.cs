using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using ServiceLayer.Implementations;

namespace FinanceTrackingApp.Controllers;

public class ReportController(IReportService reportService) : Controller
{


    [HttpGet("report-summary")]
    public async Task<IActionResult> GetSummary()
    {
        var categories = await reportService.GetAllCategoriesAsync();

        var model = new ReportingViewModel
        {
            StartDate = DateTime.Now.AddMonths(-1), 
            EndDate = DateTime.Now,
            Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList() 
        };

        return View(model);
    }
    [HttpGet("get-report")]
    public IActionResult GetReport(DateTime startDate, DateTime endDate)
    {
        return View(startDate);
    }
}
