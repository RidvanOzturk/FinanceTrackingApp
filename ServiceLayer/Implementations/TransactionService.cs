using DataLayer;
using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations;

public class TransactionService(ITransactionRepository transactionRepository) : ITransactionService
{
    public async Task<bool> AddIncomeAsync(AddIncomeRequestDTO model)
    {
        var user = await transactionRepository.GetByName(model.username);
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
        await transactionRepository.AddIncomeAsync(income);
        var result =  transactionRepository.CommitAsync();
        return result != null;
    }

    public async Task<bool> AddExpenseAsync(AddExpenseRequestDTO model)
    {
        var user = transactionRepository.GetByName(model.username);
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
        await transactionRepository.AddExpenseAsync(expense);
        var result = transactionRepository.CommitAsync();
        return result != null;
    }
    public async Task DeleteInListAsync(Guid id)
    {
        var deletedExpense = transactionRepository.GetByIdExpensesAsync(id);
        var deletedIncome = transactionRepository.GetByIdIncomesAsync(id);

        if (deletedExpense != null)
        {
            context.Expenses.Remove(deletedExpense);
            await context.SaveChangesAsync();
        }
        if (deletedIncome != null)
        {
            context.Incomes.Remove(deletedIncome);
            await context.SaveChangesAsync();
        }
    }
    public async Task<List<Category>> GetIncomeCategoriesAsync()
    {
        return await context.Categories
            .Where(c => c.Type == "Income")
            .ToListAsync();
    }

    public async Task<List<Category>> GetExpenseCategoriesAsync()
    {
        return await context.Categories
            .Where(c => c.Type == "Expense")
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
    public async Task<List<IncomeExpenseListViewModel>> GetIncomeExpenseListAsync()
    {
        var incomeExpenseList = new List<IncomeExpenseListViewModel>();

        var incomes = await context.Incomes
            .Include(i => i.Category)
            .ToListAsync();

        incomeExpenseList.AddRange(incomes.Select(i => new IncomeExpenseListViewModel
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

        incomeExpenseList.AddRange(expenses.Select(e => new IncomeExpenseListViewModel
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
