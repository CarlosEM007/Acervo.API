namespace Acervo.Application.DTOs
{
    public record CreateUserDto(string Name, string Email, string PasswordHash);

    public record UpdateUserDto(long Id, string Name, string Email);
}
