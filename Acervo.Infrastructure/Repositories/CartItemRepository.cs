using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _context;

        public CartItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(CartItem Entity)
        {
            _context.CartItems.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<CartItem>>> GetAllCartItem()
        {
            List<CartItem>? items = await _context.CartItems.ToListAsync();

            if (items == null || items.Count == 0)
                return Result<List<CartItem>>.Failure("Nenhum item de carrinho cadastrado!");

            return Result<List<CartItem>>.Success(items);
        }

        public async Task<Result<CartItem>> GetById(long Id)
        {
            CartItem? item = await _context.CartItems.FirstOrDefaultAsync(c => c.Id == Id);

            if (item == null)
                return Result<CartItem>.Failure("Item de carrinho inexistente!");

            return Result<CartItem>.Success(item);
        }

        public async Task<Result> Insert(CartItem Entity)
        {
            await _context.CartItems.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(CartItem Entity)
        {
            _context.CartItems.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
