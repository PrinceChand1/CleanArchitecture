namespace CleanArchitecture.Application.Dtos.AdminDtos.ResponseDto;
public class ResetPasswordResponseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string ResetLink { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}