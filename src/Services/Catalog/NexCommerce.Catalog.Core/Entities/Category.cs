namespace NexCommerce.Catalog.Core.Entities;
using NexCommerce.Catalog.Core.Exceptions;

public class Category : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public Guid? ParentCategoryId { get; private set; }
    public Category? ParentCategory { get; private set; }
    public IReadOnlyCollection<Product> Products => products.AsReadOnly();
    public IReadOnlyCollection<Category> SubCategories => subCategories.AsReadOnly();
    public bool IsActive { get; private set; } = true;

    private readonly List<Product> products = new();
    private readonly List<Category> subCategories = new();

    private Category() { }

    public Category(string name, string? description, Guid? parentCategoryId = null)
    {
        Name = name;
        Description = description;
        ParentCategoryId = parentCategoryId;
    }

    public void SetDescription(string? description)
    {
        if (description?.Length > 500)
            throw new CategoryDescriptionTooLongException();

        Description = description;
    }

    public void Activate()
    {
        IsActive = true;
        MarkAsModified("System");
    }

    public void Deactivate()
    {
        if (HasActiveProducts())
            throw new CategoryDeactivateWithActiveProductsException();

        IsActive = false;
        MarkAsModified("System");
    }

    public bool HasProducts() => products.Count > 0;

    public bool HasActiveProducts() => products.Any(p => p.IsAvailableForSale());

    public bool IsRootCategory() => ParentCategoryId == null;

    public int GetTotalProductCount() => products.Count + subCategories.Sum(sc => sc.GetTotalProductCount());
}
