using ItemTracker.Abstractions;
using ItemTracker.Database;
using ItemTracker.Extensions;

namespace ItemTracker.Infrastucture
{
    public class EntityStore : IEntityStore
    {
        private readonly IEventStore store;

        public EntityStore(IEventStore eventStore)
        {
            this.store = eventStore;
        }

        public async Task<T> Load<T>(Guid Id) where T : Entity, new()
        {
            IReadOnlyCollection<IDomainEvent> domainEvents = await this.store.ReadEvents(EntityStreamName.For<T>(Id)).ToListAsync();

            T entity = new T();

            foreach (IDomainEvent domainEvent in domainEvents)
            {
                entity.When(domainEvent);
            }

            return entity;
        }

        public async Task Save<T>(T entity) where T : Entity
        {
            foreach (IDomainEvent domainEvent in entity.DomainEvents)
            {
                await this.store.Add(EntityStreamName.For(entity), domainEvent);
            }
        }
    }
}
