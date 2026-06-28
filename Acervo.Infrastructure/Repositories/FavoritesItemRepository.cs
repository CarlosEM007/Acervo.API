using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class FavoritesItemRepository : IFavoritesItemRepository
    {
        private readonly AppDbContext _context;

        public FavoritesItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(FavoritesItem Entity)
        {
            _context.FavoritesItems.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<FavoritesItem>>> GetAllFavoritesItem()
        {
            List<FavoritesItem>? items = await _context.FavoritesItems.ToListAsync();

            if (items == null || items.Count == 0)
                return Result<List<FavoritesItem>>.Failure("Nenhum item de favoritos cadastrado!");

            return Result<List<FavoritesItem>>.Success(items);
        }

        public async Task<Result<FavoritesItem>> GetById(long Id)
        {
            FavoritesItem? item = await _context.FavoritesItems.FirstOrDefaultAsync(f => f.Id == Id);

            if (item == null)
                return Result<FavoritesItem>.Failure("Item de favoritos inexistente!");

            return Result<FavoritesItem>.Success(item);
        }

        public async Task<Result> Insert(FavoritesItem Entity)
        {
            await _context.FavoritesItems.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(FavoritesItem Entity)
        {
            _context.FavoritesItems.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
