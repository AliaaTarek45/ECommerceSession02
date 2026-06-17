using ECommerce.Domain.Contracts;

namespace ECommerce.API.Extensions
{
    internal static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");
            await seeder.SeedAsync();
            return app;
        }
    }
}
