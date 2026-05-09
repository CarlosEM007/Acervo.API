using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Author
    {
        public long Id { get; }
        public string Name { get; private set; }
        public string Biography { get; private set; }
        public DateTime? BirthDate { get; private set; }

        public ICollection<Book> Books { get; private set; } = new List<Book>();

        protected Author() { }

        public Author(string name, string biography, DateTime? birthDate = null)
        {
            RulesValidations(name);
            Name = name;
            Biography = biography;
            BirthDate = birthDate;
        }

        public void Update(string name, string biography, DateTime? birthDate = null)
        {
            RulesValidations(name);
            Name = name;
            Biography = biography;
            BirthDate = birthDate;
        }

        private void RulesValidations(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new DomainException("O Nome do autor deve ser preenchido.");
        }
    }
}