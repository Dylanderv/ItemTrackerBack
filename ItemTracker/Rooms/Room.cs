using ItemTracker.Domain.Items;

namespace ItemTracker.Domain.Rooms
{
    public class Room
    {
        public Guid Id { get; }
        public string Name { get; }
        public IList<Item> Items { get; }
    }
}
