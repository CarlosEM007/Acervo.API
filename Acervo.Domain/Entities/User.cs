using Acervo.Domain.Enum;
using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class User
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; }
        public UserRole Role { get; private set; }

        protected User() { }

        public User(string name, string email, string passwordHash)
        {
            RulesValidations(name, email, passwordHash);
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string email)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome deve ser preenchido.");
            if (string.IsNullOrEmpty(email))
                throw new DomainException("O E-mail deve ser preenchido.");

            Name = name;
            Email = email;
        }

        public void ChangePassword(string newPasswordHash)
        {
            if (string.IsNullOrEmpty(newPasswordHash))
                throw new DomainException("A senha não pode ser vazia.");

            PasswordHash = newPasswordHash;
        }

        private void RulesValidations(string name, string email, string passwordHash)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(name))
                message += "O Nome deve ser preenchido. \n";

            if (string.IsNullOrEmpty(email))
                message += "O E-mail deve ser preenchido. \n";

            if (string.IsNullOrEmpty(passwordHash))
                message += "A Senha deve ser preenchida. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}