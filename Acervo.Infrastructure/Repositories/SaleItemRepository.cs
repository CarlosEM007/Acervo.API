using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly AppDbContext _context;

        public SaleItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(SaleItem Entity)
        {
            _context.SaleItems.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<SaleItem>>> GetAllSaleItem()
        {
            List<SaleItem>? items = await _context.SaleItems.ToListAsync();

            if (items == null || items.Count == 0)
                return Result<List<SaleItem>>.Failure("Nenhum item de venda cadastrado!");

            return Result<List<SaleItem>>.Success(items);
        }

        public async Task<Result<SaleItem>> GetById(long Id)
        {
            SaleItem? item = await _context.SaleItems.FirstOrDefaultAsync(s => s.Id == Id);

            if (item == null)
                return Result<SaleItem>.Failure("Item de venda inexistente!");

            return Result<SaleItem>.Success(item);
        }

        public async Task<Result> Insert(SaleItem Entity)
        {
            await _context.SaleItems.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(SaleItem Entity)
        {
            _context.SaleItems.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
