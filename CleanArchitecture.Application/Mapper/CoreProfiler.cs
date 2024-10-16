using CleanArchitecture.Application.Mapper.EmailConfigProfiles;
using CleanArchitecture.Application.Mapper.UserProfiles;

namespace CleanArchitecture.Application.Mapper;
public class CoreProfiler : Profile
{
    public CoreProfiler()
    {
        UserProfiler.ConfigureMappings(this);
        EmailConfigProfiler.ConfigureMappings(this);
    }
}



