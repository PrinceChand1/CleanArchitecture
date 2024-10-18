namespace CleanArchitecture.Domain.Entities.Users;
[Table(nameof(User))]
public class User : BaseAuditableEntity
{
    [Required]
    [MaxLength(200)]
    public required string FirstName { get; set; }
    [MaxLength(200)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [MaxLength(20)]
    public required string Gender { get; set; }
    [Required]
    public required int Age { get; set; }
    [Required]
    [MaxLength(20)]
    public required string Phone { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Email { get; set; }
    [MaxLength(200)]
    public string Password { get; set; } = string.Empty;
    [Required]
    [MaxLength(50)]
    public required string UserType { get; set; }
    [MaxLength(50)]
    public string OfficeStaffType { get; set; } = string.Empty;
    [MaxLength(200)]
    public string Username { get; set; } = string.Empty;
}

