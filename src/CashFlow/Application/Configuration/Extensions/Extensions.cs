using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using CashFlow.Infrastructure.Database;

namespace CashFlow.Application.Configuration.Extensions
{
    public static class Extensions
    {
        public static string GetRequiredValue(this IConfiguration configuration, string name) =>
       configuration[name] ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":" + name : name)}");

        public static string GetRequiredConnectionString(this IConfiguration configuration, string name) =>
            configuration.GetConnectionString(name) ?? throw new InvalidOperationException($"Configuration missing value for: {(configuration is IConfigurationSection s ? s.Path + ":ConnectionStrings:" + name : "ConnectionStrings:" + name)}");

        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            static void ConfigureSqlOptions(SqlServerDbContextOptionsBuilder sqlOptions)
            {
                sqlOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
            };

            services.AddDbContext<MovementContext>(options =>
            {
                var connectionString = configuration.GetRequiredConnectionString("MovementDB");

                options.UseSqlServer(connectionString, ConfigureSqlOptions);
            });

            return services;
        }
    }
}
