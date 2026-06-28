using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(Category Entity)
        {
            _context.Categories.Remove(Entity);

            return Result.Success();
        }

        public async Task<Result<List<Category>>> GetAllCategory()
        {
            List<Category>? categories = await _context.Categories.ToListAsync();

            if (categories == null || categories.Count == 0)
                return Result<List<Category>>.Failure("Nenhuma categoria cadastrada!");

            return Result<List<Category>>.Success(categories);
        }

        public async Task<Result<Category>> GetById(long Id)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == Id);

            if (category == null)
                return Result<Category>.Failure("Categoria inexistente!");

            return Result<Category>.Success(category);
        }

        public async Task<Result> Insert(Category Entity)
        {
            await _context.Categories.AddAsync(Entity);

            return Result.Success();
        }

        public async Task<Result> Update(Category Entity)
        {
            _context.Categories.Update(Entity);
            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
