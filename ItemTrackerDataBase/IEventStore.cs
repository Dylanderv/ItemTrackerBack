using ItemTracker.Abstractions;

namespace ItemTracker.Database
{
    public interface IEventStore
    {
        public Task Add(string streamName, IDomainEvent domainEvent);

        public IAsyncEnumerable<IDomainEvent> ReadEvents(string streamName);
    }
}
