using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

    }
}
