namespace FinanceTrackingApp.Models.Responses
{
    public class DashboardViewResponseModel
    {
        public decimal TotalIncome { get; set; }
        public decimal TotalExpense { get; set; }
        public decimal Balance { get; set; }

        public float TotalIncomeFloat => (float)TotalIncome;
        public float TotalExpenseFloat => (float)TotalExpense;
        public float BalanceFloat => (float)Balance;
    }
}
