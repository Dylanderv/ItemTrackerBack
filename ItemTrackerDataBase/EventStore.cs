using EventStore.Client;
using ItemTracker.Abstractions;
using ItemTracker.Extensions;
using System.Text;
using System.Text.Json;

namespace ItemTracker.Database
{
    public class EventStore : IEventStore
    {
        private readonly EventStoreClient dbClient;

        public EventStore(EventStoreClient dbClient)
        {
            this.dbClient = dbClient;
        }

        public async Task Add(string streamName, IDomainEvent domainEvent)
        {
            var eventData = new EventData(
                Uuid.NewUuid(),
                domainEvent.GetType().Name,
                JsonSerializer.SerializeToUtf8Bytes(domainEvent),
                metadata: Encoding.UTF8.GetBytes(domainEvent.GetType().Assembly.FullName)
            );

            await this.dbClient.AppendToStreamAsync(
                streamName,
                StreamState.Any,
                new[] { eventData }
            );
        }

        public async IAsyncEnumerable<IDomainEvent> ReadEvents(string streamName)
        {
            List<ResolvedEvent> resolvedEvents = await this.dbClient.ReadStreamAsync(
                Direction.Forwards,
                streamName,
                StreamPosition.Start
            ).ToListAsync();    

            foreach (ResolvedEvent resolvedEvent in resolvedEvents)
            {
                Type? type = resolvedEvent.Event.Metadata
                    .ToArray()
                    .Pipe(Encoding.UTF8.GetString)
                    .Pipe(Type.GetType);

                if (type == null) throw new InvalidCastException($"Unable to retrieve event {Encoding.UTF8.GetString(resolvedEvent.Event.Metadata.ToArray())}");

                string eventData = resolvedEvent.Event.Data
                    .ToArray()
                    .Pipe(Encoding.UTF8.GetString);

                var deserializedEvent = JsonSerializer.Deserialize(eventData, type);

                if (deserializedEvent is IDomainEvent domainEvent)
                {
                    yield return domainEvent;
                } else
                {
                    throw new InvalidCastException($"Deserialized event {deserializedEvent.GetType().Name} is not IDomainEvent");
                }
                
            }
        }
    }
}
