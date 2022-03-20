using ItemTracker.Abstractions;

namespace ItemTracker.Domain.Items.Events
{
    public sealed record ItemUsed
    (
        Guid ItemId,
        decimal QuantityUsed
    ) : IDomainEvent;
}
