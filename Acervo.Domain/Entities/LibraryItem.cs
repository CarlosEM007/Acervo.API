using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class LibraryItem
    {
        public long Id { get; private set; }
        public long LibraryId { get; private set; }
        public Library Library { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }
        public DateTime AcquiredAt { get; }
        public DateTime? LastReadAt { get; private set; }
        public int ReadingProgress { get; private set; } 

        protected LibraryItem() { }

        public LibraryItem(long libraryId, long bookId)
        {
            if (libraryId <= 0)
                throw new DomainException("O biblioteca deve ser válida.");

            if (bookId <= 0)
                throw new DomainException("O livro deve ser válido.");

            LibraryId = libraryId;
            BookId = bookId;
            AcquiredAt = DateTime.UtcNow;
            ReadingProgress = 0;
        }

        public void UpdateProgress(int progressPercentage)
        {
            if (progressPercentage < 0 || progressPercentage > 100)
                throw new DomainException("O progresso deve estar entre 0 e 100.");

            ReadingProgress = progressPercentage;
            LastReadAt = DateTime.UtcNow;
        }
    }
}