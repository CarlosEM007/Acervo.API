using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ILibraryItemRepository : IRepository<LibraryItem>
    {
        Task<Result<List<LibraryItem>>> GetAllLibraryItem();
    }
}
