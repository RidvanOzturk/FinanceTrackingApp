using DataLayer.Entities;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface ITransactionService
    {
        Task<bool> AddIncomeAsync(AddIncomeRequestDTO model);
        Task GetIncomeCategoriesAsync();
        Task GetExpenseCategoriesAsync();
        Task<bool> AddExpenseAsync(AddExpenseRequestDTO model);
        Task<decimal> GetTotalIncomeAsync(string username);
        Task<decimal> GetTotalExpenseAsync(string username);
        Task<List<IncomeExpenseListViewModel>> GetIncomeExpenseListAsync();
        Task DeleteInListAsync(Guid id);
    }
}
