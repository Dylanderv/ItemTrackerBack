using ItemTracker.Abstractions;
using ItemTracker.Domain.Items.Events;

namespace ItemTracker.Domain.Items
{
    public class Item : Entity
    {
        private string name;
        private decimal quantity;
        private string unity;

        private Item(Guid id, IReadOnlyCollection<IDomainEvent> domainEvents) : base(id)
        {
            foreach (IDomainEvent domainEvent in domainEvents)
            {
                this.When(domainEvent);
            }
        }

        public static Item Rehydrate(Guid id, IReadOnlyCollection<IDomainEvent> domainEvents)
        {
            return new Item(id, domainEvents);
        }

        public void AddQuantity(decimal quantityToAdd)
        {
            this.StoreEvent(new ItemRefilled(this.Id, quantityToAdd));
        }

        public override void When(IDomainEvent domainEvent)
        {
            switch (domainEvent)
            {
                case ItemCreated itemCreated:
                    this.name = itemCreated.Name;
                    this.quantity = itemCreated.Quantity;
                    this.unity = itemCreated.Unity;
                    break;
                case ItemRefilled itemRefilled:
                    this.quantity += itemRefilled.QuantityAdded;
                    break;
                case ItemUsed itemUsed:
                    this.quantity -= itemUsed.QuantityUsed;
                    break;
                default:
                    throw new ArgumentException($"Unhandle event {nameof(domainEvent)}");
            }
        }

    }
}