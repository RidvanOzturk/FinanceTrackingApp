using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations;

public class TransactionRepository(FinanceContext financeContext): ITransactionRepository
{
    public async Task<User?> GetByName(string name)
    {
        return await financeContext.Users
            .FirstOrDefaultAsync(x => x.Username == name);
    }
    public async Task CommitAsync()
    {
        await financeContext.SaveChangesAsync();
    }
    public async Task AddIncomeAsync(Income income)
    {
        await financeContext.Incomes.AddAsync(income);
    }
    public async Task AddExpenseAsync(Expense expense)
    {
        await financeContext.Expenses.AddAsync(expense);
    }
    public async Task GetByIdExpensesAsync(Guid id)
    {
        await financeContext.Expenses.FirstOrDefaultAsync(x =>x.Id == id);
    }
    public async Task GetByIdIncomesAsync(Guid id)
    {
        await financeContext.Incomes.FirstOrDefaultAsync(x => x.Id == id);
    }
}
