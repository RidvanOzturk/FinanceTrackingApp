using DataLayer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Contracts;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class ReportService(FinanceContext context) : IReportService
    {
        //SORULACAK
        public async Task<ReportingViewDTO> GetReportAsync(DateTime startDate, DateTime endDate, Guid? categoryId)
        {
            var query = context.Incomes
                .Where(i => i.Date >= startDate && i.Date <= endDate);
                
            if (categoryId.HasValue)
            {
                query = query.Where(i => i.CategoryId == categoryId.Value);
            }

            var totalIncome = await query.SumAsync(i => i.Amount);

            var expenseQuery = context.Expenses
                .Where(e => e.Date >= startDate && e.Date <= endDate)
                .AsQueryable();

            if (categoryId.HasValue)
            {
                expenseQuery = expenseQuery.Where(e => e.CategoryId == categoryId.Value);
            }

            var totalExpense = await expenseQuery.SumAsync(e => e.Amount);

            return new ReportingViewDTO
            {
                StartDate = startDate,
                EndDate = endDate,
                CategoryId = categoryId,
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense,
                Categories = await context.Categories
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    })
                    .ToListAsync()
            };
        }
    }
}
