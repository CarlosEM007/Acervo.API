using Acervo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Publisher> Publishers => Set<Publisher>();

        public DbSet<Cart> Carts => Set<Cart>();
        public DbSet<CartItem> CartItems => Set<CartItem>();

        public DbSet<Favorites> Favorites => Set<Favorites>();
        public DbSet<FavoritesItem> FavoritesItems => Set<FavoritesItem>();

        public DbSet<Library> Libraries => Set<Library>();
        public DbSet<LibraryItem> LibraryItems => Set<LibraryItem>();

        public DbSet<Seller> Sellers => Set<Seller>();
        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<StockItem> StockItems => Set<StockItem>();

        public DbSet<Sale> Sales => Set<Sale>();
        public DbSet<SaleItem> SaleItems => Set<SaleItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}