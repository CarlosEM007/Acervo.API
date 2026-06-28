using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class CategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Category>> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<Result<List<Category>>> GetAllCategory()
        {
            return await _repository.GetAllCategory();
        }

        public Result Delete(Category Entity)
        {
            return _repository.Delete(Entity);
        }

        public async Task<Result> Insert(Category Entity)
        {
            return await _repository.Insert(Entity);
        }

        public async Task<Result> Update(Category Entity)
        {
            return await _repository.Update(Entity);
        }
    }
}
