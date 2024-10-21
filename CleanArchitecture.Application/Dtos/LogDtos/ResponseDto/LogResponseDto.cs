using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.LogDtos.ResponseDto;
public class LogResponseDto : BaseDto
{
    [Required]
    public required DateTime Date { get; set; }
    [Required]
    public required int Userid { get; set; }
    [Required]
    public required string Method { get; set; }
    [Required]
    public required string Operation { get; set; }
    [Required]
    public string? Path { get; set; } = string.Empty;
    public string? InnerException { get; set; }
    public required string ErrorMessage { get; set; }
    public required string StackTrace { get; set; }
}
