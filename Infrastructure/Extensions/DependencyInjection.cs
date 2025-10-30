using Application.Contracts.Repository;
using Infrastructure.DataAccess;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                opt.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IProductsRepository, ProductRepository>();
        }
    }
}
