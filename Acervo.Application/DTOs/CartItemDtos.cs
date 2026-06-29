namespace Acervo.Application.DTOs
{
    public record CreateCartItemDto(long CartId, long BookId, decimal UnitPrice, int Quantity);

    public record UpdateCartItemDto(long Id, long CartId, long BookId, decimal UnitPrice, int Quantity);
}
