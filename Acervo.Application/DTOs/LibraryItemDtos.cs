namespace Acervo.Application.DTOs
{
    public record CreateLibraryItemDto(long LibraryId, long BookId);

    public record UpdateLibraryItemDto(long Id, long LibraryId, long BookId);
}
