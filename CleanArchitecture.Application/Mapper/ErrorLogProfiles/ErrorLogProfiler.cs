using CleanArchitecture.Application.Dtos.ErrorLogDtos.RequestDto;
using CleanArchitecture.Domain.Entities.ErrorLogEntities;

namespace CleanArchitecture.Application.Mapper.ErrorLogProfiles;
public class ErrorLogProfiler
{
    public static void ConfigureMappings(Profile profile)
    {
        profile.CreateMap<ErrorLog, ErrorLogRequestDto>().ReverseMap();
        profile.CreateMap<ErrorLog, ErrorLogRequestDto>().ReverseMap();
    }
}
