using Acervo.Domain.Exceptions;
using Acervo.Domain.Enum;

namespace Acervo.Domain.Entities
{
    public class Sale
    {
        public long Id { get; }
        public long UserId { get; private set; }
        public User User { get; private set; }
        public long SellerId { get; private set; }
        public Seller Seller { get; private set; }
        public SaleStatus Status { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime CreatedAt { get; }
        public DateTime? CompletedAt { get; private set; }

        public ICollection<SaleItem> Items { get; private set; } = new List<SaleItem>();

        protected Sale() { }

        public Sale(long userId, long sellerId)
        {
            if (userId <= 0)
                throw new DomainException("O UserId deve ser válido.");

            if (sellerId <= 0)
                throw new DomainException("O SellerId deve ser válido.");

            UserId = userId;
            SellerId = sellerId;
            Status = SaleStatus.Pending;
            TotalAmount = 0;
            CreatedAt = DateTime.UtcNow;
        }

        public void AddItem(long bookId, int quantity, decimal unitPrice)
        {
            if (Status != SaleStatus.Pending)
                throw new DomainException("Não é possível adicionar itens a uma venda que não está pendente.");

            if (bookId <= 0)
                throw new DomainException("O BookId deve ser válido.");

            if (quantity <= 0)
                throw new DomainException("A quantidade deve ser maior que zero.");

            if (unitPrice <= 0)
                throw new DomainException("O preço unitário deve ser maior que zero.");

            Items.Add(new SaleItem(Id, bookId, quantity, unitPrice));
            RecalculateTotal();
        }

        public void Confirm()
        {
            if (Status != SaleStatus.Pending)
                throw new DomainException("Apenas vendas pendentes podem ser confirmadas.");

            if (Items.Count == 0)
                throw new DomainException("A venda deve ter pelo menos um item.");

            Status = SaleStatus.Confirmed;
        }

        public void Complete()
        {
            if (Status != SaleStatus.Confirmed)
                throw new DomainException("Apenas vendas confirmadas podem ser concluídas.");

            Status = SaleStatus.Completed;
            CompletedAt = DateTime.UtcNow;
        }

        public void Cancel()
        {
            if (Status == SaleStatus.Completed)
                throw new DomainException("Vendas concluídas não podem ser canceladas.");

            Status = SaleStatus.Cancelled;
        }

        private void RecalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.SubTotal;
            TotalAmount = total;
        }
    }
}