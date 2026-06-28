using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IStockItemRepository : IRepository<StockItem>
    {
        Task<Result<List<StockItem>>> GetAllStockItem();
    }
}
