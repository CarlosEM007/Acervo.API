using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Book
    {
        public long Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int PagesNumber { get; private set; }
        public DateTime Release { get; private set; }
        public string CoverImageUrl { get; private set; }

        public long CategoryId { get; private set; }
        public Category Category { get; private set; }

        public long AuthorId { get; private set; }
        public Author Author { get; private set; }

        public long PublisherId { get; private set; }
        public Publisher Publisher { get; private set; }

        protected Book() { }

        public Book(string title, string description, DateTime release, int pagesNumber,
                    long categoryId, long authorId, long publisherId, string coverImageUrl = null)
        {
            RulesValidations(title, description, pagesNumber, categoryId, authorId, publisherId);
            Title = title;
            Description = description;
            Release = release;
            PagesNumber = pagesNumber;
            CategoryId = categoryId;
            AuthorId = authorId;
            PublisherId = publisherId;
            CoverImageUrl = coverImageUrl;
        }

        public void Update(string title, string description, DateTime release, int pagesNumber,
                           long categoryId, long authorId, long publisherId, string coverImageUrl = null)
        {
            RulesValidations(title, description, pagesNumber, categoryId, authorId, publisherId);
            Title = title;
            Description = description;
            Release = release;
            PagesNumber = pagesNumber;
            CategoryId = categoryId;
            AuthorId = authorId;
            PublisherId = publisherId;
            CoverImageUrl = coverImageUrl;
        }

        private void RulesValidations(string title, string description, int pagesNumber,
                                       long categoryId, long authorId, long publisherId)
        {
            string message = string.Empty;

            if (string.IsNullOrEmpty(title))
                message += "O Título deve ser preenchido. \n";

            if (string.IsNullOrEmpty(description))
                message += "A Descrição deve ser preenchida. \n";

            if (pagesNumber <= 0)
                message += "A quantidade de páginas deve ser maior que 0. \n";

            if (categoryId <= 0)
                message += "A Categoria deve ser informada. \n";

            if (authorId <= 0)
                message += "O Autor deve ser informado. \n";

            if (publisherId <= 0)
                message += "A Editora deve ser informada. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}