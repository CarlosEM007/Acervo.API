using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Acervo.Infrastructure.Repositories
{
    public class BookRepository: IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Book Entity)
        {
            _context.Books.Remove(Entity);
            _context.SaveChanges();

            return Result.Success();
        }

        public async Task<Result<List<Book>>> GetAllBook()
        {
            List<Book>? Books = await _context.Books.ToListAsync();

            if(Books == null || Books.Count == 0)
            {
                return Result<List<Book>>.Failure("Nenhum livro cadastrado!");
            }

            return Result<List<Book>>.Success(Books);
        }

        public async Task<Result<Book>> GetById(long Id)
        {
            Book? Book = await _context.Books.FirstOrDefaultAsync(b => b.Id == Id);

            if(Book == null)
            {
                return Result<Book>.Failure("Livro inexistente!");
            }

            return Result<Book>.Success(Book);
        }

        public async Task<Result> Insert(Book Entity)
        {
            await _context.Books.AddAsync(Entity);
            await _context.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> Update(Book Entity)
        {
            _context.Books.Update(Entity);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
