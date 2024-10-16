﻿using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations;

public class UserRepository(FinanceContext financeContext) : IUserRepository
{
    public async Task Create(User user)
    {
        financeContext.Users.Add(user);
    }

    public async Task Delete(User user)
    {
        financeContext.Users.Remove(user);
    }

    public async Task<List<User>> GetAll()
    {
        return financeContext.Users.ToList();
    }

    public Task<User> GetById(int id)
    {
        //...
        throw new NotImplementedException();
    }

    public async Task<User?> GetByNameAsync(string name)
    {
        return await financeContext.Users
            .FirstOrDefaultAsync(x => x.Username == name);
    }

    public Task Update(User user)
    {
        //..
        throw new NotImplementedException();
    }

    public async Task CommitAsync()
    {
        await financeContext.SaveChangesAsync();
    }
}