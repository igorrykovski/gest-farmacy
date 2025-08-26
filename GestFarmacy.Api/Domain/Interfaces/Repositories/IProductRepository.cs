using GestFarmacy.Api.Domain.Entities;

namespace GestFarmacy.Api.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product? GetById(Guid id);
        IEnumerable<Product> SearchByName(string name);
        void Add(Product product);
        void Update(Product product);
        void Remove(Guid id);
    }
}
