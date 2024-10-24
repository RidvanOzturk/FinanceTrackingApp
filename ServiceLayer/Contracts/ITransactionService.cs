﻿using DataLayer.Entities;
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
        Task<List<Category>> GetIncomeCategoriesAsync();
        Task<List<Category>> GetExpenseCategoriesAsync();
        Task<bool> AddExpenseAsync(AddExpenseRequestDTO model);
        Task<decimal> GetTotalIncomeAsync(string username);
        Task<decimal> GetTotalExpenseAsync(string username);
        Task<List<IncomeExpenseListModelDTO>> GetIncomeExpenseListAsync();
        Task DeleteInListAsync(Guid id);
    }
}
