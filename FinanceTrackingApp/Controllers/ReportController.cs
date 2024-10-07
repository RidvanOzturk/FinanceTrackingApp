using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using ServiceLayer.Implementations;

namespace FinanceTrackingApp.Controllers;

public class ReportController(IReportService reportService) : Controller
{
    [Authorize]
    [HttpGet("report-summary")]
    public async Task<IActionResult> GetSummary(string daterange, Guid? categoryId)
    {
        DateTime startDate, endDate;

        if (!string.IsNullOrEmpty(daterange))
        {
            try
            {
                var dates = daterange.Split('-');
                startDate = DateTime.ParseExact(dates[0].Trim(), "dd-MM-yyyy", null);
                endDate = DateTime.ParseExact(dates[1].Trim(), "dd-MM-yyyy", null);
            }
            catch (Exception ex)
            {
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }
        }
        else
        {
            startDate = DateTime.Now.AddDays(-30);
            endDate = DateTime.Now;
        }

        var reportModel = new ReportAsyncViewModel
        {
            startDate = startDate,
            endDate = endDate,
            categoryId = categoryId
        };

        var reportingViewModel = await reportService.GetReportAsync(reportModel);

        var categories = await reportService.GetAllCategoriesAsync();
        reportingViewModel.Categories = categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        return View(reportingViewModel);
    }

    [HttpPost("generate-report")]
    public async Task<IActionResult> GenerateReport(string daterange, Guid? categoryId)
    {
        var dates = daterange?.Split('-');
        if (dates.Length == 2 && DateTime.TryParse(dates[0], out DateTime startDate) && DateTime.TryParse(dates[1], out DateTime endDate))
        {
           
            var reportType = Request.Form["reportType"]; // "pdf" / "excel" 

            if (reportType == "pdf")
            {
                var pdf = GeneratePdf(reportData);
                return File(pdf, "application/pdf", "report.pdf");
            }
            else if (reportType == "excel")
            {
                var excel = GenerateExcel(reportData);
                return File(excel, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");
            }
        }

        return BadRequest("Invalid date range or category.");
    }


    [HttpPost("download-report")]
    public IActionResult DownloadReport(ReportingViewModel model)
    {
        return Ok();
    }



}
