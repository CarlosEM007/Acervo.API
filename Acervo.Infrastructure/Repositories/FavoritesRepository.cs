using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class FavoritesRepository : IFavoritesRepository
    {
        private readonly AppDbContext _context;

        public FavoritesRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Favorites Entity)
        {
            _context.Favorites.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<Favorites>>> GetAllFavorites()
        {
            List<Favorites>? favorites = await _context.Favorites.ToListAsync();

            if (favorites == null || favorites.Count == 0)
                return Result<List<Favorites>>.Failure("Nenhuma lista de favoritos cadastrada!");

            return Result<List<Favorites>>.Success(favorites);
        }

        public async Task<Result<Favorites>> GetById(long Id)
        {
            Favorites? favorites = await _context.Favorites.FirstOrDefaultAsync(f => f.Id == Id);

            if (favorites == null)
                return Result<Favorites>.Failure("Lista de favoritos inexistente!");

            return Result<Favorites>.Success(favorites);
        }

        public async Task<Result> Insert(Favorites Entity)
        {
            await _context.Favorites.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(Favorites Entity)
        {
            _context.Favorites.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
