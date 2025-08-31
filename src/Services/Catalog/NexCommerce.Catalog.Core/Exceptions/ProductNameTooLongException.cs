namespace NexCommerce.Catalog.Core.Exceptions;

public class ProductNameTooLongException : Exception
{
    public ProductNameTooLongException() : base("Product name cannot exceed 200 characters") { }
}
