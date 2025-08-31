namespace NexCommerce.Catalog.Core.Exceptions;

public class BrandTooLongException : Exception
{
    public BrandTooLongException() : base("Brand cannot exceed 100 characters") { }
}
