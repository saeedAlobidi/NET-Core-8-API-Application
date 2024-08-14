namespace CRM.Domain.Common;

public abstract class Entity<T>
{

    public T Id { get; set; }
    protected readonly List<IDomainEvent> _domainEvents = [];
    protected Entity(T Id) => this.Id = Id;

    protected Entity() { }
    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();
        _domainEvents.Clear();

        return copy;
    }


    public override bool Equals(object? obj)
    {
        return (obj!=null && this.GetType == obj.GetType && ((Entity<T>)obj).Id.Equals(Id));
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
