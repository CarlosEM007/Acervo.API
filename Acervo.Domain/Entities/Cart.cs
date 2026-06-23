using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class Cart
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public User User { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; private set; }

        public ICollection<CartItem> Items { get; private set; } = new List<CartItem>();

        public decimal Total
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                    total += item.UnitPrice * item.Quantity;
                return total;
            }
        }

        protected Cart() { }

        public Cart(long userId)
        {
            if (userId <= 0)
                throw new DomainException("O Usuário deve ser válido.");

            UserId = userId;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddItem(long bookId, decimal unitPrice, int quantity = 1)
        {
            if (bookId <= 0)
                throw new DomainException("O livro deve ser válido.");

            if (unitPrice <= 0)
                throw new DomainException("O preço unitário deve ser maior que zero.");

            if (quantity <= 0)
                throw new DomainException("A quantidade deve ser maior que zero.");

            CartItem existingItem = null;
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
                Items.Add(new CartItem(Id, bookId, unitPrice, quantity));

            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveItem(long bookId)
        {
            CartItem itemToRemove = null;
            foreach (var item in Items)
            {
                if (item.BookId == bookId)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove == null)
                throw new DomainException("O livro não foi encontrado no carrinho.");

            Items.Remove(itemToRemove);
            UpdatedAt = DateTime.UtcNow;
        }

        public void Clear()
        {
            Items.Clear();
            UpdatedAt = DateTime.UtcNow;
        }
    }
}