namespace Catalog.API.Exceptions;

public class ProductNotFoundException() : Exception(MessagesConstants.ProductNotFound);
public class CategoryNotFoundException() : Exception(MessagesConstants.CategoryNotFound);