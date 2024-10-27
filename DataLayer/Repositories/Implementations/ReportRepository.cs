using DataLayer.DTOs;
using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Implementations;

public class ReportRepository(FinanceContext financeContext) : IReportRepository
{
    public IQueryable<Income> GetIncomeQuery(ReportFilterRepDTO model)
    {
       var incomeQuery = financeContext.Incomes
                .Where(i => i.Date >= model.StartDate && i.Date <= model.EndDate);

        if (model.CategoryId.HasValue)
        {
            incomeQuery = incomeQuery.Where(i => i.CategoryId == model.CategoryId.Value);
        }
        return incomeQuery;
    }
    public IQueryable<Expense> GetExpenseQuery(ReportFilterRepDTO model)
    {
        var expenseQuery = financeContext.Expenses
                .Where(e => e.Date >= model.StartDate && e.Date <= model.EndDate);
        if (model.CategoryId.HasValue)
        {
            expenseQuery = expenseQuery.Where(i => i.CategoryId == model.CategoryId.Value);
        }
        return expenseQuery;
    }
    public async Task<List<Category>> GetCategories()
    {
        return await financeContext.Categories.ToListAsync();
    }
    public async Task<decimal> GetTotalIncome(string username)
    {
        return await financeContext.Incomes
            .Where(i => i.User.Username == username)
            .SumAsync(i => i.Amount);
    }

    public async Task<decimal> GetTotalExpense(string username)
    {
        return await financeContext.Expenses
            .Where(e => e.User.Username == username)
            .SumAsync(e => e.Amount);
    }
}