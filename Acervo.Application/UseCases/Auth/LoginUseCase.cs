using Acervo.Domain.Interfaces.Services;
using static Acervo.Application.DTOs.LoginDTO;
using static Acervo.Application.DTOs.TokenDTO;

namespace Acervo.Application.UseCases.Auth
{
    public class LoginUseCase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly ITokenService _tokenService;

        public LoginUseCase(IUsuarioRepository usuarioRepo, ITokenService tokenService)
        {
            _usuarioRepo = usuarioRepo;
            _tokenService = tokenService;
        }

        public async Task<TokenDto> ExecutarAsync(LoginDto dto)
        {
            var usuario = await _usuarioRepo.ObterPorEmailAsync(dto.Email)
                ?? throw new UnauthorizedAccessException("Credenciais inválidas.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
                throw new UnauthorizedAccessException("Credenciais inválidas.");

            var token = _tokenService.GerarToken(usuario);
            return new TokenDto(token, DateTime.UtcNow.AddHours(8));
        }
    }
}
