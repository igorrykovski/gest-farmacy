using System;

namespace GestFarmacy.Api.Domain.Entities
{
    /// <summary>
    /// Represents a sale transaction.
    /// </summary>
    public class Sale
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public Guid CustomerId { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Date { get; private set; }

        public Sale(Guid id, Guid productId, Guid customerId, int quantity, DateTime date)
        {
            if (quantity <= 0)
                throw new ArgumentException("Quantity must be greater than zero", nameof(quantity));

            Id = id;
            ProductId = productId;
            CustomerId = customerId;
            Quantity = quantity;
            Date = date;
        }
    }
}
