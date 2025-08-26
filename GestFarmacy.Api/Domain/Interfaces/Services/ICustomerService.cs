using GestFarmacy.Api.Domain.Entities;

namespace GestFarmacy.Api.Domain.Interfaces.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(Guid id);
        IEnumerable<Customer> Search(string name);
        Customer Create(Customer customer);
        void Update(Customer customer);
        void Delete(Guid id);
    }
}
