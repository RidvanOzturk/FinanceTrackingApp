using FinanceTrackingApp.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
namespace FinanceTrackingApp.Controllers;

[Route("transactions")]
public class TransactionsController(ITransactionService transactionService) : Controller
{
    [HttpGet("dashboard")]
    public IActionResult Dashboard()
    {
        ViewData["Title"] = "Income-Expense Dashboard";
        return View();
    }

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
            var requestDTO = new AddIncomeRequestDTO
            {
                username = User.Identity.Name, 
                amount = requestModel.amount,
                CategoryId = requestModel.CategoryId,
                date = requestModel.date
            };

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
            var requestDTO = new AddExpenseRequestDTO
            {
                username = User.Identity.Name,
                amount = requestModel.amount,
                CategoryId = requestModel.CategoryId,
                date = requestModel.date
            };

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



}
