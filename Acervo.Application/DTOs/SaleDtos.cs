namespace Acervo.Application.DTOs
{
    public record CreateSaleDto(long UserId, long SellerId);

    public record UpdateSaleDto(long Id, long UserId, long SellerId);
}
