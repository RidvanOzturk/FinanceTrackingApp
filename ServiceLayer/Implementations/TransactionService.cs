﻿using DataLayer;
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
using ServiceLayer.Extensions;

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

        var income = model.IncomeMap(user);

        await transactionRepository.AddIncomeAsync(income);
        await transactionRepository.CommitAsync();  
        return true;
    }
    public async Task<bool> AddExpenseAsync(AddExpenseRequestDTO model)
    {
        var user = await transactionRepository.GetByName(model.username);
        if (user == null)
        {
            return false;
        }

        var expense = model.ExpenseMap(user);

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
        }
        if (deletedIncome != null)
        {
            await transactionRepository.RemoveIncomeAsync(id);
        }
        await transactionRepository.CommitAsync();
    }
    public async Task<List<Category>> GetIncomeCategoriesAsync()
    {
        return await transactionRepository.GetIncomeCategoriesAsync();
    }

    public async Task<List<Category>> GetExpenseCategoriesAsync()
    {
        return await transactionRepository.GetExpenseCategoriesAsync();
    }
    public async Task<decimal> GetTotalIncomeAsync(string username)
    {
        return await transactionRepository.GetTotalIncomeAsync(username);
    }
    public async Task<decimal> GetTotalExpenseAsync(string username)
    {
        return await transactionRepository.GetTotalExpenseAsync(username);
    }
    public async Task<List<IncomeExpenseListModelDTO>> GetIncomeExpenseListAsync()
    {
        var incomeExpenseList = new List<IncomeExpenseListModelDTO>();

        var incomes = await transactionRepository.GetIncomeCategoryListAsync();

        incomeExpenseList.AddRange(incomes.Select(i => new IncomeExpenseListModelDTO
        {
            Id = i.Id,
            CategoryName = i.Category.Name,
            Amount = i.Amount,
            Date = i.Date,
            Type = "Income"
        }));


        var expenses = await transactionRepository.GetExpenseCategoryListAsync();

        incomeExpenseList.AddRange(expenses.Select(e => new IncomeExpenseListModelDTO
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
