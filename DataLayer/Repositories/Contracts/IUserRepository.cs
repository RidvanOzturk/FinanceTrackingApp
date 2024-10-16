using DataLayer.Entities;

namespace DataLayer.Repositories.Contracts;

public interface IUserRepository
{
    Task Create(User user);
    Task Update(User user);
    Task Delete(User user);
    Task<User> GetById(int id);
    Task<List<User>> GetAll();
    Task<User?> GetByNameandEmailAsync(string name, string mail);

    Task CommitAsync();
}
