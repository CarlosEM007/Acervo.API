using Acervo.Application.DTOs;
using Acervo.Domain.Interfaces.Repository;
using Acervo.Domain.Interfaces.Services;

namespace Acervo.Application.UseCases.Auth
{
    public class LoginUseCase
    {
        private readonly IUserRepository _usuarioRepo;
        private readonly ITokenService _tokenService;

        public LoginUseCase(IUserRepository usuarioRepo, ITokenService tokenService)
        {
            _usuarioRepo = usuarioRepo;
            _tokenService = tokenService;
        }

        public async Task<TokenDTO> ExecutarAsync(LoginDto dto)
        {
            var usuario = await _usuarioRepo.ObterPorEmailAsync(dto.Email);

            if (!usuario.Succeeded || usuario.Value == null)
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            if (!BCrypt.Net.BCrypt.Verify(dto.PasswordHash, usuario.Value.PasswordHash))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            var token = _tokenService.GerarToken(usuario.Value);
            return new TokenDTO(token, DateTime.UtcNow.AddHours(8));
        }
    }
}
