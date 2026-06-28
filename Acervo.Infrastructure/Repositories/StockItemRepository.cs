using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {
        private readonly AppDbContext _context;

        public StockItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(StockItem Entity)
        {
            _context.StockItems.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<StockItem>>> GetAllStockItem()
        {
            List<StockItem>? items = await _context.StockItems.ToListAsync();

            if (items == null || items.Count == 0)
                return Result<List<StockItem>>.Failure("Nenhum item de estoque cadastrado!");

            return Result<List<StockItem>>.Success(items);
        }

        public async Task<Result<StockItem>> GetById(long Id)
        {
            StockItem? item = await _context.StockItems.FirstOrDefaultAsync(s => s.Id == Id);

            if (item == null)
                return Result<StockItem>.Failure("Item de estoque inexistente!");

            return Result<StockItem>.Success(item);
        }

        public async Task<Result> Insert(StockItem Entity)
        {
            await _context.StockItems.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(StockItem Entity)
        {
            _context.StockItems.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
