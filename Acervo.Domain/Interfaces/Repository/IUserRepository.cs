using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<Result<List<User>>> GetAllUser();
        Task<Result<User>> ObterPorEmailAsync(string email);
    }
}
