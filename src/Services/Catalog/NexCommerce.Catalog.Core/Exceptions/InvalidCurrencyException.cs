namespace NexCommerce.Catalog.Core.Exceptions;
public class InvalidCurrencyException : Exception
{
    public InvalidCurrencyException() : base("Invalid price currency")
    {
    }
}
