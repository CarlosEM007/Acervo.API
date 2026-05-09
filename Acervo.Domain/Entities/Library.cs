using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Library
    {
        public long Id { get; }
        public long UserId { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; }

        public ICollection<LibraryItem> Items { get; private set; } = new List<LibraryItem>();

        protected Library() { }

        public Library(long userId)
        {
            if (userId <= 0)
                throw new DomainException("O UserId deve ser válido.");

            UserId = userId;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(long bookId)
        {
            if (bookId <= 0)
                throw new DomainException("O BookId deve ser válido.");

            bool alreadyExists = false;
            foreach (var item in Items)
            {
                if (item.BookId == bookId)
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (alreadyExists)
                throw new DomainException("O livro já existe na biblioteca.");

            Items.Add(new LibraryItem(Id, bookId));
        }

        public void RemoveItem(long bookId)
        {
            LibraryItem itemToRemove = null;
            foreach (var item in Items)
            {
                if (item.BookId == bookId)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove == null)
                throw new DomainException("O livro não foi encontrado na biblioteca.");

            Items.Remove(itemToRemove);
        }
    }
}