using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class AuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Author>> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<Result<List<Author>>> GetAllAuthor()
        {
            return await _repository.GetAllAuthor();
        }

        public Result Delete(Author Entity)
        {
            return _repository.Delete(Entity);
        }

        public async Task<Result> Insert(Author Entity)
        {
            return await _repository.Insert(Entity);
        }

        public async Task<Result> Update(Author Entity)
        {
            return await _repository.Update(Entity);
        }
    }
}
