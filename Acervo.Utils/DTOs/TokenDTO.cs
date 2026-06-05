namespace Acervo.Application.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime Expiracao { get; set; }

        public TokenDTO(string token, DateTime expiracao)
        {
            Token = token;
            Expiracao = expiracao;
        }
    }
}
