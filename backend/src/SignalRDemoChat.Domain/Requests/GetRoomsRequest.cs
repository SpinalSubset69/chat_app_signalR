using MediatR;
using SignalRDemoChat.Domain.Dtos;
using SignalRDemoChat.Domain.Models;

namespace SignalRDemoChat.Domain.Requests;

public record GetRoomsRequest(int page, int take) : IRequest<PaginationResult<RoomDto>>;
