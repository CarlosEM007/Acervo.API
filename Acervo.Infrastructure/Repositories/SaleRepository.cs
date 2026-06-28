using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _context;

        public SaleRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Sale Entity)
        {
            _context.Sales.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<Sale>>> GetAllSale()
        {
            List<Sale>? sales = await _context.Sales.ToListAsync();

            if (sales == null || sales.Count == 0)
                return Result<List<Sale>>.Failure("Nenhuma venda cadastrada!");

            return Result<List<Sale>>.Success(sales);
        }

        public async Task<Result<Sale>> GetById(long Id)
        {
            Sale? sale = await _context.Sales.FirstOrDefaultAsync(s => s.Id == Id);

            if (sale == null)
                return Result<Sale>.Failure("Venda inexistente!");

            return Result<Sale>.Success(sale);
        }

        public async Task<Result> Insert(Sale Entity)
        {
            await _context.Sales.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(Sale Entity)
        {
            _context.Sales.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
