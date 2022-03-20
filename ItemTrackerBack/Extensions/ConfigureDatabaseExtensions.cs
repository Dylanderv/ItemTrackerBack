using ItemTracker.Database;

namespace ItemTrackerBack.Web.Extensions
{
    public static class ConfigureDatabaseExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services)
        {
            var dbInitializer = new DbInitializer();
            services.AddSingleton(dbInitializer.InitializeDatabase());
            services.AddScoped<IEventStore, ItemTracker.Database.EventStore>();
        }
    }
}
