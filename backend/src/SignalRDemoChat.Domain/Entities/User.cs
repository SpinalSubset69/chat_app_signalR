using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRDemoChat.Domain.Entities;

[Table("users")]
public class User : BaseEntity
{
    [Column("username")]
    public string UserName { get; set; } = string.Empty;

    // Property for rooms
    public virtual ICollection<Room> Rooms { get; set; }    
}
