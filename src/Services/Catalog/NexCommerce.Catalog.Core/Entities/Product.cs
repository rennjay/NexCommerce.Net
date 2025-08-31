using NexCommerce.Catalog.Core.Enums;
using NexCommerce.Catalog.Core.ValueObjects;
using NexCommerce.Catalog.Core.Exceptions;

namespace NexCommerce.Catalog.Core.Entities;

public class Product : EntityBase
{
    public string Name { get; private set; } = string.Empty;
    public string? Description { get; private set; }
    public string SKU { get; private set; } = string.Empty;
    public Price Price { get; private set; } = new Price(0, "USD");
    public int StockQuantity { get; private set; }
    public ProductStatus Status { get; private set; } = ProductStatus.Active;
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public string? ImageUrl { get; private set; }
    public double Weight { get; private set; }
    public string? Brand { get; private set; }
    public DateTime? LaunchDate { get; private set; }

    private Product() { }

    public Product(string name, string sku, decimal price, Guid categoryId, string createdBy)
    {
        SetName(name);
        SetSKU(sku);
        SetPrice(price);
        SetCategoryId(categoryId);
        CreatedBy = createdBy;
        Status = ProductStatus.Active;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ProductNameEmptyException();

        if (name.Length > 200)
            throw new ProductNameTooLongException();

        Name = name;
    }

    public void SetSKU(string sku)
    {
        if (string.IsNullOrWhiteSpace(sku))
            throw new SkuEmptyException();

        if (sku.Length > 50)
            throw new SkuTooLongException();

        SKU = sku;
    }

    public void SetPrice(decimal amount, string currency = "USD")
    {
        Price = new Price(amount, currency);
    }

    public void SetDescription(string? description)
    {
        if (description?.Length > 1000)
            throw new ProductDescriptionTooLongException();

        Description = description;
    }

    public void SetCategoryId(Guid categoryId)
    {
        if (categoryId == Guid.Empty)
            throw new CategoryIdEmptyException();

        CategoryId = categoryId;
    }

    public void UpdateStock(int quantity)
    {
        if (quantity < 0)
            throw new StockQuantityNegativeException();

        StockQuantity = quantity;
        MarkAsModified("System");
    }

    public void ChangeStatus(ProductStatus newStatus)
    {
        Status = newStatus;
        MarkAsModified("System");
    }

    public void SetImageUrl(string? imageUrl)
    {
        if (imageUrl?.Length > 500)
            throw new ImageUrlTooLongException();

        ImageUrl = imageUrl;
    }

    public void SetWeight(double weight)
    {
        if (weight < 0)
            throw new ProductWeightNegativeException();

        Weight = weight;
    }

    public void SetBrand(string? brand)
    {
        if (brand?.Length > 100)
            throw new BrandTooLongException();

        Brand = brand;
    }

    public void SetLaunchDate(DateTime? launchDate)
    {
        LaunchDate = launchDate;
    }

    public bool IsInStock()
    {
        return StockQuantity > 0 && Status == ProductStatus.Active;
    }

    public bool IsAvailableForSale()
    {
        return Status == ProductStatus.Active && !IsDeleted;
    }
}
