using ItemTracker.Abstractions;

namespace ItemTracker.Database
{
    public static class EntityStreamName
    {
        public static string For<T>(T entity) where T : Entity
        {
            return For<T>(entity.Id);
        }

        public static string For<T>(Guid id) where T : Entity
        {
            return $"{nameof(T)}-{id}";
        }
    }
}
