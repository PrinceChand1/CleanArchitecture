namespace CleanArchitecture.Domain.Entities;
public class BaseEntity
{
    [Key]
    public int Id { get; set; }
    [MaxLength(200)]
    public string? CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    [MaxLength(200)]
    public string? ModifiedBy { get; set; } = string.Empty;
    public DateTime ModifiedOn { get; set; }
    [MaxLength(200)]
    public string? DeletedBy { get; set; } = string.Empty;
    public DateTime DeletedOn { get; set; }
    public bool IsDeleted { get; set; } = false;
}
