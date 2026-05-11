using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acervo.Application.DTOs
{
    public class TokenDTO
    {
        public record TokenDto(string Token, DateTime Expiracao);
    }
}
