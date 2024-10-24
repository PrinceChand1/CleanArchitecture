namespace CleanArchitecture.Application.Dtos.AdminDtos.ResponseDto;
public class UserLoginResponseDto : BaseDto
{
    public required string Token { get; set; }
    public required string FirstName { get; set; }
    public required string Email { get; set; }
    public required string UserType { get; set; }
    public string OfficeStaffType { get; set; }
}
