namespace Acervo.Application.DTOs
{
    public record CreateSellerDto(string Name, string Email, string Document, string? Phone);

    public record UpdateSellerDto(long Id, string Name, string Email, string? Phone);
}
