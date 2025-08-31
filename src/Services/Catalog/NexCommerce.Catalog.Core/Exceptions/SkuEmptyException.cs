namespace NexCommerce.Catalog.Core.Exceptions;

public class SkuEmptyException : Exception
{
    public SkuEmptyException() : base("SKU cannot be empty") { }
}
