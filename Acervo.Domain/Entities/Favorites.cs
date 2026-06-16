using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Favorites
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; }

        public ICollection<FavoritesItem> Items { get; private set; } = new List<FavoritesItem>();

        protected Favorites() { }

        public Favorites(long userId)
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
                throw new DomainException("O livro já está nos favoritos.");

            Items.Add(new FavoritesItem(Id, bookId));
        }

        public void RemoveItem(long bookId)
        {
            FavoritesItem itemToRemove = null;
            foreach (var item in Items)
            {
                if (item.BookId == bookId)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove == null)
                throw new DomainException("O livro não foi encontrado nos favoritos.");

            Items.Remove(itemToRemove);
        }
    }
}