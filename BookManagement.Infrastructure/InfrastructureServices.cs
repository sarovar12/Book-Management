
using BookManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BookManagement.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            return services;
        }
    }
}
