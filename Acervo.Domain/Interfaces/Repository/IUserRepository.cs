using Acervo.Domain.Common;
using Acervo.Domain.Entities;

namespace Acervo.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        Task<Result<User>> ObterPorEmailAsync(string email);
    }
}
