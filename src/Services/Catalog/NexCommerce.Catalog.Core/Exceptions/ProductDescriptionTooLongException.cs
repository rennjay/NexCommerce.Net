namespace NexCommerce.Catalog.Core.Exceptions;

public class ProductDescriptionTooLongException : Exception
{
    public ProductDescriptionTooLongException() : base("Description cannot exceed 1000 characters") { }
}
