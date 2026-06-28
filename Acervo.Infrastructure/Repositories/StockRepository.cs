using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _context;

        public StockRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Stock Entity)
        {
            _context.Stocks.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<Stock>>> GetAllStock()
        {
            List<Stock>? stocks = await _context.Stocks.ToListAsync();

            if (stocks == null || stocks.Count == 0)
                return Result<List<Stock>>.Failure("Nenhum estoque cadastrado!");

            return Result<List<Stock>>.Success(stocks);
        }

        public async Task<Result<Stock>> GetById(long Id)
        {
            Stock? stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == Id);

            if (stock == null)
                return Result<Stock>.Failure("Estoque inexistente!");

            return Result<Stock>.Success(stock);
        }

        public async Task<Result> Insert(Stock Entity)
        {
            await _context.Stocks.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(Stock Entity)
        {
            _context.Stocks.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
