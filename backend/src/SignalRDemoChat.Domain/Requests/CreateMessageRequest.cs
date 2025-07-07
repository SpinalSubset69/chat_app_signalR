using MediatR;

namespace SignalRDemoChat.Domain.Requests;

public record CreateMessageRequest(string connectionId, long userId, string text) : IRequest<Unit>;
