using Microsoft.EntityFrameworkCore;

namespace WebApi
{
    public static class DataExtensions
    {
        public static WebApplication ApplyMigration<T>(this WebApplication app) where T : DbContext
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<T>();

            db.Database.Migrate();

            return app;
        }
    }
}
