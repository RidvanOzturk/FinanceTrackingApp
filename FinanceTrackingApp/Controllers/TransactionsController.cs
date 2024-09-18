using Microsoft.AspNetCore.Mvc;

namespace FinanceTrackingApp.Controllers
{
    public class TransactionsController : Controller
    {
        [HttpPost("add")]
        public IActionResult AddTransaction(/*TransactionRequestModel model*/)
        {
            return View(/*model*/);
        }
        [HttpGet("list")]
        public IActionResult ListTransactions()
        {
            return RedirectToAction( "List" );
        }
        [HttpPut("update/{id}")]
        public IActionResult UpdateTransaction(/*Guid id, TransactionModel model*/)
        {
            return View();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteTransaction(Guid id)
        {
            return RedirectToAction("Delete", id);
        }


    }
}
