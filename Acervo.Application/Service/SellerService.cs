using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class SellerService
    {
        private readonly ISellerRepository _repository;

        public SellerService(ISellerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Seller>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<Seller>>> GetAllSeller() => await _repository.GetAllSeller();
        public Result Delete(Seller Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(Seller Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(Seller Entity) => await _repository.Update(Entity);
    }
}
