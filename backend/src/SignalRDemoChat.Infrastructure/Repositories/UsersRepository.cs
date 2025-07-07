using Microsoft.EntityFrameworkCore;
using SignalRDemoChat.Domain.Entities;
using SignalRDemoChat.Infrastructure.Contracts;
using SignalRDemoChat.Infrastructure.DbAccess;

namespace SignalRDemoChat.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly AppDbContext _appDbContext;

    public UsersRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateUserAsync(string userName)
    {
        User user = new User();

        user.UserName = userName;

        _appDbContext.Users.Add(user);  

        await _appDbContext.SaveChangesAsync(); 
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _appDbContext.Users.ToListAsync();
    }

    public async Task<bool> UserNameExistsAsync(string userName)
    {
        return await _appDbContext.Users.AnyAsync(x => x.UserName == userName);
    }
}
