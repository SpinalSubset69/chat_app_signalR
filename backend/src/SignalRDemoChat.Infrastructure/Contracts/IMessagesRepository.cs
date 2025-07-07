namespace SignalRDemoChat.Infrastructure.Contracts;

public interface IMessagesRepository
{
    Task SaveMessageAsync(long roomId, long userId, string text);
}
