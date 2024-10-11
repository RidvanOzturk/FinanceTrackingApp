namespace FinanceTrackingApp.Models.Requests
{
    public class GenerateReportRequestModel
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Guid? categoryId { get; set; }
        public string reportType { get; set; }
    }
}
