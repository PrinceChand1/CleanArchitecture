using CleanArchitecture.Application.Dtos.UserDtos.RequestDto;
using CleanArchitecture.Application.Dtos.UserDtos.ResponseDto;
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
