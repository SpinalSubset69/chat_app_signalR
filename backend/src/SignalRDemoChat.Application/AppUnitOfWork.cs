using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Infrastructure.Contracts;
using SignalRDemoChat.Infrastructure.DbAccess;
using SignalRDemoChat.Infrastructure.Repositories;

namespace SignalRDemoChat.Application;

internal class AppUnitOfWork : IAppUnitOfWork, IDisposable
{
    private readonly AppDbContext _appDbContext;

    private IRoomsRepository? _rooms;
    private IUsersRepository? _users;
    private IMessagesRepository? _messages;

    public AppUnitOfWork(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IRoomsRepository Rooms
    {
        get
        {
            _rooms ??= new RoomsRepository(_appDbContext);

            return _rooms;
        }
    }

    public IUsersRepository Users
    {
        get
        {
            _users ??= new UsersRepository(_appDbContext);

            return _users;
        }
    }

    public IMessagesRepository Messages
    {
        get
        {
            _messages ??= new MessagesRepository(_appDbContext);

            return _messages;
        }
    }

    public void Dispose(bool isDisposing)
    {
        if (isDisposing)
        {
            if(_rooms is not null) GC.SuppressFinalize(_rooms);
            if (_users is not null) GC.SuppressFinalize(_users);
            if (_messages is not null) GC.SuppressFinalize(_messages);
        }
    }
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }
}

