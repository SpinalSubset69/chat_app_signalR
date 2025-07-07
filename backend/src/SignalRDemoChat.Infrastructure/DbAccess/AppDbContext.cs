using Microsoft.EntityFrameworkCore;
using SignalRDemoChat.Domain.Entities;

namespace SignalRDemoChat.Infrastructure.DbAccess;

public class AppDbContext : DbContext
{

    public virtual DbSet<Room> Rooms {  get; set; }
    public virtual DbSet<Message> Messages { get; set; }
    public virtual DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Room Relation with messages
        modelBuilder.Entity<Room>()
            .HasMany(e => e.Messages)
            .WithOne(e => e.Room)
            .HasForeignKey(e => e.RoomId)
            .HasPrincipalKey(e => e.Id);

        // Room Relation with users
        modelBuilder.Entity<Room>()
            .HasMany(e => e.Users)
            .WithMany(e => e.Rooms)
            .UsingEntity(j => j.ToTable("UserRooms"));                    
    }
}
