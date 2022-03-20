using ItemTracker.Abstractions;

namespace ItemTracker.Domain.Items.Events
{
    public sealed record ItemCreated
    (
        string Name,
        decimal Quantity,
        string Unity
    ) : IDomainEvent;
}
