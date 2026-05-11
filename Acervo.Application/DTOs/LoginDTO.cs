using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.Application.DTOs
{
    public class LoginDTO
    {
        public record LoginDto(string Email, string Senha);

    }
}
