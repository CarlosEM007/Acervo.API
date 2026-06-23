using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class CartItem
    {
        public long Id { get; private set; }
        public long CartId { get; private set; }
        public Cart Cart { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }

        public decimal SubTotal => UnitPrice * Quantity;

        protected CartItem() { }

        public CartItem(long cartId, long bookId, decimal unitPrice, int quantity)
        {
            RulesValidations(cartId, bookId, unitPrice, quantity);
            CartId = cartId;
            BookId = bookId;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new DomainException("A quantidade a adicionar deve ser maior que zero.");

            Quantity += amount;
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount <= 0)
                throw new DomainException("A quantidade a remover deve ser maior que zero.");

            if (Quantity - amount < 1)
                throw new DomainException("A quantidade não pode ficar menor que 1.");

            Quantity -= amount;
        }

        public void UpdateQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new DomainException("A quantidade deve ser maior que zero.");

            Quantity = quantity;
        }

        private void RulesValidations(long cartId, long bookId, decimal unitPrice, int quantity)
        {
            string message = string.Empty;

            if (cartId <= 0)
                message += "O CartId deve ser válido. \n";

            if (bookId <= 0)
                message += "O BookId deve ser válido. \n";

            if (unitPrice <= 0)
                message += "O preço unitário deve ser maior que zero. \n";

            if (quantity <= 0)
                message += "A quantidade deve ser maior que zero. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}