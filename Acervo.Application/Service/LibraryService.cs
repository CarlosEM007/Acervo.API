using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class LibraryService
    {
        private readonly ILibraryRepository _repository;

        public LibraryService(ILibraryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Library>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<Library>>> GetAllLibrary() => await _repository.GetAllLibrary();
        public Result Delete(Library Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(Library Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(Library Entity) => await _repository.Update(Entity);
    }
}
