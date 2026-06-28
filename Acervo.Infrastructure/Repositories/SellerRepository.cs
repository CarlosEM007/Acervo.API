using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AppDbContext _context;

        public SellerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Seller Entity)
        {
            _context.Sellers.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<Seller>>> GetAllSeller()
        {
            List<Seller>? sellers = await _context.Sellers.ToListAsync();

            if (sellers == null || sellers.Count == 0)
                return Result<List<Seller>>.Failure("Nenhum vendedor cadastrado!");

            return Result<List<Seller>>.Success(sellers);
        }

        public async Task<Result<Seller>> GetById(long Id)
        {
            Seller? seller = await _context.Sellers.FirstOrDefaultAsync(s => s.Id == Id);

            if (seller == null)
                return Result<Seller>.Failure("Vendedor inexistente!");

            return Result<Seller>.Success(seller);
        }

        public async Task<Result> Insert(Seller Entity)
        {
            await _context.Sellers.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(Seller Entity)
        {
            _context.Sellers.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
