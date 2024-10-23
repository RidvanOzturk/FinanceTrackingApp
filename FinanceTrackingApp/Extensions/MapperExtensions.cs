using FinanceTrackingApp.Models.Requests;
using ServiceLayer.DTOs;

namespace FinanceTrackingApp.Extensions;

public static class MapperExtensions
{
    public static ReportFilterDTO Map(this GenerateReportRequestModel model)
    {
        return new ReportFilterDTO
        {
            startDate = model.startDate,
            endDate = model.endDate,
            categoryId = model.categoryId
        };
    }
}

//public static class MapperExtensions
//{
//    public static ReportFilterDTO Map(GenerateReportRequestModel model)
//    {
//        return new ReportFilterDTO
//        {
//            startDate = model.startDate,
//            endDate = model.endDate,
//            categoryId = model.categoryId
//        };
//    }
//}