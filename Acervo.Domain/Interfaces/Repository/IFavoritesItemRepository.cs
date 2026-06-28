using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IFavoritesItemRepository : IRepository<FavoritesItem>
    {
        Task<Result<List<FavoritesItem>>> GetAllFavoritesItem();
    }
}
