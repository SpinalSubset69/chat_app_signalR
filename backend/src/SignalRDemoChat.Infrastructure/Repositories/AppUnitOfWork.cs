namespace SignalRDemoChat.Infrastructure.Repositories;

public class AppUnitOfWork : IDisposable
{

    public void Dispose(bool isDisposing)
    {
        if (isDisposing) 
        {

        }
    }
    public void Dispose()
    {
        Dispose(true);

        GC.SuppressFinalize(this);
    }
}
