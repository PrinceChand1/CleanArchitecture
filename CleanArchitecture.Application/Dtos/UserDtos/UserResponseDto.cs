namespace CleanArchitecture.Application.Dtos.UserDtos;
public class UserResponseDto : BaseDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
}
