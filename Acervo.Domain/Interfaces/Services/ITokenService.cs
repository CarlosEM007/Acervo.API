using Acervo.Domain.Entities;
using System.Security.Claims;

namespace Acervo.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        string GerarToken(User usuario);
        ClaimsPrincipal? ValidarToken(string token);
    }
}
