using DataLayer;
using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using DataLayer.Repositories.Implementations;
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
        if (user == null) return false;

        var income = new Income
        {
            Id = Guid.NewGuid(),
            Amount = model.amount,
            Date = model.date,
            CategoryId = model.CategoryId,
            UserId = user.Id
        };

        await transactionRepository.AddIncomeAsync(income);
        await transactionRepository.CommitAsync();  
        return true;
    }
    public async Task<bool> AddExpenseAsync(AddExpenseRequestDTO model)
    {
        var user = await transactionRepository.GetByName(model.username);
        if (user == null) return false;

        var expense = new Expense
        {
            Id = Guid.NewGuid(),
            Amount = model.amount,
            Date = model.date,
            CategoryId = model.CategoryId,
            UserId = user.Id
        };

        await transactionRepository.AddExpenseAsync(expense);
        await transactionRepository.CommitAsync();
        return true;
    }
    public async Task DeleteInListAsync(Guid id)
    {
        var deletedExpense = await transactionRepository.GetByIdExpensesAsync(id);
        var deletedIncome = await transactionRepository.GetByIdIncomesAsync(id);

        if (deletedExpense != null)
        {
            await transactionRepository.RemoveExpenseAsync(id);
            await transactionRepository.CommitAsync();  
        }
        if (deletedIncome != null)
        {
            await transactionRepository.RemoveIncomeAsync(id);
            await transactionRepository.CommitAsync(); 
        }
    }
    public async Task<List<SelectListItem>> GetIncomeCategoriesAsync()
    {
        var categories = await transactionRepository.GetIncomeCategoriesAsync();
        return categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
    }

    public async Task<List<SelectListItem>> GetExpenseCategoriesAsync()
    {
        var categories = await transactionRepository.GetExpenseCategoriesAsync();
        return categories.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
    }
    public async Task GetTotalIncomeAsync(string username)
    {
        await transactionRepository.GetTotalIncomeAsync(username);
    }
    public async Task GetTotalExpenseAsync(string username)
    {
        await transactionRepository.GetTotalExpenseAsync(username);
    }
    public async Task<List<IncomeExpenseListViewModel>> GetIncomeExpenseListAsync()
    {
        var incomeExpenseList = new List<IncomeExpenseListViewModel>();

        var incomes = await transactionRepository.GetIncomeCategoryListAsync();

        incomeExpenseList.AddRange(incomes.Select(i => new IncomeExpenseListViewModel
        {
            Id = i.Id,
            CategoryName = i.Category.Name,
            Amount = i.Amount,
            Date = i.Date,
            Type = "Income"
        }));


        var expenses = await transactionRepository.GetExpenseCategoryListAsync();

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
