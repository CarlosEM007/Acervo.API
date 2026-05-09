using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Stock
    {
        public long Id { get; }
        public long SellerId { get; private set; }
        public Seller Seller { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public ICollection<StockItem> Items { get; private set; } = new List<StockItem>();

        protected Stock() { }

        public Stock(long sellerId)
        {
            if (sellerId <= 0)
                throw new DomainException("O SellerId deve ser válido.");

            SellerId = sellerId;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddItem(long bookId, int quantity, decimal price)
        {
            if (bookId <= 0)
                throw new DomainException("O BookId deve ser válido.");

            StockItem existingItem = null;
            foreach (var item in Items)
            {
                if (item.BookId == bookId)
                {
                    existingItem = item;
                    break;
                }
            }

            if (existingItem != null)
                existingItem.IncreaseQuantity(quantity);
            else
                Items.Add(new StockItem(Id, bookId, quantity, price));

            UpdatedAt = DateTime.UtcNow;
        }

        public void DeductItem(long bookId, int quantity)
        {
            StockItem stockItem = null;
            foreach (var item in Items)
            {
                if (item.BookId == bookId)
                {
                    stockItem = item;
                    break;
                }
            }

            if (stockItem == null)
                throw new DomainException("Livro não encontrado no estoque.");

            stockItem.DecreaseQuantity(quantity);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}