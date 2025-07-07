using MediatR;
using SignalRDemoChat.Domain.Models;

namespace SignalRDemoChat.Domain.Requests;

public record CreateRoomRequest(string roomName) : IRequest<string>;
