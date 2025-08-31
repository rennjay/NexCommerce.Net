namespace NexCommerce.Catalog.Core.Exceptions;

public class ProductWeightNegativeException : Exception
{
    public ProductWeightNegativeException() : base("Weight cannot be negative") { }
}
