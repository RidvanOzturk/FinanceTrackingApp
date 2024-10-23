namespace ServiceLayer.DTOs;

public class ReportFilterDTO
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }

    public Guid? categoryId { get; set; }
}
