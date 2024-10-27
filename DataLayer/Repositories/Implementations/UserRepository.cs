using DataLayer.Entities;
using DataLayer.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataLayer.Repositories.Implementations;

public class UserRepository(FinanceContext financeContext) : IUserRepository
{
    public async Task Create(User? user)
    {
        financeContext.Users.AddAsync(user);
    }
    public async Task<User?> GetByNameandEmailAsync(string name, string mail)
    {
        return await financeContext.Users
            .FirstOrDefaultAsync(x => x.Username == name || x.Email == mail);
    }
    public async Task<bool> CommitAsync()
    {
        var changes = await financeContext.SaveChangesAsync();
        return changes > 0;
    }
}
