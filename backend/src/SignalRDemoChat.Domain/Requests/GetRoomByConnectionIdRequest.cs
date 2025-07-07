using MediatR;
using SignalRDemoChat.Domain.Dtos;

namespace SignalRDemoChat.Domain.Requests;

public record GetRoomByConnectionIdRequest(string connectionId) : IRequest<RoomDto>;
