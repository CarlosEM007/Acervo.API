using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class FavoritesItem
    {
        public long Id { get; }
        public long FavoritesId { get; private set; }
        public Favorites Favorites { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }
        public DateTime AddedAt { get; }

        protected FavoritesItem() { }

        public FavoritesItem(long favoritesId, long bookId)
        {
            if (favoritesId <= 0)
                throw new DomainException("O FavoritesId deve ser válido.");

            if (bookId <= 0)
                throw new DomainException("O BookId deve ser válido.");

            FavoritesId = favoritesId;
            BookId = bookId;
            AddedAt = DateTime.UtcNow;
        }
    }
}