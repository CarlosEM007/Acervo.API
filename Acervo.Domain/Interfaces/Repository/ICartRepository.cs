using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<Result<List<Cart>>> GetAllCart();
    }
}
