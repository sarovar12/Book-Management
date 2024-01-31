
using BookManagement.Domain.Interface;
using BookManagement.Infrastructure.Repository;
using BookManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BookManagement.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddScoped<IBookService, BookServices>();
            services.AddScoped<IStudentService, StudentServices>();
            services.AddScoped<IIssueService, IssueServices>();
            return services;
        }
    }
}
