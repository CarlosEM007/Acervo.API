using Acervo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Book> Books;

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
