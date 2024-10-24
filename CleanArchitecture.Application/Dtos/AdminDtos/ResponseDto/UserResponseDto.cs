using CleanArchitecture.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
public class UserResponseDto : BaseDto
{
    [Required]
    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    [Required]
    public required string Gender { get; set; }
    [Required]
    public required int Age { get; set; }
    [Required]
    public required string Phone { get; set; }
    [Required]
    public required string Email { get; set; }
    public string Password { get; set; }
    public required string UserType { get; set; }
    public string OfficeStaffType { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
}
