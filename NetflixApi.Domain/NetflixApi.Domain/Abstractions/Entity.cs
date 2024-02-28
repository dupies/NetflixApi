namespace NetflixApi.Domain.Abstractions;

public class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public Entity()
    {
        Id = 0;
    }
    public Entity(int id)
    {
        Id = id;
    }
    public int Id { get; set; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
