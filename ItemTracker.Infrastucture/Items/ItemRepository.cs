using ItemTracker.Domain.Items;

namespace ItemTracker.Infrastucture.Items
{
    public class ItemRepository : BaseRepository, IItemRepository
    {
        public ItemRepository(IEntityStore entityStore) : base(entityStore)
        {
        }

        public async Task<Item> GetItem(Guid id)
        {
            return await this.entityStore.Load<Item>(id);
        }

        public async Task Save(Item item)
        {
            await base.Save(item);
        }
    }
}
