using MediatR;
using Microsoft.AspNetCore.SignalR;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.Hubs;

public class ChatHub : Hub
{
    private readonly ISender _sender;

    public ChatHub(ISender sender)
    {
        _sender = sender;
    }

    public async Task RoomCreated(string connectionId)
    {        
        var room = await _sender.Send(new GetRoomByConnectionIdRequest(connectionId));

        await Clients.All.SendAsync("RoomCreated", room);
    }

    public async Task JoinRoom(string connectionId, string UserName)
    {        
        await Groups.AddToGroupAsync(Context.ConnectionId, connectionId);
        await Clients.Group(connectionId).SendAsync("NewUser", $"{UserName} joined the chat");
    }

    public async Task LeaveRoom(string connectionId, string UserName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, connectionId);
        await Clients.Group(connectionId).SendAsync("NewUser", $"{UserName} leaved the chat");
    }
}
