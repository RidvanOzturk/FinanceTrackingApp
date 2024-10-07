using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;

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
                // Tarih aralığını '-' ile ayırıyoruz ve trim ile boşlukları temizliyoruz
                var dates = daterange.Split('-');
                startDate = DateTime.ParseExact(dates[0].Trim(), "dd-MM-yyyy", null);
                endDate = DateTime.ParseExact(dates[1].Trim(), "dd-MM-yyyy", null);
            }
            catch (Exception ex)
            {
                // Eğer hata olursa varsayılan son 30 günü kullanıyoruz
                startDate = DateTime.Now.AddDays(-30);
                endDate = DateTime.Now;
            }
        }
        else
        {
            // Eğer tarih aralığı gelmezse varsayılan olarak son 30 gün kullanıyoruz
            startDate = DateTime.Now.AddDays(-30);
            endDate = DateTime.Now;
        }

        // Verileri rapor servisinden alıyoruz
        var reportModel = new ReportAsyncViewModel
        {
            startDate = startDate,
            endDate = endDate,
            categoryId = categoryId
        };

        // Rapor verilerini getiriyoruz
        var reportingViewModel = await reportService.GetReportAsync(reportModel);

        // Kategorileri de ekliyoruz
        var categories = await reportService.GetAllCategoriesAsync();
        reportingViewModel.Categories = categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();

        return View(reportingViewModel);
    }




    [HttpPost("download-report")]
    public IActionResult DownloadReport(ReportingViewModel model)
    {
        return Ok();
    }
}
