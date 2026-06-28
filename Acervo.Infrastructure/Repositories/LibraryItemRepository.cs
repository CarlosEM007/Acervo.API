using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class LibraryItemRepository : ILibraryItemRepository
    {
        private readonly AppDbContext _context;

        public LibraryItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(LibraryItem Entity)
        {
            _context.LibraryItems.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<LibraryItem>>> GetAllLibraryItem()
        {
            List<LibraryItem>? items = await _context.LibraryItems.ToListAsync();

            if (items == null || items.Count == 0)
                return Result<List<LibraryItem>>.Failure("Nenhum item de biblioteca cadastrado!");

            return Result<List<LibraryItem>>.Success(items);
        }

        public async Task<Result<LibraryItem>> GetById(long Id)
        {
            LibraryItem? item = await _context.LibraryItems.FirstOrDefaultAsync(l => l.Id == Id);

            if (item == null)
                return Result<LibraryItem>.Failure("Item de biblioteca inexistente!");

            return Result<LibraryItem>.Success(item);
        }

        public async Task<Result> Insert(LibraryItem Entity)
        {
            await _context.LibraryItems.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(LibraryItem Entity)
        {
            _context.LibraryItems.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }
    }
}
