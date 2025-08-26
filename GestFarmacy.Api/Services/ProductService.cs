using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;
using GestFarmacy.Api.Domain.Interfaces.Services;

namespace GestFarmacy.Api.Services
{
    /// <summary>
    /// Business logic for products.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public Product Create(Product product)
        {
            _repository.Add(product);
            return product;
        }

        public void Delete(Guid id) => _repository.Remove(id);

        public IEnumerable<Product> GetAll() => _repository.GetAll();

        public Product GetById(Guid id)
        {
            var product = _repository.GetById(id);
            if (product == null)
                throw new KeyNotFoundException("Product not found");
            return product;
        }

        public IEnumerable<Product> Search(string name) => _repository.SearchByName(name);

        public void Update(Product product) => _repository.Update(product);
    }
}
