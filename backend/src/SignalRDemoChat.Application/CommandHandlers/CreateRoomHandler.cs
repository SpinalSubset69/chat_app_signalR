using MediatR;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Domain.Models;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.CommandHandlers;

public class CreateRoomHandler : IRequestHandler<CreateRoomRequest, string>
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public CreateRoomHandler(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<string> Handle(Domain.Requests.CreateRoomRequest request, CancellationToken cancellationToken)
    {
        var connectionId = Guid.NewGuid().ToString();

        await _appUnitOfWork.Rooms.CreateRoomAsync(connectionId, request.roomName, 69);

        return connectionId;
    }
}
