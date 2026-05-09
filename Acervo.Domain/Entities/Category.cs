using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string Description { get; set; }

        public Category() { }

        public Category(string description)
        {
            RulesValidations(description);

            Description = description;
        }

        public void Update(string description)
        {
            RulesValidations(description);

            Description = description;
        }

        public void RulesValidations(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new DomainException("A descrição deve ser preenchida.");
            }
        }
    }
}
