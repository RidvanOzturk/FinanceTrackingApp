using DataLayer.Entities;

public class Income
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public Guid CategoryId { get; set; }  

    public Category Category { get; set; }  

    public Guid UserId { get; set; }
    public User User { get; set; }
}
