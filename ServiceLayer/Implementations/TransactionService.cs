using DataLayer;
using DataLayer.Entities;
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
    public class TransactionService(FinanceContext context) : ITransactionService
    {
        public async Task<bool> AddIncomeAsync(AddIncomeRequestDTO model)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == model.username);
            if (user == null)
            {
                return false; 
            }
            var income = new Income
            {
                Id = Guid.NewGuid(), 
                Amount = model.amount,     
                Date = model.date,
                CategoryId = model.CategoryId,
                UserId = user.Id     
            };
            await context.Incomes.AddAsync(income);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> AddExpenseAsync(AddExpenseRequestDTO model)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == model.username);
            if (user == null)
            {
                return false;
            }
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Amount = model.amount,
                Date = model.date,
                CategoryId = model.CategoryId,
                UserId = user.Id
            };
            await context.Expenses.AddAsync(expense);
            var result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<Category>> GetIncomeCategoriesAsync()
        {
            return await context.Categories
                .Where(c => c.Type == "Gelir")
                .ToListAsync();
        }

        public async Task<List<Category>> GetExpenseCategoriesAsync()
        {
            return await context.Categories
                .Where(c => c.Type == "Gider")
                .ToListAsync();
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
        public async Task<List<IncomeExpenseListViewDTO>> GetIncomeExpenseListAsync()
        {
            var incomeExpenseList = new List<IncomeExpenseListViewDTO>();

            var incomes = await context.Incomes
                .Include(i => i.Category)
                .ToListAsync();
            incomeExpenseList.AddRange(incomes.Select(i => new IncomeExpenseListViewDTO
            {
                Id = i.Id,
                CategoryName = i.Category.Name,
                Amount = i.Amount,
                Date = i.Date,
                Type = "Income"
            }));

            var expenses = await context.Expenses
                .Include(e => e.Category)
                .ToListAsync();
            incomeExpenseList.AddRange(expenses.Select(e => new IncomeExpenseListViewDTO
            {
                Id = e.Id,
                CategoryName = e.Category.Name,
                Amount = e.Amount,
                Date = e.Date,
                Type = "Expense"
            }));

            return incomeExpenseList;
        }

    }
}
