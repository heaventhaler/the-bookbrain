public class NotFoundException : Exception
{
    public string? EntityName { get; }
    public object? Id { get; }

    public NotFoundException(string entityName, object id) 
        : base($"{entityName} with ID {id} not found")
    {
        EntityName = entityName;
        Id = id;
    }

    public NotFoundException(string message) : base(message) { }
}