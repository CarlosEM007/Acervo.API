using Acervo.Domain.Common;
using Acervo.Domain.Entities;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Acervo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<User>> ObterPorEmailAsync(string email)
        {
            User? user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (user == null)
            {
                return Result<User>.Failure("Nenhum usuário encontrado!");
            }

            return Result<User>.Success(user);
        }
    }
}
