using SignalRDemoChat.Domain.Entities;

namespace SignalRDemoChat.Domain.Dtos;

public class UserDto
{
    public long Id { get; set; }
    public string UserName { get; set; }

    public static explicit operator UserDto(User user)
    {
        return new UserDto() { Id = user.Id, UserName = user.UserName };
    }
}
