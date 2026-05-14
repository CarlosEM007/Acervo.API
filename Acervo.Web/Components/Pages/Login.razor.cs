using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Acervo.Web.Pages
{
    public partial class Login
    {
        [Inject] private NavigationManager Navigation { get; set; }

        private string Username { get; set; } = string.Empty;
        private string Password { get; set; } = string.Empty;
        private string ErrorMessage { get; set; } = string.Empty;
        private bool IsLoading { get; set; } = false;

        private async Task HandleLogin()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Preencha o usuário e a senha.";
                return;
            }

            IsLoading = true;

            try
            {
                // TODO: substitua pela chamada real ao seu serviço de autenticação
                await Task.Delay(800); // simulação de requisição

                bool success = Username == "admin" && Password == "admin";

                if (success)
                    Navigation.NavigateTo("/dashboard");
                else
                    ErrorMessage = "Usuário ou senha inválidos.";
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task HandleKeyDown(KeyboardEventArgs e)
        {
            if (e.Key == "Enter")
                await HandleLogin();
        }
    }
}