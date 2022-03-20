using ItemTracker.Abstractions;

namespace ItemTracker.Infrastucture
{
    public abstract class BaseRepository
    {
        protected readonly IEntityStore entityStore;

        protected BaseRepository(IEntityStore entityStore)
        {
            this.entityStore = entityStore;
        }

        public async Task Save<T>(T item) where T : Entity
        {
            await this.entityStore.Save(item);
        }
    }
}
