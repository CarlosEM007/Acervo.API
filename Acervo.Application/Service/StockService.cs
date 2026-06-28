using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class StockService
    {
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Stock>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<Stock>>> GetAllStock() => await _repository.GetAllStock();
        public Result Delete(Stock Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(Stock Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(Stock Entity) => await _repository.Update(Entity);
    }
}
