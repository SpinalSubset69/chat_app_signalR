
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRDemoChat.Domain.Entities;

public class Room : BaseEntity
{
    [Column("connection_id")]
    public string ConnectionId { get; set; }

    [Column("room_name")]
    public string? RoomName { get; set; }

    // Navigation property
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Message> Messages { get; set; }
}
