using DataLayer.DTOs;
using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using ServiceLayer.Extensions;

namespace ServiceLayer.Implementations
{
    public class ReportService(IReportRepository reportRepository) : IReportService
    {
        public async Task<ReportingModelDTO> GetReportAsync(ReportFilterDTO model)
        {

            var query = model.ReportMap();

            var incomeQuery = reportRepository.GetIncomeQuery(query);



            var totalIncome = await incomeQuery.SumAsync(i => i.Amount);



            var expenseQuery = reportRepository.GetExpenseQuery(query);

            var totalExpense = await expenseQuery.SumAsync(e => e.Amount);
            var categories = await reportRepository.GetCategories();
            return new ReportingModelDTO
            {
                StartDate = model.startDate,
                EndDate = model.endDate,
                CategoryId = model.categoryId,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense,
                Categories = categories
    .Select(c => new SelectListItem
    {
        Value = c.Id.ToString(),
        Text = c.Name
    }).ToList()
            };
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
           return await reportRepository.GetCategories();
        }
        public async Task<List<IncomeExpenseListModelDTO>> GetReportDataAsync(ReportFilterDTO model)
        {
            var query = model.ReportQueryMap();
            var incomesQuery = reportRepository.GetIncomeQuery(query);
            var incomes = await incomesQuery
                .Select(i => new IncomeExpenseListModelDTO
                {
                    Id = i.Id,
                    CategoryName = i.Category.Name,
                    Amount = i.Amount,
                    Date = i.Date,
                    Type = "Income"
                })
                .ToListAsync();

            var expensesQuery = reportRepository.GetExpenseQuery(query);

            var expenses = await expensesQuery
                .Select(e => new IncomeExpenseListModelDTO
                {
                    Id = e.Id,
                    CategoryName = e.Category.Name,
                    Amount = e.Amount,
                    Date = e.Date,
                    Type = "Expense"
                })
                .ToListAsync();

            var combinedReport = incomes.Concat(expenses).ToList();
            return combinedReport;
        }
        public async Task<decimal> GetTotalIncomeAsync(string username)
        {
            return await reportRepository.GetTotalIncome(username);
        }
        public async Task<decimal> GetTotalExpenseAsync(string username)
        {
            return await reportRepository.GetTotalExpense(username);
        }
    }
}
