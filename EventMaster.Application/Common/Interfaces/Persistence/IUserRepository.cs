using EventMaster.Domain.Users;

namespace EventMaster.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    Task<List<User>> LoadAsync();
    Task<User?> FetchAsync(int id);
    Task<User?> FetchByEmailAsync(string email);
    Task<User?> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}