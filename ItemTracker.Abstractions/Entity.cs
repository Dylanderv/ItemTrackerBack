namespace ItemTracker.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; }
        public IList<IDomainEvent> DomainEvents { get; }

        protected Entity(Guid id)
        {
            this.Id = id;
            this.DomainEvents = new List<IDomainEvent>();
        }

        protected void StoreEvent(IDomainEvent domainEvent)
        {
            this.When(domainEvent);
            this.DomainEvents.Add(domainEvent);
        }

        public abstract void When(IDomainEvent domainEvent);
    }
}
