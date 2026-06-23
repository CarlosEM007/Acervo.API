using Acervo.Application.UseCases.Auth;
using Microsoft.AspNetCore.Mvc;
using Acervo.Application.DTOs;

namespace Acervo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly LoginUseCase _loginUseCase;

        public AuthController(LoginUseCase loginUseCase) => _loginUseCase = loginUseCase;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var resultado = await _loginUseCase.ExecutarAsync(dto);
            return Ok(resultado);
        }
    }
}
