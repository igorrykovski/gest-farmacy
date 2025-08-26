using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;
using GestFarmacy.Api.Domain.Interfaces.Services;

namespace GestFarmacy.Api.Services
{
    /// <summary>
    /// Business logic for customers.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer Create(Customer customer)
        {
            _repository.Add(customer);
            return customer;
        }

        public void Delete(Guid id) => _repository.Remove(id);

        public IEnumerable<Customer> GetAll() => _repository.GetAll();

        public Customer GetById(Guid id)
        {
            var customer = _repository.GetById(id);
            if (customer == null)
                throw new KeyNotFoundException("Customer not found");
            return customer;
        }

        public IEnumerable<Customer> Search(string name) => _repository.SearchByName(name);

        public void Update(Customer customer) => _repository.Update(customer);
    }
}
