using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<User>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<User>>> GetAllUser() => await _repository.GetAllUser();
        public Result Delete(User Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(User Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(User Entity) => await _repository.Update(Entity);
    }
}
