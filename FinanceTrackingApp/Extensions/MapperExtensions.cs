using FinanceTrackingApp.Models.Requests;
using ServiceLayer.DTOs;

namespace FinanceTrackingApp.Extensions;

public static class MapperExtensions
{
    public static ReportAsyncViewModel Map(this GenerateReportRequestModel model)
    {
        return new ReportAsyncViewModel
        {
            startDate = model.startDate,
            endDate = model.endDate,
            categoryId = model.categoryId
        };
    }
}

//public static class MapperExtensions
//{
//    public static ReportAsyncViewModel Map(GenerateReportRequestModel model)
//    {
//        return new ReportAsyncViewModel
//        {
//            startDate = model.startDate,
//            endDate = model.endDate,
//            categoryId = model.categoryId
//        };
//    }
//}