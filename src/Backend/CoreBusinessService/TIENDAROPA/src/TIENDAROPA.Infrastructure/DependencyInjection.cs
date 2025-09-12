using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TIENDAROPA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TIENDAROPA.Infrastructure
{
    public static class DependencyInjection
    {
        // Note: It's convention to make the first parameter `this IServiceCollection services`
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Get the connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // The assembly variable is useful if you want to specify a migrations assembly,
            // which is a common practice.
            var assembly = typeof(TiendadbContext).Assembly.FullName;

            services.AddDbContext<TiendadbContext>(options =>
                options.UseSqlServer(connectionString, sqlOptions =>
                {
                    // Optional: Specify the assembly where your migrations are located.
                    // This is very useful in a multi-project solution.
                    sqlOptions.MigrationsAssembly(assembly);
                }));

            // Here is where you would register your repositories or other infrastructure services
            // Example:
            // services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
//dotnet ef migrations add InitialCreate --project TIENDAROPA.Infrastructure -o Migrations