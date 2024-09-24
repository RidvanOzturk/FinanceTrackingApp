using DataLayer.Entities;

namespace FinanceTrackingApp.Models.Requests
{
    public class AddExpenseRequestModel
    {
        public string username { get; set; }
        public decimal amount { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime date { get; set; }
        public List<Category> Categories { get; set; }
    }
}

