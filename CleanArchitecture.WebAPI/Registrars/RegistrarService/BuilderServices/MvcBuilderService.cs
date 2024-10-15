using Asp.Versioning;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;
using FluentValidation.AspNetCore;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.BuilderServices
{
    public class MvcBuilderService : IWebApplicationBuilderRegistrar
    {
        string CorsOrigins = "CorsOrigins";
        public void RegistrarBuilderServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            
            // CORS setup
            string? corsRaw = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(corsRaw))
            {
                string[] corsOrigins = corsRaw.Split(',');
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy(name: CorsOrigins,
                        builder =>
                        {
                            builder.WithOrigins(corsOrigins)
                                .AllowAnyHeader()
                                .AllowCredentials()
                                .AllowAnyMethod();
                        });
                });
            }
        }
    }
}
