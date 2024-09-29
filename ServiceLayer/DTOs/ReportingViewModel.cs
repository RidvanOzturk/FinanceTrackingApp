using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs;

    public class ReportingViewModel
    {

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid? CategoryId { get; set; } // Optional filter
    public decimal TotalIncome { get; set; }
    public decimal TotalExpense { get; set; }
    public decimal Balance { get; set; }

    public float TotalIncomeFloat => (float)TotalIncome;
    public float TotalExpenseFloat => (float)TotalExpense;
    public float BalanceFloat => (float)Balance;

    public List<SelectListItem> Categories { get; set; }
}
