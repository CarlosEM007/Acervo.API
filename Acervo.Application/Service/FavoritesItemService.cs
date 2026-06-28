using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class FavoritesItemService
    {
        private readonly IFavoritesItemRepository _repository;

        public FavoritesItemService(IFavoritesItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<FavoritesItem>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<FavoritesItem>>> GetAllFavoritesItem() => await _repository.GetAllFavoritesItem();
        public Result Delete(FavoritesItem Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(FavoritesItem Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(FavoritesItem Entity) => await _repository.Update(Entity);
    }
}
