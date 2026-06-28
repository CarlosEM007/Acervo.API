using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ISaleRepository : IRepository<Sale>
    {
        Task<Result<List<Sale>>> GetAllSale();
    }
}
