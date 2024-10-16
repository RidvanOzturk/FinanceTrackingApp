using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Contracts;

public interface ITransactionRepository
{
    Task<User?> GetByName(string name);
    Task CommitAsync();
    Task AddIncomeAsync(Income income);
    Task AddExpenseAsync(Expense expense);
    Task GetByIdExpensesAsync(Guid id);
    Task GetByIdIncomesAsync(Guid id);
}
