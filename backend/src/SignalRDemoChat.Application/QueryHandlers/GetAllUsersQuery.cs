using MediatR;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Domain.Dtos;
using SignalRDemoChat.Domain.Models;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.QueryHandlers;

internal class GetAllUsersQuery : IRequestHandler<GetUsersRequest, ApiResponse>
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public GetAllUsersQuery(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<ApiResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = await _appUnitOfWork.Users.GetAllUsersAsync();

        return new()
        {
            IsSuccess = true,
            Data = users.Select(x => new UserDto { Id = x.Id, UserName = x.UserName }),
            Message = "Users List"
        };
    }
}
