using SignalRDemoChat.Domain.Entities;

namespace SignalRDemoChat.Domain.Dtos;

public class RoomDto
{
    public long Id { get; set; }
    public string ConnectionId { get; set; }
    public string RoomName { get; set; }

    public static explicit operator RoomDto(Room room)
    {
        return new() { ConnectionId = room.ConnectionId, Id = room.Id, RoomName = room.RoomName };
    }
}
