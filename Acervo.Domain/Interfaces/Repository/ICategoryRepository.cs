using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Result<List<Category>>> GetAllCategory();
    }
}
