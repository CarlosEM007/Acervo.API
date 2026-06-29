namespace Acervo.Application.DTOs
{
    public record CreateBookDto(
        string   Title,
        string   Description,
        DateTime Release,
        int      PagesNumber,
        long     CategoryId,
        long     AuthorId,
        long     PublisherId,
        string?  CoverImageUrl);

    public record UpdateBookDto(
        long     Id,
        string   Title,
        string   Description,
        DateTime Release,
        int      PagesNumber,
        long     CategoryId,
        long     AuthorId,
        long     PublisherId,
        string?  CoverImageUrl);
}
