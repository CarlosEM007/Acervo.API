using Acervo.Domain.Exceptions;

namespace Acervo.Domain.Entities
{
    public class SaleItem
    {
        public long Id { get; }
        public long SaleId { get; private set; }
        public Sale Sale { get; private set; }
        public long BookId { get; private set; }
        public Book Book { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }

        public decimal SubTotal => UnitPrice * Quantity;

        protected SaleItem() { }

        public SaleItem(long saleId, long bookId, int quantity, decimal unitPrice)
        {
            RulesValidations(saleId, bookId, quantity, unitPrice);
            SaleId = saleId;
            BookId = bookId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        private void RulesValidations(long saleId, long bookId, int quantity, decimal unitPrice)
        {
            string message = string.Empty;

            if (saleId <= 0)
                message += "O SaleId deve ser válido. \n";

            if (bookId <= 0)
                message += "O BookId deve ser válido. \n";

            if (quantity <= 0)
                message += "A quantidade deve ser maior que zero. \n";

            if (unitPrice <= 0)
                message += "O preço unitário deve ser maior que zero. \n";

            if (!string.IsNullOrEmpty(message))
                throw new DomainException(message);
        }
    }
}