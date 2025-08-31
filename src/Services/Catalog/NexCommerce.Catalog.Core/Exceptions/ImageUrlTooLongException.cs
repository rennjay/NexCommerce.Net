namespace NexCommerce.Catalog.Core.Exceptions;

public class ImageUrlTooLongException : Exception
{
    public ImageUrlTooLongException() : base("Image URL cannot exceed 500 characters") { }
}
