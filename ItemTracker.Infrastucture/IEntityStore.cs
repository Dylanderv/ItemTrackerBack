using ItemTracker.Abstractions;

namespace ItemTracker.Infrastucture
{
    public interface IEntityStore
    {
        public Task Save<T>(T entity) where T : Entity;
        public Task<T> Load<T>(Guid Id) where T : Entity, new();
    }
}
