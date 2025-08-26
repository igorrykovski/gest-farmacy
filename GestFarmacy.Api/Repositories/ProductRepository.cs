using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;

namespace GestFarmacy.Api.Repositories
{
    /// <summary>
    /// In-memory implementation of product repository.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new()
        {
            new Product(Guid.NewGuid(), "Aspirin", 10m, 100),
            new Product(Guid.NewGuid(), "Ibuprofen", 15m, 200)
        };

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(Guid id) => _products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<Product> SearchByName(string name) =>
            _products.Where(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        public void Add(Product product) => _products.Add(product);

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                _products.Remove(existing);
                _products.Add(product);
            }
        }

        public void Remove(Guid id)
        {
            var product = GetById(id);
            if (product != null)
                _products.Remove(product);
        }
    }
}
