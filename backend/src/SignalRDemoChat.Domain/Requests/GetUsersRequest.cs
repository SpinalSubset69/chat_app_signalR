using MediatR;
using SignalRDemoChat.Domain.Models;

namespace SignalRDemoChat.Domain.Requests;

public record GetUsersRequest() : IRequest<ApiResponse>;
