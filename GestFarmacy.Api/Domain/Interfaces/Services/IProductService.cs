using GestFarmacy.Api.Domain.Entities;

namespace GestFarmacy.Api.Domain.Interfaces.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        IEnumerable<Product> Search(string name);
        Product Create(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}
