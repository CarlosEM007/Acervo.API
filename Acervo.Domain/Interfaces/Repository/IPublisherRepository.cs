using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        Task<Result<List<Publisher>>> GetAllPublisher();
    }
}
