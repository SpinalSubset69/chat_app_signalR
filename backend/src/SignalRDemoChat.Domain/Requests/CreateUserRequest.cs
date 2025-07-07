using MediatR;
using SignalRDemoChat.Domain.Models;

namespace SignalRDemoChat.Domain.Requests;

public record CreateUserRequest(string userName) : IRequest<ApiResponse>;
