namespace DataLayer.DTOs
{
    public class ReportFilterRepDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
