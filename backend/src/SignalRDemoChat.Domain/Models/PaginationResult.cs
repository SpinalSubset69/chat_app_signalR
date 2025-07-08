namespace SignalRDemoChat.Domain.Models;

public class PaginationResult<T>
{
    public IEnumerable<T> Records { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public int TotalCount { get; set; }
}
