using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Publisher Entity)
        {
            _context.Publishers.Remove(Entity);

            return Result.Success();
        }

        public async Task<Result<List<Publisher>>> GetAllPublisher()
        {
            List<Publisher>? publishers = await _context.Publishers.ToListAsync();

            if (publishers == null || publishers.Count == 0)
                return Result<List<Publisher>>.Failure("Nenhuma editora cadastrada!");

            return Result<List<Publisher>>.Success(publishers);
        }

        public async Task<Result<Publisher>> GetById(long Id)
        {
            Publisher? publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Id == Id);

            if (publisher == null)
                return Result<Publisher>.Failure("Editora inexistente!");

            return Result<Publisher>.Success(publisher);
        }

        public async Task<Result> Insert(Publisher Entity)
        {
            await _context.Publishers.AddAsync(Entity);

            return Result.Success();
        }

        public async Task<Result> Update(Publisher Entity)
        {
            _context.Publishers.Update(Entity);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
