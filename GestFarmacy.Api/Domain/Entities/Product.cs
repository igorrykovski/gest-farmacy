using System;

namespace GestFarmacy.Api.Domain.Entities
{
    /// <summary>
    /// Represents a product sold in the pharmacy.
    /// </summary>
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public Product(Guid id, string name, decimal price, int stock)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (price < 0)
                throw new ArgumentException("Price must be positive", nameof(price));
            if (stock < 0)
                throw new ArgumentException("Stock must be positive", nameof(stock));

            Id = id;
            Name = name;
            Price = price;
            Stock = stock;
        }

        public void UpdateStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Amount must be positive", nameof(amount));
            Stock = amount;
        }
    }
}
