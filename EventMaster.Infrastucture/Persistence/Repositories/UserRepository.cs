using EventMaster.Application.Common.Interfaces.Persistence;
using EventMaster.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace EventMaster.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EventMasterDbContext _dbContext;

    public UserRepository(EventMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> LoadAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> FetchAsync(int id)
    {
        return await _dbContext.Users
        .Include(x => x.Reservations)
        .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> FetchByEmailAsync(string email)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User?> AddAsync(User user)
    {
        var createdUser = await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

}