using SignalRDemoChat.Domain.Entities;

namespace SignalRDemoChat.Infrastructure.Contracts;

public interface IUsersRepository
{
    public Task CreateUserAsync(string userName);
    public Task<bool> UserNameExistsAsync(string userName);

    public Task<IEnumerable<User>> GetAllUsersAsync();
}
