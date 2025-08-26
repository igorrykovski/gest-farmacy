using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;

namespace GestFarmacy.Api.Repositories
{
    /// <summary>
    /// In-memory implementation of sale repository.
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private static readonly List<Sale> _sales = new();

        public IEnumerable<Sale> GetAll() => _sales;

        public Sale? GetById(Guid id) => _sales.FirstOrDefault(s => s.Id == id);

        public IEnumerable<Sale> GetByCustomer(Guid customerId) =>
            _sales.Where(s => s.CustomerId == customerId);

        public void Add(Sale sale) => _sales.Add(sale);

        public void Remove(Guid id)
        {
            var sale = GetById(id);
            if (sale != null)
                _sales.Remove(sale);
        }
    }
}
