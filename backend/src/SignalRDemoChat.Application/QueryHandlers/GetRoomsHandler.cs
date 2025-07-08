using MediatR;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Domain.Dtos;
using SignalRDemoChat.Domain.Models;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.QueryHandlers;

internal class GetRoomsHandler : IRequestHandler<GetRoomsRequest, PaginationResult<RoomDto>>
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public GetRoomsHandler(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<PaginationResult<RoomDto>> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {        
        var skip = (request.page - 1) * request.take;

        var roomsTotalCount = await _appUnitOfWork.Rooms.GetTotalRoomsAsync();
        var rooms = await _appUnitOfWork.Rooms.GetRoomsAsync(request.take, skip);        

        return new PaginationResult<RoomDto>()
        {
            TotalCount = roomsTotalCount,
            Records = rooms.Select(x => (RoomDto)x),
            Page = request.page,
            TotalPages = (int)Math.Round(Convert.ToDecimal(roomsTotalCount / request.take))
        };
    }
}
