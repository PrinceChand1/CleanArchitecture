using CleanArchitecture.Application.Dtos.EmailConfigDtos.RequestDto;
using CleanArchitecture.Application.Dtos.EmailConfigDtos.ResponseDto;
using CleanArchitecture.Domain.Entities.EmailConfigEntities;

namespace CleanArchitecture.Application.Mapper.EmailConfigProfiles;
public class EmailConfigProfiler
{
    public static void ConfigureMappings(Profile profile)
    {
        profile.CreateMap<EmailConfig, EmailConfigRequestDto>().ReverseMap();
        profile.CreateMap<EmailConfig, EmailConfigResponseDto>().ReverseMap();
    }
}
