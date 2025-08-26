using GestFarmacy.Api.Domain.Entities;

namespace GestFarmacy.Api.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(Guid id);
        IEnumerable<Customer> SearchByName(string name);
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(Guid id);
    }
}
