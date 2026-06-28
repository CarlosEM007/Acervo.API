using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;

namespace Acervo.Application.Service
{
    public class LibraryItemService
    {
        private readonly ILibraryItemRepository _repository;

        public LibraryItemService(ILibraryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<LibraryItem>> GetById(long Id) => await _repository.GetById(Id);
        public async Task<Result<List<LibraryItem>>> GetAllLibraryItem() => await _repository.GetAllLibraryItem();
        public Result Delete(LibraryItem Entity) => _repository.Delete(Entity);
        public async Task<Result> Insert(LibraryItem Entity) => await _repository.Insert(Entity);
        public async Task<Result> Update(LibraryItem Entity) => await _repository.Update(Entity);
    }
}
