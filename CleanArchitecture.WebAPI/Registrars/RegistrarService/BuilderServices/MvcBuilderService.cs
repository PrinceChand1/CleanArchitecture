using Asp.Versioning;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Shared.SharedResoures;
using CleanArchitecture.WebAPI.Filters;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.BuilderServices
{
    public class MvcBuilderService : IWebApplicationBuilderRegistrar
    {
        public void RegistrarBuilderServices(WebApplicationBuilder builder)
        {
            string CorsOrigins = "CorsOrigins";
            var connectionString = builder.Configuration.GetConnectionString("default");

            builder.Services.AddControllers();
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

            builder.Services.AddInfrastructureServices().AddApplicationServices(builder.Configuration);
            //Registering the Filter for Dependency Injection
            builder.Services.AddScoped<ProducesResponseTypeFilter>();

            // Global Registration of the Filter
            builder.Services.AddControllers(x =>
            {
                //x.Filters.Add<ProducesResponseTypeFilter>();
            });

            builder.Services.AddDbContext<StrideMemoDbContext>(x =>
            {
                x.UseSqlServer(connectionString, migrationLayer => migrationLayer.MigrationsAssembly(SharedResoure.MigrationLayer));
            });

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
