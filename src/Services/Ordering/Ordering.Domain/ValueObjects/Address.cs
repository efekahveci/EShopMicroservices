namespace Ordering.Domain.ValueObjects;
public record class Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmailAddress { get; } = default!;
    public string AddressLine { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string ZipCode { get; } = default!;

    private Address(string firstName, string lastName, string? emailAddress, string addressLine, string country, string state, string zipcode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipcode;
    }

    protected Address()
    {
    }

    public static Address Of(string firstName, string lastName, string? emailAddress, string addressLine, string country, string state, string zipcode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress, nameof(emailAddress));
        ArgumentException.ThrowIfNullOrWhiteSpace(addressLine, nameof(addressLine));

        return new Address(firstName, lastName, emailAddress, addressLine, country, state, zipcode);
    }
}
