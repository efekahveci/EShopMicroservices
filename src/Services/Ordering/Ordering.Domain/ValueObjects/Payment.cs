namespace Ordering.Domain.ValueObjects;
public record Payment
{
    public string CardName { get; } = default!;
    public string CardNumber { get; } = default!;
    public string Cvv { get; } = default!;
    public string Expiration { get; } = default!;
    public int PaymentMethod { get; } = default!;

    private Payment(string cardName, string cardNumber, string cvv, string expiration, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Cvv = cvv;
        Expiration = expiration;
        PaymentMethod = paymentMethod;
    }
    protected Payment() { }
    public static Payment Of(string cardName, string cardNumber, string expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName, nameof(cardName));
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber, nameof(cardNumber)); 
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, cvv, expiration, paymentMethod);
    }

}
