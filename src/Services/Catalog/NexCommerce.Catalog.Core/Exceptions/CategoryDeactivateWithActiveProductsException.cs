namespace NexCommerce.Catalog.Core.Exceptions;

public class CategoryDeactivateWithActiveProductsException : Exception
{
    public CategoryDeactivateWithActiveProductsException() : base("Cannot deactivate category with active products") { }
}
