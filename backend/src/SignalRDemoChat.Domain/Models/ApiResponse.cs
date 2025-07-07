namespace SignalRDemoChat.Domain.Models;

public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public object? Data { get; set; }
    public  string Message { get; set; } = string.Empty;    
}
