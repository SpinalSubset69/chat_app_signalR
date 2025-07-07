using MediatR;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Domain.Entities;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.CommandHandlers;

internal class CreateMessageHandler : IRequestHandler<CreateMessageRequest, Unit>
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public CreateMessageHandler(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<Unit> Handle(CreateMessageRequest request, CancellationToken cancellationToken)
    {
        // Get Room Id
        var roomId = await _appUnitOfWork.Rooms.GetRoomIdByConnectionIdAsync(request.connectionId);

        // Room does not exists
        if (roomId == 0) throw new EntryPointNotFoundException(nameof(Room));

        // Save message
        await _appUnitOfWork.Messages.SaveMessageAsync(roomId, request.userId, request.text);

        // Return 'null'
        return Unit.Value;
    }
}
