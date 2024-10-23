using DataLayer.DTOs;
using DataLayer.Entities;

namespace DataLayer.Repositories.Contracts;

public interface IReportRepository
{
    IQueryable<Income> GetIncomeQuery(ReportFilterRepDTO model);
    IQueryable<Expense> GetExpenseQuery(ReportFilterRepDTO model);
    Task<List<Category>> GetCategories();
    Task<decimal> GetTotalIncome(string username);
    Task<decimal> GetTotalExpense(string username);
}
