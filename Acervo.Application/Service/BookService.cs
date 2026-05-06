using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.Application.Service
{
    public class BookService
    {
        private IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Book>> GetById(long Id)
        {
            return await _repository.GetById(Id);
        }

        public async Task<Result<List<Book>>> GetAllBook()
        {
            return await _repository.GetAllBook();
        }

        public Result Delete(Book Entity)
        {
            return _repository.Delete(Entity);
        }

        public async Task<Result> Insert(Book Entity)
        {
            return await _repository.Insert(Entity);
        }

        public async Task<Result> Update(Book Entity)
        {
            return await _repository.Update(Entity);
        }
    }
}
