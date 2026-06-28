using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface ILibraryRepository : IRepository<Library>
    {
        Task<Result<List<Library>>> GetAllLibrary();
    }
}
