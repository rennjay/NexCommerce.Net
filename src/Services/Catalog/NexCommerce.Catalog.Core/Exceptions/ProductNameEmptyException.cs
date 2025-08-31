namespace NexCommerce.Catalog.Core.Exceptions;

public class ProductNameEmptyException : Exception
{
    public ProductNameEmptyException() : base("Product name cannot be empty") { }
}
