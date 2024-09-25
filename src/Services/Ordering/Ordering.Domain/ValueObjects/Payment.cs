﻿namespace Ordering.Domain.ValueObjects;
public record Payment
{
    public string CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string CVV { get; } = default!;
    public string Expiration { get; } = default!;
    public int PaymentMethod { get; } = default!;

    private Payment(string cardName, string cardNumber, string cvv, string expiration, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        CVV = cvv;
        Expiration = expiration;
        PaymentMethod = paymentMethod;
    }
    protected Payment() { }
    public static Payment Of(string cardName, string cardNumber, string cvv, string expiration, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName, nameof(cardName));
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber));
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv, nameof(cvv));

        return new Payment(cardName, cardNumber, cvv, expiration, paymentMethod);
    }

}
