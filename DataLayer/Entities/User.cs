namespace DataLayer.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public ICollection<Income> IncomeList { get; set; }
        public ICollection<Expense> ExpenseList { get; set; }
    }
}
