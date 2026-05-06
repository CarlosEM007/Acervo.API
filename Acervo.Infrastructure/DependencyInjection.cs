using Acervo.Domain.Interfaces;
using Acervo.Infrastructure.Data;
using Acervo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acervo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("Postgres"),
                    sql => sql.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                ));

            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
