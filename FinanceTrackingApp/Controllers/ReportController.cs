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
    public async Task<IActionResult> GetSummary()
    {
        var categories = await reportService.GetAllCategoriesAsync();
        var reportingViewModel = new ReportingViewModel
        {
            Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList(),
            StartDate = DateTime.Now.AddDays(-30), 
            EndDate = DateTime.Now
        };
        return View(reportingViewModel);
    }
    [HttpGet("generate-report")]
    public async Task<IActionResult> GenerateReport(DateTime startDate, DateTime endDate, Guid? categoryId, string reportType)
    {
        var generateReportModel = new ReportAsyncViewModel
        {
            startDate = startDate,
            endDate = endDate,
            categoryId = categoryId
        };
        var reportData = await reportService.GetReportDataAsync(generateReportModel);

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
        ExcelPackage.LicenseContext = LicenseContext.Commercial;
        using (var package = new ExcelPackage(new FileInfo("MyWorkbook.xlsx")))
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
