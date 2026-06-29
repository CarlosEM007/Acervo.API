namespace Acervo.Application.DTOs
{
    public record CreatePublisherDto(string Name, string Country, string? Website);

    public record UpdatePublisherDto(long Id, string Name, string Country, string? Website);
}
