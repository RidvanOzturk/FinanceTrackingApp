﻿using DataLayer.Entities;
using FinanceTrackingApp.Models.Requests;
using FinanceTrackingApp.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using ServiceLayer.Implementations;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace FinanceTrackingApp.Controllers;

[Route("transactions")]
public class TransactionsController(ITransactionService transactionService) : Controller
{
    [Authorize]
    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        ViewData["Title"] = "Income-Expense Dashboard";

        var username = User.Identity?.Name;
        if (string.IsNullOrEmpty(username))
        {
            return RedirectToAction("Login", "Auth");
        }

        var totalIncome = await transactionService.GetTotalIncomeAsync(username);
        var totalExpense = await transactionService.GetTotalExpenseAsync(username);

        var balance = totalIncome - totalExpense;

        var model = new DashboardViewResponseModel
        {
            TotalIncome = totalIncome,
            TotalExpense = totalExpense,
            Balance = balance
        };

        return View(model);
    }
    [Authorize]
    [HttpGet("add-income")]
    public async Task<IActionResult> AddIncome()
    {
        var categories = await transactionService.GetIncomeCategoriesAsync();
        var model = new AddIncomeRequestModel
        {
            Categories = categories
        };
        return View(model); 
    }

    [HttpPost("add-income")]
    public async Task<IActionResult> AddIncome(AddIncomeRequestModel requestModel)
    {
        if (ModelState.IsValid)
        {
            var requestDTO = ConstructAddIncomeDTO(requestModel);

            var result = await transactionService.AddIncomeAsync(requestDTO);
            if (result)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Error while adding income");
                return View(requestModel);
            }
        }

        requestModel.Categories = await transactionService.GetIncomeCategoriesAsync();
        return View(requestModel);
    }

    [Authorize]
    [HttpGet("add-expense")]
    public async Task<IActionResult> AddExpense()
    {
        var categories = await transactionService.GetExpenseCategoriesAsync();
        var model = new AddExpenseRequestModel
        {
            Categories = categories
        };
        return View(model);
    }


    [HttpPost("add-expense")]
    public async Task<IActionResult> AddExpense(AddExpenseRequestModel requestModel)
    {
        if (ModelState.IsValid)
        {
            var requestDTO = ConstructAddExpenseDTO(requestModel);
            var result = await transactionService.AddExpenseAsync(requestDTO);
            if (result)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Error while adding income");
                return View(requestModel);
            }
        }

        requestModel.Categories = await transactionService.GetExpenseCategoriesAsync();
        return View(requestModel);
    }
    [Authorize]
    [HttpGet("income-expense-list")]
    public async Task<IActionResult> IncomeExpenseList()
    {
        var incomeExpenseList = await transactionService.GetIncomeExpenseListAsync();
        return View(incomeExpenseList);  
    }

    [HttpGet("delete/{id:guid}")]
    public async Task<IActionResult> DeleteDataInList(Guid id)
    {
        await transactionService.DeleteInListAsync(id);
        return RedirectToAction("IncomeExpenseList");
    }

    private AddIncomeRequestDTO ConstructAddIncomeDTO(AddIncomeRequestModel value)
    {
        //Mapping
        return new AddIncomeRequestDTO
        {
            username = User.Identity.Name,
            amount = value.amount,
            CategoryId = value.CategoryId,
            date = value.date
        };
    }
    private AddExpenseRequestDTO ConstructAddExpenseDTO(AddExpenseRequestModel value) 
    {
        return new AddExpenseRequestDTO
        {
            username = User.Identity.Name,
            amount = value.amount,
            CategoryId = value.CategoryId,
            date = value.date
        };
    }
}
