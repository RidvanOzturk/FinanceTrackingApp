using FinanceTrackingApp.Models.Requests;
using ServiceLayer.DTOs;

namespace FinanceTrackingApp.Extensions;

public static class MapperExtensions
{
    public static ReportFilterDTO ReportMap(this GenerateReportRequestModel model)
    {
        return new ReportFilterDTO
        {
            startDate = model.startDate,
            endDate = model.endDate,
            categoryId = model.categoryId
        };
    }
    public static AddIncomeRequestDTO IncomeMap(this AddIncomeRequestModel model, string username)
    {
        return new AddIncomeRequestDTO
        {
            username = username,
            amount = model.amount,
            CategoryId = model.CategoryId,
            date = model.date
        };
    }
    public static AddExpenseRequestDTO ExpenseMap(this AddExpenseRequestModel model, string username)
    {
        return new AddExpenseRequestDTO
        {
            username = username,
            amount = model.amount,
            CategoryId = model.CategoryId,
            date = model.date
        };
    }
    public static RegisterRequestDTO RegisterMap(this RegisterRequestModel requestModel)
    {
        return new RegisterRequestDTO
        {
            username = requestModel.username,
            email = requestModel.mail,
            password = requestModel.password
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