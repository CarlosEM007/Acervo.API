using Acervo.Application.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<BookService>();
            services.AddScoped<AuthorService>();
            services.AddScoped<PublisherService>();
            services.AddScoped<CategoryService>();

            return services;
        }
    }
}
