using ItemTracker.Abstractions;

namespace ItemTracker.Domain.Items.Events
{
    public sealed record ItemRefilled
    (
        Guid ItemId,
        decimal QuantityAdded
    ) : IDomainEvent;
}
