namespace Acervo.Application.DTOs
{
    public record CreateCartDto(long UserId);

    public record UpdateCartDto(long Id, long UserId);
}
