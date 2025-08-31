namespace NexCommerce.Catalog.Core.Exceptions;

public class SkuTooLongException : Exception
{
    public SkuTooLongException() : base("SKU cannot exceed 50 characters") { }
}
