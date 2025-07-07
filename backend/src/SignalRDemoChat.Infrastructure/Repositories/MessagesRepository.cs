using SignalRDemoChat.Domain.Entities;
using SignalRDemoChat.Infrastructure.Contracts;
using SignalRDemoChat.Infrastructure.DbAccess;

namespace SignalRDemoChat.Infrastructure.Repositories;

public class MessagesRepository : IMessagesRepository
{
    private readonly AppDbContext _appDbContext;

    public MessagesRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task SaveMessageAsync(long roomId, long userId, string text)
    {
        Message message = new Message();

        message.Text = text;
        message.UserId = userId;
        message.RoomId = roomId;

        _appDbContext.Messages.Add(message);

        await _appDbContext.SaveChangesAsync();
    }
}
