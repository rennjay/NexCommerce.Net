namespace NexCommerce.Catalog.Core.Exceptions;

public class CategoryIdEmptyException : Exception
{
    public CategoryIdEmptyException() : base("Category ID cannot be empty") { }
}
