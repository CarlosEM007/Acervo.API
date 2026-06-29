namespace Acervo.Application.DTOs
{
    public record CreateStockDto(long SellerId);

    public record UpdateStockDto(long Id, long SellerId);
}
