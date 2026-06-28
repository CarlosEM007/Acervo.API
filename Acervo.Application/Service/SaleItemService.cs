using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class SaleItemService
    {
        private readonly ISaleItemRepository _repository;

        public SaleItemService(ISaleItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<SaleItem>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<SaleItem>>> GetAllSaleItem() => await _repository.GetAllSaleItem();
        public Result Delete(SaleItem Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(SaleItem Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(SaleItem Entity) => await _repository.Update(Entity);
    }
}
