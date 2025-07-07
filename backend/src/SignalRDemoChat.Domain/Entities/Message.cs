using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRDemoChat.Domain.Entities;

[Table("messages")]
public class Message : BaseEntity
{
    [Column("room_id")]
    public long RoomId { get; set; }
    [Column("user_id")]
    public long UserId { get; set; }
    [Column("text")]
    public string Text { get; set; } = string.Empty;
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    // Navigation Properties    
    public virtual Room Room { get; set; }
}
