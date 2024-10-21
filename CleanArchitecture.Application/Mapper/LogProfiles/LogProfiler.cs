using CleanArchitecture.Application.Dtos.LogDtos.RequestDto;
using CleanArchitecture.Domain.Entities.LogEntities;

namespace CleanArchitecture.Application.Mapper.LogProfiles;
public class LogProfiler
{
    public static void ConfigureMappings(Profile profile)
    {
        profile.CreateMap<Log, LogRequestDto>().ReverseMap();
        profile.CreateMap<Log, LogRequestDto>().ReverseMap();
    }
}