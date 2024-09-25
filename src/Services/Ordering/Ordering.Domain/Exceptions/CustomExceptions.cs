namespace Ordering.Domain.Exceptions;
public class DomainNotFoundException(string domainName) : Exception(MessagesConstants.DomainNotFoundException + domainName);