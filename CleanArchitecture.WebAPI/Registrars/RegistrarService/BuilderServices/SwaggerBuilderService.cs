using CleanArchitecture.Shared.SharedResoures;
using CleanArchitecture.WebAPI.Options;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;
using Microsoft.OpenApi.Models;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.BuilderServices
{
    public class SwaggerBuilderService : IWebApplicationBuilderRegistrar
    {
        public void RegistrarBuilderServices(WebApplicationBuilder builder)
        {
            builder.Services.ConfigureOptions<ConfigureSwaggerOption>();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition(SharedResoure.Bearer, new OpenApiSecurityScheme
                {
                    Description = SharedResoure.JwtTokenDescription,
                    Name = SharedResoure.Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = SharedResoure.Bearer,
                    BearerFormat = SharedResoure.JWT
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = SharedResoure.Bearer
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }
    }
}
