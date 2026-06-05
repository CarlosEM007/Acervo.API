using Acervo.Application.DTOs;

namespace Acervo.Web
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateUser(LoginDto login)
        {

        }
    }
}
