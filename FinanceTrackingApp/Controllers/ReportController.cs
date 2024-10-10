using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
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
                startDate = DateTime.ParseExact(dates[0].Trim(), "dd/MM/yyyy", null);
                endDate = DateTime.ParseExact(dates[1].Trim(), "dd/MM/yyyy", null);
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
        DateTime startDate, endDate;

        if (!string.IsNullOrEmpty(daterange))
        {
            var dates = daterange.Split('-');
            startDate = DateTime.ParseExact(dates[0].Trim(), "dd/MM/yyyy", null);
            endDate = DateTime.ParseExact(dates[1].Trim(), "dd/MM/yyyy", null);
        }
        else
        {
            startDate = DateTime.Now.AddDays(-30); 
            endDate = DateTime.Now;
        }
        var generateReportModel = new ReportAsyncViewModel
        {
            startDate = startDate,
            endDate = endDate,
            categoryId = categoryId
        };
        var reportData = await reportService.GetReportDataAsync(generateReportModel);

        var reportType = Request.Form["reportType"]; 

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

        return BadRequest("Invalid report type.");
    }


    private byte[] GenerateExcel(List<IncomeExpenseListViewModel> reportData)
    {
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Report");
            worksheet.Cells[1, 1].Value = "Category";
            worksheet.Cells[1, 2].Value = "Amount";
            worksheet.Cells[1, 3].Value = "Date";
            worksheet.Cells[1, 4].Value = "Type";  

            for (int i = 0; i < reportData.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = reportData[i].CategoryName;
                worksheet.Cells[i + 2, 2].Value = reportData[i].Amount;
                worksheet.Cells[i + 2, 3].Value = reportData[i].Date.ToString("dd-MM-yyyy");
                worksheet.Cells[i + 2, 4].Value = reportData[i].Type;  
            }

            return package.GetAsByteArray();
        }
    }
    private byte[] GeneratePdf(List<IncomeExpenseListViewModel> reportData)
    {
        using (var memoryStream = new MemoryStream())
        {
            var document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, memoryStream);

            document.Open();
            document.Add(new Paragraph("Report"));

            foreach (var item in reportData)
            {
                document.Add(new Paragraph($"{item.CategoryName} - {item.Amount} - {item.Date:dd-MM-yyyy} - {item.Type}"));
            }

            document.Close();
            return memoryStream.ToArray();
        }
    }




}
