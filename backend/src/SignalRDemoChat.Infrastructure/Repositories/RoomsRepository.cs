using Microsoft.EntityFrameworkCore;
using SignalRDemoChat.Domain.Entities;
using SignalRDemoChat.Infrastructure.Contracts;
using SignalRDemoChat.Infrastructure.DbAccess;

namespace SignalRDemoChat.Infrastructure.Repositories;

public class RoomsRepository : IRoomsRepository
{
    private readonly AppDbContext _appDbContext;

    public RoomsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task CreateRoomAsync(string connectionId, string? roomName, long userId)
    {
        Room room = new Room();

        room.ConnectionId = connectionId;   
        room.RoomName = roomName;        

        _appDbContext.Rooms.Add(room);

        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Room?> GetRoomByConnectionIdAsync(string connectionId)
    {
        return await _appDbContext.Rooms.FirstOrDefaultAsync(x => x.ConnectionId == connectionId);
    }

    public async Task<long> GetRoomIdByConnectionIdAsync(string connectionId)
    {
        var room = await _appDbContext.Rooms.FirstOrDefaultAsync(x => x.ConnectionId == connectionId);
        
        if(room is null) return 0;

        return room.Id;
    }

    public async Task<bool> RoomExistsAsync(string connectionId)
    {
        return await _appDbContext.Rooms.AnyAsync(x => x.ConnectionId == connectionId);
    }
}
