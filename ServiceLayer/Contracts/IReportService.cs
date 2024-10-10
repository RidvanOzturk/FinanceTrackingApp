using DataLayer.Entities;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IReportService
    {
        Task<ReportingViewModel> GetReportAsync(ReportAsyncViewModel model);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<List<IncomeExpenseListViewModel>> GetReportDataAsync(ReportAsyncViewModel model);
        Task<decimal> GetTotalIncomeAsync(string username);
        Task<decimal> GetTotalExpenseAsync(string username);


    }
}
