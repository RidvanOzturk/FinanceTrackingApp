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
    public IActionResult AddIncome()
    {
        return View();
    }

    [HttpPost("add-income")]
    public async Task<IActionResult> AddIncome(AddIncomeRequestModel requestModel)
    {
        
        if (ModelState.IsValid)
        {
            var username = HttpContext.User.Identity.Name;
            var requestDTO = new AddIncomeRequestDTO
            {
                username = requestModel.username,
                amount = requestModel.amount,
                CategoryId = requestModel.CategoryId, 
                date = requestModel.date,
            };
            var result = await transactionService.AddIncomeAsync(requestDTO);
            if (result)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "User already exists");
                return View(requestModel);
            }
        }
        return View();
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
