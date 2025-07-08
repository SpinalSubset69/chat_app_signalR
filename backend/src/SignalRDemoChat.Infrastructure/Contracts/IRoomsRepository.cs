using SignalRDemoChat.Domain.Entities;

namespace SignalRDemoChat.Infrastructure.Contracts;

public interface IRoomsRepository
{
    Task CreateRoomAsync(string connectionId, string? roomName, long userId);
    Task<bool> RoomExistsAsync(string connectionId);
    Task<long> GetRoomIdByConnectionIdAsync(string connectionId);
    Task<Room?> GetRoomByConnectionIdAsync(string connectionId);

    Task<IEnumerable<Room>> GetRoomsAsync(int take, int skip);

    Task<int> GetTotalRoomsAsync();
}
