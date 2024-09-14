namespace Catalog.API.Exceptions;

public class ProductNotFoundException(Guid id) : NotFoundException(MessagesConstants.ProductNotFound, id);
public class CategoryNotFoundException() : Exception(MessagesConstants.CategoryNotFound);