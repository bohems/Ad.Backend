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

            services.AddDbContext<AdvertisementsDbContext>(options =>
                options.UseSqlServer(connectionString));
              
            services.AddScoped<IAdvertisementsDbContext>(provider =>
                provider.GetService<AdvertisementsDbContext>());

            return services;
        }
    }
}
