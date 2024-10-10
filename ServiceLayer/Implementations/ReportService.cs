using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class ReportService(FinanceContext context) : IReportService
    {
        public async Task<ReportingViewModel> GetReportAsync(ReportAsyncViewModel model)
        {
            var incomeQuery = context.Incomes
                .Where(i => i.Date >= model.startDate && i.Date <= model.endDate);

            if (model.categoryId.HasValue)
            {
                incomeQuery = incomeQuery.Where(i => i.CategoryId == model.categoryId.Value);
            }

            var totalIncome = await incomeQuery.SumAsync(i => i.Amount);

            var expenseQuery = context.Expenses
                .Where(e => e.Date >= model.startDate && e.Date <= model.endDate);

            if (model.categoryId.HasValue)
            {
                expenseQuery = expenseQuery.Where(e => e.CategoryId == model.categoryId.Value);
            }

            var totalExpense = await expenseQuery.SumAsync(e => e.Amount);

            return new ReportingViewModel
            {
                StartDate = model.startDate,
                EndDate = model.endDate,
                CategoryId = model.categoryId,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense,
                Categories = await context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToListAsync()
            };
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await context.Categories
                .ToListAsync();
        }
        public async Task<List<IncomeExpenseListViewModel>> GetReportDataAsync(ReportAsyncViewModel model)
        {
            var incomesQuery = context.Incomes
                .Where(i => i.Date >= model.startDate && i.Date <= model.endDate);

            if (model.categoryId.HasValue)
            {
                incomesQuery = incomesQuery.Where(i => i.CategoryId == model.categoryId.Value);
            }

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

            var expensesQuery = context.Expenses
                .Where(e => e.Date >= model.startDate && e.Date <= model.endDate);

            if (model.categoryId.HasValue)
            {
                expensesQuery = expensesQuery.Where(e => e.CategoryId == model.categoryId.Value);
            }

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
            return await context.Incomes
                .Where(i => i.User.Username == username)
                .SumAsync(i => i.Amount);
        }
        public async Task<decimal> GetTotalExpenseAsync(string username)
        {
            return await context.Expenses
                .Where(e => e.User.Username == username)
                .SumAsync(e => e.Amount);
        }
    }
}
