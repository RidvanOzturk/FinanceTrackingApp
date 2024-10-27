using DataLayer.DTOs;
using DataLayer.Entities;
using ServiceLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Extensions;

public static class MapperExtensions
{
    public static User UserMap(this RegisterRequestDTO registerRequest) 
    { 
        return new User
        {
            Id = Guid.NewGuid(),
            Username = registerRequest.username,
            Email = registerRequest.email,
            PasswordHash = registerRequest.password
        };
    }
    public static Income IncomeMap(this AddIncomeRequestDTO model, User user) 
    {
        return new Income
        {
            Id = Guid.NewGuid(),
            Amount = model.amount,
            Date = model.date,
            CategoryId = model.CategoryId,
            UserId = user.Id
        };
    }
    public static Expense ExpenseMap(this AddExpenseRequestDTO model, User user)
    {
        return new Expense
        {
            Id = Guid.NewGuid(),
            Amount = model.amount,
            Date = model.date,
            CategoryId = model.CategoryId,
            UserId = user.Id
        };
    }
    public static ReportFilterRepDTO ReportMap(this ReportFilterDTO model)
    {
        return new ReportFilterRepDTO
        {
            StartDate = model.startDate,
            EndDate = model.endDate,
            CategoryId = model.categoryId,
        };
    }
    public static ReportFilterRepDTO ReportQueryMap(this ReportFilterDTO model)
    {
        return new ReportFilterRepDTO
        {
            StartDate = model.startDate,
            EndDate = model.endDate,
            CategoryId = model.categoryId,
        };
    }
}
