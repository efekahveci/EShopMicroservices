﻿namespace Ordering.Domain.ValueObjects;
public record ProductId
{
    public Guid Value { get; } = default!;

    private ProductId(Guid value) => Value = value;

    public static ProductId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        if (value == Guid.Empty)
        {
            throw new DomainNotFoundException(nameof(ProductId));
        }

        return new ProductId(value);
    }
}
