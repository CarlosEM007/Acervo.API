using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IStockRepository : IRepository<Stock>
    {
        Task<Result<List<Stock>>> GetAllStock();
    }
}
