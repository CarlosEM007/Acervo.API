using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ISaleItemRepository : IRepository<SaleItem>
    {
        Task<Result<List<SaleItem>>> GetAllSaleItem();
    }
}
