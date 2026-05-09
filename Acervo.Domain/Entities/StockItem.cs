using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class StockItem
    {
        public long Id { get; }
        public long StockId { get; private set; }
        public Stock Stock { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        protected StockItem() { }

        public StockItem(long stockId, long bookId, int quantity, decimal price)
        {
            RulesValidations(stockId, bookId, quantity, price);
            StockId = stockId;
            BookId = bookId;
            Quantity = quantity;
            Price = price;
            UpdatedAt = DateTime.UtcNow;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new DomainException("A quantidade a adicionar deve ser maior que zero.");

            Quantity += amount;
            UpdatedAt = DateTime.UtcNow;
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new DomainException("A quantidade a remover deve ser maior que zero.");

            if (Quantity - amount < 0)
                throw new DomainException("Estoque insuficiente para esta operação.");

            Quantity -= amount;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new DomainException("O preço deve ser maior que zero.");

            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        private void RulesValidations(long stockId, long bookId, int quantity, decimal price)
        {
            string message = string.Empty;

            if (stockId <= 0)
                message += "O StockId deve ser válido. \n";

            if (bookId <= 0)
                message += "O BookId deve ser válido. \n";

            if (quantity < 0)
                message += "A quantidade não pode ser negativa. \n";

            if (price <= 0)
                message += "O preço deve ser maior que zero. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}