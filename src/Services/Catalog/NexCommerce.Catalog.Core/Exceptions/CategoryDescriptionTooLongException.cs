namespace NexCommerce.Catalog.Core.Exceptions;

public class CategoryDescriptionTooLongException : Exception
{
    public CategoryDescriptionTooLongException() : base("Description cannot exceed 500 characters") { }
}
