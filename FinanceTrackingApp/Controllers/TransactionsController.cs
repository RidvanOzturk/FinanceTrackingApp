using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Contracts;
namespace FinanceTrackingApp.Controllers
{
    public class TransactionsController(ITransactionService transactionService) : Controller
    {
        

        [HttpPost("add-income")]
        public IActionResult AddIncome(/*IncomeModel model*/)
        {
            if (ModelState.IsValid)
            {
                // Gelir ekleme işlemi
                return RedirectToAction("ListIncomes");
            }
            return View(/*model*/);
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
}
