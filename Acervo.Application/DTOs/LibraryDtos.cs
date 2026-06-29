namespace Acervo.Application.DTOs
{
    public record CreateLibraryDto(long UserId);

    public record UpdateLibraryDto(long Id, long UserId);
}
