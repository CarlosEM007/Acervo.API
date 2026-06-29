namespace Acervo.Application.DTOs
{
    public record CreateAuthorDto(
        string    Name,
        string?   Biography,
        DateTime? BirthDate);

    public record UpdateAuthorDto(
        long      Id,
        string    Name,
        string?   Biography,
        DateTime? BirthDate);
}
