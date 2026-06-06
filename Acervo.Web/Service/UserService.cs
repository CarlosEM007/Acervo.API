using Acervo.Application.DTOs;
using Acervo.Web.Endpoints.Auth;
using System.Net.Http.Json;

namespace Acervo.Web.Service
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
        private readonly SessionService _session;

        public UserService(HttpClient httpClient, SessionService session)
        {
            _httpClient = httpClient;
            _session = session;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var login = new LoginDto()
            {
                Email = email,
                PasswordHash = password
            };
            
            var response = await _httpClient.PostAsJsonAsync(AuthEndpoints.Login(), login);

            if(!response.IsSuccessStatusCode)
                return false;

            var result = await response.Content.ReadFromJsonAsync<TokenDTO>();

            if(result?.Token == null)
                return false;

            _session.SetToken(result.Token);
            return true;
        }
    }
}
