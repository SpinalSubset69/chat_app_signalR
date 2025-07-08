using MediatR;
using SignalRDemoChat.Domain.Models;

namespace SignalRDemoChat.Domain.Requests;

public record CreateUserRequest(string userName, string password) : IRequest<ApiResponse>;
