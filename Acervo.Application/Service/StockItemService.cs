using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class StockItemService
    {
        private readonly IStockItemRepository _repository;

        public StockItemService(IStockItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<StockItem>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<StockItem>>> GetAllStockItem() => await _repository.GetAllStockItem();
        public Result Delete(StockItem Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(StockItem Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(StockItem Entity) => await _repository.Update(Entity);
    }
}
