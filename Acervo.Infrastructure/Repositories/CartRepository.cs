using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Cart Entity)
        {
            _context.Carts.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<Cart>>> GetAllCart()
        {
            List<Cart>? carts = await _context.Carts.ToListAsync();

            if (carts == null || carts.Count == 0)
                return Result<List<Cart>>.Failure("Nenhum carrinho cadastrado!");

            return Result<List<Cart>>.Success(carts);
        }

        public async Task<Result<Cart>> GetById(long Id)
        {
            Cart? cart = await _context.Carts.FirstOrDefaultAsync(c => c.Id == Id);

            if (cart == null)
                return Result<Cart>.Failure("Carrinho inexistente!");

            return Result<Cart>.Success(cart);
        }

        public async Task<Result> Insert(Cart Entity)
        {
            await _context.Carts.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(Cart Entity)
        {
            _context.Carts.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
