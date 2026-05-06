using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<Result<List<Book>>> GetAllBook();
    }
}
