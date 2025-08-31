namespace NexCommerce.Catalog.Core.Exceptions;
public class NegativePriceException : Exception
{
    public NegativePriceException() : base("Price cannot be negative")
    {
    }
}
