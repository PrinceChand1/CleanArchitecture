namespace CleanArchitecture.Domain.Entities;
public abstract class BaseAuditableEntity : BaseEntity
{
    [MaxLength(200)]
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [MaxLength(200)]
    public string? ModifiedBy { get; set; } = string.Empty;
    public DateTime? ModifiedOn { get; set; }
    [MaxLength(200)]
    public string? DeletedBy { get; set; } = string.Empty;
    public DateTime? DeletedOn { get; set; }
    public bool IsDeleted { get; set; } = false;

    ///// <summary>
    ///// Marks the entity as deleted with relevant metadata.
    ///// </summary>
    ///// <param name="deletedBy">User who performed the deletion</param>
    //public void SoftDelete(string deletedBy)
    //{
    //    IsDeleted = true;
    //    DeletedBy = deletedBy;
    //    DeletedOn = DateTime.UtcNow;
    //}

    ///// <summary>
    ///// Restores the entity from a soft-delete state.
    ///// </summary>
    //public void Restore()
    //{
    //    IsDeleted = false;
    //    DeletedBy = null;
    //    DeletedOn = null;
    //}

    ///// <summary>
    ///// Updates audit fields during modification.
    ///// </summary>
    ///// <param name="modifiedBy">User who modified the entity</param>
    //public void SetModified(string modifiedBy)
    //{
    //    ModifiedBy = modifiedBy;
    //    ModifiedOn = DateTime.Now;
    //}

    ///// <summary>
    ///// Initializes audit fields during entity creation.
    ///// </summary>
    ///// <param name="createdBy">User who created the entity</param>
    //public void SetCreated(string createdBy)
    //{
    //    CreatedBy = createdBy;
    //    CreatedOn = DateTime.UtcNow;
    //}
}