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
            services.AddScoped<CartService>();
            services.AddScoped<CartItemService>();
            services.AddScoped<FavoritesService>();
            services.AddScoped<FavoritesItemService>();
            services.AddScoped<LibraryService>();
            services.AddScoped<LibraryItemService>();
            services.AddScoped<SaleService>();
            services.AddScoped<SaleItemService>();
            services.AddScoped<SellerService>();
            services.AddScoped<StockService>();
            services.AddScoped<StockItemService>();
            services.AddScoped<UserService>();

            return services;
        }
    }
}
