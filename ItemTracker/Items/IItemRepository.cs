namespace ItemTracker.Domain.Items
{
    public interface IItemRepository
    {
        public Task<Item> GetItem(Guid id);
        public Task Save(Item item);
    }
}
