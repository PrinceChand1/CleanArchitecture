using CleanArchitecture.Infrastructure.Repositories.AbstractRepositories;

namespace CleanArchitecture.Application.Comman.Security;
public class JwtSecurityMiddleware
{
    private IUnitOfWork _unitOfWork = null!;
    public async Task InvokeAsync()
    {
        try
        {
        }
        catch (Exception ex)
        {
            //await HandleExceptionAsync(context, ex);
        }
    }
}
