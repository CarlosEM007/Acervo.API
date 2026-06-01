using Microsoft.AspNetCore.Components.Web;

namespace Acervo.Web.Components.Pages
{
    public partial class Login
    {
        private string Usuario { get; set; }
        private string Senha { get; set; }

        private void Acessar()
        {
            Navigation.NavigateTo("/Home");
        }
    }
}
