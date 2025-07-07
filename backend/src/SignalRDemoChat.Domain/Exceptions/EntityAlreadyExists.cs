namespace SignalRDemoChat.Domain.Exceptions;

public class EntityAlreadyExists : Exception
{
    public EntityAlreadyExists(string entity)
        : base($"{entity} already exists!")
    {
        
    }
}
