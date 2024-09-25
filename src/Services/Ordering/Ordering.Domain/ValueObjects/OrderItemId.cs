namespace Ordering.Domain.ValueObjects;
public record OrderItemId
{
    public Guid Value { get; } = default!;

    private OrderItemId(Guid value) => Value = value;

    public static OrderItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Guid.Empty)
        {
            throw new DomainNotFoundException(nameof(OrderItemId));
        }

        return new OrderItemId(value);
    }
}
