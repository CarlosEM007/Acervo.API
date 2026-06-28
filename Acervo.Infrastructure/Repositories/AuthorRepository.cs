using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Author Entity)
        {
            _context.Authors.Remove(Entity);

            return Result.Success();
        }

        public async Task<Result<List<Author>>> GetAllAuthor()
        {
            List<Author>? authors = await _context.Authors.ToListAsync();

            if (authors == null || authors.Count == 0)
                return Result<List<Author>>.Failure("Nenhum autor cadastrado!");

            return Result<List<Author>>.Success(authors);
        }

        public async Task<Result<Author>> GetById(long Id)
        {
            Author? author = await _context.Authors.FirstOrDefaultAsync(a => a.Id == Id);

            if (author == null)
                return Result<Author>.Failure("Autor inexistente!");

            return Result<Author>.Success(author);
        }

        public async Task<Result> Insert(Author Entity)
        {
            await _context.Authors.AddAsync(Entity);

            return Result.Success();
        }

        public async Task<Result> Update(Author Entity)
        {
            _context.Authors.Update(Entity);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
