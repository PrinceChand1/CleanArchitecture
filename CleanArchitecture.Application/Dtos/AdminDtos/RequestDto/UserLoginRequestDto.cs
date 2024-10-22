using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
public class UserLoginRequestDto
{
    [Required(ErrorMessage = $"{nameof(Username)} is required.")]
    public required string Username { get; set; }

    [Required(ErrorMessage = $"{nameof(Password)} is required.")]
    public required string Password { get; set; }
}
