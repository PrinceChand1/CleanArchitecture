namespace CleanArchitecture.Domain.Entities.LogEntities;
[Table(nameof(Log))]
public class Log : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public required int Userid { get; set; }
    [Required]
    public required DateTime Date { get; set; } = DateTime.Now;
    [Required]
    [MaxLength(200)]
    public required string Method { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Operation { get; set; }
    [Required]
    [MaxLength(10000)]
    public string? Path { get; set; } = string.Empty;
    [MaxLength(10000)]
    public string? InnerException { get; set; }
    [MaxLength(10000)]
    public required string ErrorMessage { get; set; }
    [MaxLength(10000)]
    public required string StackTrace { get; set; }
}
