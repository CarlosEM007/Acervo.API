using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class PublisherService
    {
        private readonly IPublisherRepository _repository;

        public PublisherService(IPublisherRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Publisher>> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<Result<List<Publisher>>> GetAllPublisher()
        {
            return await _repository.GetAllPublisher();
        }

        public Result Delete(Publisher Entity)
        {
            return _repository.Delete(Entity);
        }

        public async Task<Result> Insert(Publisher Entity)
        {
            return await _repository.Insert(Entity);
        }

        public async Task<Result> Update(Publisher Entity)
        {
            return await _repository.Update(Entity);
        }
    }
}
