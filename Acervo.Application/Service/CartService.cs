using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class CartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Cart>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<Cart>>> GetAllCart() => await _repository.GetAllCart();
        public Result Delete(Cart Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(Cart Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(Cart Entity) => await _repository.Update(Entity);
    }
}
