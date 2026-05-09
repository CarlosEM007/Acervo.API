using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Publisher
    {
        public long Id { get; }
        public string Name { get; private set; }
        public string Country { get; private set; }
        public string Website { get; private set; }

        public ICollection<Book> Books { get; private set; } = new List<Book>();

        protected Publisher() { }

        public Publisher(string name, string country, string website = null)
        {
            RulesValidations(name, country);
            Name = name;
            Country = country;
            Website = website;
        }

        public void Update(string name, string country, string website = null)
        {
            RulesValidations(name, country);
            Name = name;
            Country = country;
            Website = website;
        }

        private void RulesValidations(string name, string country)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(name))
                message += "O Nome da editora deve ser preenchido. \n";

            if (string.IsNullOrEmpty(country))
                message += "O País da editora deve ser preenchido. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}