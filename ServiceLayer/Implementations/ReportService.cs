using DataLayer.DTOs;
using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;

namespace ServiceLayer.Implementations
{
    public class ReportService(IReportRepository reportRepository) : IReportService
    {
        public async Task<ReportingViewModel> GetReportAsync(ReportFilterDTO model)
        {

            var query = new ReportFilterRepDTO
            {
                StartDate = model.startDate,
                EndDate = model.endDate,
                CategoryId = model.categoryId,
            };

            var incomeQuery = reportRepository.GetIncomeQuery(query);



            var totalIncome = await incomeQuery.SumAsync(i => i.Amount);



            var expenseQuery = reportRepository.GetExpenseQuery(query);

            var totalExpense = await expenseQuery.SumAsync(e => e.Amount);
            var categories = await reportRepository.GetCategories();
            return new ReportingViewModel
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
        public async Task<List<IncomeExpenseListViewModel>> GetReportDataAsync(ReportFilterDTO model)
        {
            var query = new ReportFilterRepDTO
            {
                StartDate = model.startDate,
                EndDate = model.endDate,
                CategoryId = model.categoryId,
            };
            var incomesQuery = reportRepository.GetIncomeQuery(query);
            var incomes = await incomesQuery
                .Select(i => new IncomeExpenseListViewModel
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
                .Select(e => new IncomeExpenseListViewModel
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
