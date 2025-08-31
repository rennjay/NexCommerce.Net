namespace NexCommerce.Catalog.Core.Entities;

public class EntityBase
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    public string? UpdatedBy { get; protected set; }
    public bool IsDeleted { get; protected set; } = false;

    protected EntityBase(string createdBy = "System")
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        CreatedBy = createdBy;
    }

    public virtual void Delete()
    {
        IsDeleted = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public virtual void MarkAsModified(string modifiedBy)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = modifiedBy;
    }
}