using Acervo.Web.Service;
using Microsoft.AspNetCore.Components.Web;
using System.Runtime.CompilerServices;

namespace Acervo.Web.Components.Pages
{
    public partial class Login
    {
        private readonly UserService _service;

        private string Usuario { get; set; }
        private string Senha { get; set; }

        public Login(UserService service)
        {
            _service = service;
        }

        private async Task Acessar()
        {
            var ok = await _service.LoginUser(Usuario, Senha);

            if(ok)
                Navigation.NavigateTo("/Home");
        }

        private void Registrar(MouseEventArgs e)
        {
            Navigation.NavigateTo("/registrar");
        }
    }
}
