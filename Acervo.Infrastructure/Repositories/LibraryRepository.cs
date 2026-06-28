using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _context;

        public LibraryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Library Entity)
        {
            _context.Libraries.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<Library>>> GetAllLibrary()
        {
            List<Library>? libraries = await _context.Libraries.ToListAsync();

            if (libraries == null || libraries.Count == 0)
                return Result<List<Library>>.Failure("Nenhuma biblioteca cadastrada!");

            return Result<List<Library>>.Success(libraries);
        }

        public async Task<Result<Library>> GetById(long Id)
        {
            Library? library = await _context.Libraries.FirstOrDefaultAsync(l => l.Id == Id);

            if (library == null)
                return Result<Library>.Failure("Biblioteca inexistente!");

            return Result<Library>.Success(library);
        }

        public async Task<Result> Insert(Library Entity)
        {
            await _context.Libraries.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(Library Entity)
        {
            _context.Libraries.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
