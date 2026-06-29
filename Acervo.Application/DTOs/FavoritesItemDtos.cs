namespace Acervo.Application.DTOs
{
    public record CreateFavoritesItemDto(long FavoritesId, long BookId);

    public record UpdateFavoritesItemDto(long Id, long FavoritesId, long BookId);
}
