using CleanArchitecture.Application.Dtos;

namespace CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
public class UserResponseDto : BaseDto
{
    public required string Token { get; set; }
    public required string FirstName { get; set; }
    public required string Number { get; set; }
    public required string Email { get; set; }
    public required string UserType { get; set; }
    public string OfficeStaffType { get; set; }
}
