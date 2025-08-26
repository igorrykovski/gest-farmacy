using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;

namespace GestFarmacy.Api.Repositories
{
    /// <summary>
    /// In-memory implementation of customer repository.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private static readonly List<Customer> _customers = new()
        {
            new Customer(Guid.NewGuid(), "John Doe", "john@example.com"),
            new Customer(Guid.NewGuid(), "Jane Smith", "jane@example.com")
        };

        public IEnumerable<Customer> GetAll() => _customers;

        public Customer? GetById(Guid id) => _customers.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Customer> SearchByName(string name) =>
            _customers.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        public void Add(Customer customer) => _customers.Add(customer);

        public void Update(Customer customer)
        {
            var existing = GetById(customer.Id);
            if (existing != null)
            {
                _customers.Remove(existing);
                _customers.Add(customer);
            }
        }

        public void Remove(Guid id)
        {
            var customer = GetById(id);
            if (customer != null)
                _customers.Remove(customer);
        }
    }
}
