namespace Acervo.Application.DTOs
{
    public record CreateStockItemDto(long StockId, long BookId, int Quantity, decimal Price);

    public record UpdateStockItemDto(long Id, long StockId, long BookId, int Quantity, decimal Price);
}
