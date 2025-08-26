using GestFarmacy.Api.Domain.Entities;

namespace GestFarmacy.Api.Domain.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        Sale? GetById(Guid id);
        IEnumerable<Sale> GetByCustomer(Guid customerId);
        void Add(Sale sale);
        void Remove(Guid id);
    }
}
