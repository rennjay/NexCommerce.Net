namespace NexCommerce.Catalog.Core.Exceptions;

public class StockQuantityNegativeException : Exception
{
    public StockQuantityNegativeException() : base("Stock quantity cannot be negative") { }
}
