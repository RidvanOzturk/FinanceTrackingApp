using DataLayer.Entities;

namespace FinanceTrackingApp.Models.Requests;

public class AddIncomeRequestModel
{
    public string username { get; set; }
    public decimal amount { get; set; }
    public int CategoryId { get; set; }
    public DateTime date { get; set; }
}
