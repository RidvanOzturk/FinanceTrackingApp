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
        var categories = await transactionService.GetCategoriesAsync();
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

        requestModel.Categories = await transactionService.GetCategoriesAsync();
        return View(requestModel);
    }




    [HttpPost("add-expense")]
    public IActionResult AddExpense(/*ExpenseModel model*/)
    {
        if (ModelState.IsValid)
        {
            // Gider ekleme işlemi
            return RedirectToAction("ListExpenses");
        }
        return View(/*model*/);
    }



}
