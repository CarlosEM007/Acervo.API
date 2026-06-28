using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Task<Result<List<Seller>>> GetAllSeller();
    }
}
