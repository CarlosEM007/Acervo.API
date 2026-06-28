using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IFavoritesRepository : IRepository<Favorites>
    {
        Task<Result<List<Favorites>>> GetAllFavorites();
    }
}
