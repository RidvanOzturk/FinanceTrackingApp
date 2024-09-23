namespace ServiceLayer.DTOs;

public class AddIncomeRequestDTO
{
    public string username { get; set; }
    public decimal amount {  get; set; }
    public Guid CategoryId { get; set; }
    public DateTime date { get; set; }
}
