namespace Acervo.Application.DTOs
{
    public record CreateCategoryDto(string Description);

    public record UpdateCategoryDto(long Id, string Description);
}
