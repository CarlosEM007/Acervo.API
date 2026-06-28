using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Acervo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public Result Delete(User Entity)
        {
            _context.Users.Remove(Entity);
            return Result.Success();
        }

        public async Task<Result<List<User>>> GetAllUser()
        {
            List<User>? users = await _context.Users.ToListAsync();

            if (users == null || users.Count == 0)
                return Result<List<User>>.Failure("Nenhum usuário cadastrado!");

            return Result<List<User>>.Success(users);
        }

        public async Task<Result<User>> GetById(long Id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == Id);

            if (user == null)
                return Result<User>.Failure("Usuário inexistente!");

            return Result<User>.Success(user);
        }

        public async Task<Result> Insert(User Entity)
        {
            await _context.Users.AddAsync(Entity);
            return Result.Success();
        }

        public async Task<Result> Update(User Entity)
        {
            _context.Users.Update(Entity);
            await _context.SaveChangesAsync();
            return Result.Success();
        }

        public async Task<Result<User>> ObterPorEmailAsync(string email)
        {
            User? user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user == null)
                return Result<User>.Failure("Nenhum usuário encontrado!");

            return Result<User>.Success(user);
        }
    }
}
