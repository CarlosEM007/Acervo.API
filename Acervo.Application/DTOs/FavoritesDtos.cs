namespace Acervo.Application.DTOs
{
    public record CreateFavoritesDto(long UserId);

    public record UpdateFavoritesDto(long Id, long UserId);
}
