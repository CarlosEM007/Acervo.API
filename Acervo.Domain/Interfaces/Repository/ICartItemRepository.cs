using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ICartItemRepository : IRepository<CartItem>
    {
        Task<Result<List<CartItem>>> GetAllCartItem();
    }
}
