namespace Basket.API.Exceptions;

public class BasketNotFoundException(string userName) : NotFoundException(MessagesConstants.BasketNotFound, userName);
public class BasketItemNotFoundException(Guid itemId) : NotFoundException(MessagesConstants.BasketItemNotFound, itemId);