using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class SaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Sale>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<Sale>>> GetAllSale() => await _repository.GetAllSale();
        public Result Delete(Sale Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(Sale Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(Sale Entity) => await _repository.Update(Entity);
    }
}
