using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories.Implementations;

public class TransactionRepository(FinanceContext financeContext): ITransactionRepository
{
    public async Task<User?> GetByName(string name)
    {
        return await financeContext.Users
            .FirstOrDefaultAsync(x => x.Username == name);
    }
    public async Task<bool> CommitAsync()
    {
        var changes = await financeContext.SaveChangesAsync();
        return changes > 0;
    }
    public async Task AddIncomeAsync(Income income)
    {
        await financeContext.Incomes.AddAsync(income);
    }
    public async Task AddExpenseAsync(Expense expense)
    {
        await financeContext.Expenses.AddAsync(expense);
    }
    public async Task<Expense?> GetByIdExpensesAsync(Guid id)
    {
        return await financeContext.Expenses.FirstOrDefaultAsync(x =>x.Id == id);
    }
    public async Task<Income?> GetByIdIncomesAsync(Guid id)
    {
        return await financeContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task RemoveIncomeAsync(Guid id)
    {
        Income? income = await GetByIdIncomesAsync(id);
        if (income != null)
        {
            financeContext.Incomes.Remove(income);
        }
    }
    public async Task RemoveExpenseAsync(Guid id)
    {
        Expense? expense = await GetByIdExpensesAsync(id);
        if (expense != null)
        {
            financeContext.Expenses.Remove(expense);
        }
    }
    public async Task<List<Category>> GetIncomeCategoriesAsync()
    {
       return await financeContext.Categories
            .Where(c => c.Type == "Income")
            .ToListAsync();
    }
    public async Task<List<Category>> GetExpenseCategoriesAsync()
    {
        return await financeContext.Categories
             .Where(c => c.Type == "Expense")
             .ToListAsync();
    }
    public async Task<decimal> GetTotalIncomeAsync(string username)
    {
       return await financeContext.Incomes
            .Where(i => i.User.Username == username)
            .SumAsync(i => i.Amount);
    }
    public async Task<decimal> GetTotalExpenseAsync(string username)
    {
        return await financeContext.Expenses
             .Where(i => i.User.Username == username)
             .SumAsync(i => i.Amount);
    }
    public async Task<List<Income>> GetIncomeCategoryListAsync()
    {
        return await financeContext.Incomes
            .Include(i => i.Category)
            .ToListAsync();
    }
    public async Task<List<Expense>> GetExpenseCategoryListAsync()
    {
        return await financeContext.Expenses
            .Include(i => i.Category)
            .ToListAsync();
    }
}
