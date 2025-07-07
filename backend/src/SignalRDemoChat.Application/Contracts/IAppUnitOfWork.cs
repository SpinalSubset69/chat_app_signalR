using SignalRDemoChat.Infrastructure.Contracts;

namespace SignalRDemoChat.Application.Contracts;

public interface IAppUnitOfWork
{
    public IRoomsRepository Rooms { get; }
    public IUsersRepository Users { get; }
    public IMessagesRepository Messages { get; }
}
