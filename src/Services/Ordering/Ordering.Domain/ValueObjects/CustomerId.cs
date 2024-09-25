namespace Ordering.Domain.ValueObjects;
public record CustomerId
{
    public Guid Value { get; } = default!;

    private CustomerId(Guid value) => Value = value;

    public static CustomerId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Guid.Empty)
        {
            throw new DomainNotFoundException(nameof(CustomerId));
        }

        return new CustomerId(value);
    }
}
