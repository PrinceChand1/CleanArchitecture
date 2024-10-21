using CleanArchitecture.Domain.Entities.EmailConfigEntities;
using CleanArchitecture.Domain.Entities.LogEntities;
using CleanArchitecture.Domain.Entities.Users;
using System.Reflection;

namespace CleanArchitecture.Persistence.Context;
public class StrideMemoDbContext : DbContext
{
    public StrideMemoDbContext(DbContextOptions<StrideMemoDbContext> options) : base(options) { }
    public DbSet<User> users { get; set; }
    public DbSet<EmailConfig> emailConfigs { get; set; }
    public DbSet<Log> errorLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Throw error if migration commands are run outside of the Persistence layer
        var currentProject = AppDomain.CurrentDomain.BaseDirectory;
        if (currentProject.Contains("Persistence"))
        {
            throw new InvalidOperationException("Migrations can only be executed from the Persistence project.");
        }
        //modelBuilder.ApplyConfiguration(new UserConfiguration());
        //modelBuilder.ApplyConfiguration(new EmailConfigConfiguration());
        //modelBuilder.ApplyConfiguration(new EmailConfigConfiguration());
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
