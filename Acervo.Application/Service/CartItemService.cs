using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class CartItemService
    {
        private readonly ICartItemRepository _repository;

        public CartItemService(ICartItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<CartItem>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<CartItem>>> GetAllCartItem() => await _repository.GetAllCartItem();
        public Result Delete(CartItem Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(CartItem Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(CartItem Entity) => await _repository.Update(Entity);
    }
}
