using Application.Common;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<UserOptions>(configuration.GetSection(UserOptions.User));
            services.Configure<JwtSettingsOptions>(configuration.GetSection(JwtSettingsOptions.JwtSettings));

            string connectionString = configuration["PersistenceModule:DefaultConnection"];

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IAdRepository, AdRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
