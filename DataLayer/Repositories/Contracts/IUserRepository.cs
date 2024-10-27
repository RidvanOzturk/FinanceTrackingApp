using DataLayer.Entities;

namespace DataLayer.Repositories.Contracts;

public interface IUserRepository
{
    Task Create(User user);
    Task<User?> GetByNameandEmailAsync(string name, string mail);
    Task<bool> CommitAsync();
}
