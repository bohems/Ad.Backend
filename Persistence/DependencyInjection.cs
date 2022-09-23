using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Application.Interfaces;

namespace Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration["PersistenceModule:DefaultConnection"];

            services.AddDbContext<AdDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetService<AdDbContext>());

            return services;
        }

        public class PersistenceModuleOptions
        {
            public const string PersistenceModule = "PersistenceModule";

            public string DefaultConnection { get; set; } = string.Empty;
        }
    }
}
