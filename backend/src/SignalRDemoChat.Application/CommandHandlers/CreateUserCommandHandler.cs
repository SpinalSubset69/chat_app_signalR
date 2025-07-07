using MediatR;
using SignalRDemoChat.Application.Contracts;
using SignalRDemoChat.Domain.Entities;
using SignalRDemoChat.Domain.Exceptions;
using SignalRDemoChat.Domain.Models;
using SignalRDemoChat.Domain.Requests;

namespace SignalRDemoChat.Application.CommandHandlers;

internal class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, ApiResponse>
{
    private readonly IAppUnitOfWork _appUnitOfWork;

    public CreateUserCommandHandler(IAppUnitOfWork appUnitOfWork)
    {
        _appUnitOfWork = appUnitOfWork;
    }

    public async Task<ApiResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var userNameExists = await _appUnitOfWork.Users.UserNameExistsAsync(request.userName);
        if (userNameExists) throw new EntityAlreadyExists(nameof(User));
        await _appUnitOfWork.Users.CreateUserAsync(request.userName);

        return new()
        {
            IsSuccess = true,
            Message = "User Created Succesfully"
        };
    }
}
