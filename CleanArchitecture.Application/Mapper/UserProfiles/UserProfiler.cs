using CleanArchitecture.Application.AdminDtos.UserDtos.ResponseDto;
using CleanArchitecture.Application.Dtos.AdminDtos.RequestDto;
using CleanArchitecture.Domain.Entities.Users;

namespace CleanArchitecture.Application.Mapper.UserProfiles;
public class UserProfiler
{
    public static void ConfigureMappings(Profile profile)
    {
        profile.CreateMap<User, UserRequestDto>().ReverseMap();
        profile.CreateMap<User, UserResponseDto>().ReverseMap();
    }
}
