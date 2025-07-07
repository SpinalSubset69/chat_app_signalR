using MediatR;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Domain.Dtos;
using SignalRDemoChat.Domain.Exceptions;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.CommandHandlers;

internal class GetRoomByConnectionIdHandler : IRequestHandler<GetRoomByConnectionIdRequest, RoomDto>
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public GetRoomByConnectionIdHandler(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<RoomDto> Handle(GetRoomByConnectionIdRequest request, CancellationToken cancellationToken)
    {
        var room = await _appUnitOfWork.Rooms.GetRoomByConnectionIdAsync(request.connectionId);

        if (room is null) throw new EntityNotFound(nameof(room));

        return (RoomDto)room;
    }
}
