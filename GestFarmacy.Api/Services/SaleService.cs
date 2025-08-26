using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;
using GestFarmacy.Api.Domain.Interfaces.Services;

namespace GestFarmacy.Api.Services
{
    /// <summary>
    /// Business logic for sales.
    /// </summary>
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repository;

        public SaleService(ISaleRepository repository)
        {
            _repository = repository;
        }

        public Sale Create(Sale sale)
        {
            _repository.Add(sale);
            return sale;
        }

        public void Delete(Guid id) => _repository.Remove(id);

        public IEnumerable<Sale> GetAll() => _repository.GetAll();

        public Sale GetById(Guid id)
        {
            var sale = _repository.GetById(id);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found");
            return sale;
        }

        public IEnumerable<Sale> GetByCustomer(Guid customerId) => _repository.GetByCustomer(customerId);
    }
}
