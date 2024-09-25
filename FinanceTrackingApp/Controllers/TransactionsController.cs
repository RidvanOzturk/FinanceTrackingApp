using FinanceTrackingApp.Models.Requests;
using FinanceTrackingApp.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using ServiceLayer.Implementations;
namespace FinanceTrackingApp.Controllers;

[Route("transactions")]
public class TransactionsController(ITransactionService transactionService) : Controller
{
    [Authorize]
    [HttpGet("dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        ViewData["Title"] = "Income-Expense Dashboard";

        var username = User.Identity.Name;

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
    [Authorize]
    [HttpGet("income-expense-list")]
    public async Task<IActionResult> IncomeExpenseList()
    {
        var incomeExpenseList = await transactionService.GetIncomeExpenseListAsync();
        return View(incomeExpenseList);  
    }

    [HttpGet("report")]
    public IActionResult Reporting()
    {
        return View();
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
}
