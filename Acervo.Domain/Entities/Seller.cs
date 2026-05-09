using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Seller
    {
        public long Id { get; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; } // CNPJ or CPF
        public string Phone { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; }

        public ICollection<Stock> Stocks { get; private set; } = new List<Stock>();
        public ICollection<Sale> Sales { get; private set; } = new List<Sale>();

        protected Seller() { }

        public Seller(string name, string email, string document, string phone)
        {
            RulesValidations(name, email, document);
            Name = name;
            Email = email;
            Document = document;
            Phone = phone;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string name, string email, string phone)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome deve ser preenchido.");
            if (string.IsNullOrEmpty(email))
                throw new DomainException("O E-mail deve ser preenchido.");

            Name = name;
            Email = email;
            Phone = phone;
        }

        public void Deactivate() => IsActive = false;
        public void Activate() => IsActive = true;

        private void RulesValidations(string name, string email, string document)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(name))
                message += "O Nome deve ser preenchido. \n";

            if (string.IsNullOrEmpty(email))
                message += "O E-mail deve ser preenchido. \n";

            if (string.IsNullOrEmpty(document))
                message += "O Documento (CNPJ/CPF) deve ser preenchido. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}