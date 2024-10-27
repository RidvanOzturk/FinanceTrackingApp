using DataLayer.Entities;

namespace DataLayer.Repositories.Contracts;

public interface ITransactionRepository
{
    Task<User?> GetByName(string name);
    Task<bool> CommitAsync();
    Task AddIncomeAsync(Income income);
    Task AddExpenseAsync(Expense expense);
    Task<Expense?> GetByIdExpensesAsync(Guid id);
    Task<Income?> GetByIdIncomesAsync(Guid id);
    Task RemoveIncomeAsync(Guid id);
    Task RemoveExpenseAsync(Guid id);
    Task<List<Category>> GetIncomeCategoriesAsync();
    Task<List<Category>> GetExpenseCategoriesAsync();
    Task<decimal> GetTotalIncomeAsync(string username);
    Task<decimal> GetTotalExpenseAsync(string username);
    Task<List<Income>> GetIncomeCategoryListAsync();
    Task<List<Expense>> GetExpenseCategoryListAsync();
}
