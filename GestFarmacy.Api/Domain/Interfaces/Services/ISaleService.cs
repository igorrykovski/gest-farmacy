using GestFarmacy.Api.Domain.Entities;

namespace GestFarmacy.Api.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetAll();
        Sale GetById(Guid id);
        IEnumerable<Sale> GetByCustomer(Guid customerId);
        Sale Create(Sale sale);
        void Delete(Guid id);
    }
}
