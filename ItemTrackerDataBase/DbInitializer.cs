using EventStore.Client;

namespace ItemTracker.Database
{
    public class DbInitializer
    {
        public EventStoreClient InitializeDatabase()
        {
            var settings = EventStoreClientSettings.Create("");
            return new EventStoreClient(settings);
        }
    }
}
