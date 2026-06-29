namespace Acervo.Application.DTOs
{
    public class LoginDto
    {
        public string Name         { get; set; } = string.Empty;
        public string Email        { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class TokenDTO
    {
        public string   Token     { get; set; } = string.Empty;
        public DateTime Expiracao { get; set; }

        public TokenDTO(string token, DateTime expiracao)
        {
            Token     = token;
            Expiracao = expiracao;
        }
    }
}
