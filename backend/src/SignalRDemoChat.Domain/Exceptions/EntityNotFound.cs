namespace SignalRDemoChat.Domain.Exceptions;

public class EntityNotFound : Exception
{
    public EntityNotFound(string entityName)
        : base($"Entity: {entityName}, not found!")
    {
        
    }
}
