namespace Acervo.Application.DTOs
{
    public record CreateSaleItemDto(long SaleId, long BookId, int Quantity, decimal UnitPrice);

    public record UpdateSaleItemDto(long Id, long SaleId, long BookId, int Quantity, decimal UnitPrice);
}
