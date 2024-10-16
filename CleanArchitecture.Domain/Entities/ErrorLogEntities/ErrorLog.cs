namespace CleanArchitecture.Domain.Entities.ErrorLogEntities;
public class ErrorLog : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public required int Userid { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Method { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Operation { get; set; }
    [Required]
    [MaxLength(8000)]
    public string? Path { get; set; } = string.Empty;
    [MaxLength(8000)]
    public string? InnerException { get; set; }
    [MaxLength(8000)]
    public required string ErrorMessage { get; set; }
    [MaxLength(8000)]
    public required string StackTrace { get; set; }
}
