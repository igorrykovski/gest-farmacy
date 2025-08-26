using AutoMapper;
using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Services;
using GestFarmacy.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestFarmacy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService _service;
        private readonly IMapper _mapper;

        public SalesController(ISaleService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SaleResponse>> Get()
        {
            var sales = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<SaleResponse>>(sales));
        }

        [HttpGet("{id}")]
        public ActionResult<SaleResponse> Get(Guid id)
        {
            var sale = _service.GetById(id);
            return Ok(_mapper.Map<SaleResponse>(sale));
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<IEnumerable<SaleResponse>> GetByCustomer(Guid customerId)
        {
            var sales = _service.GetByCustomer(customerId);
            return Ok(_mapper.Map<IEnumerable<SaleResponse>>(sales));
        }

        [HttpPost]
        public ActionResult<SaleResponse> Post(SaleRequest request)
        {
            var sale = new Sale(Guid.NewGuid(), request.ProductId, request.CustomerId, request.Quantity, DateTime.UtcNow);
            var created = _service.Create(sale);
            var response = _mapper.Map<SaleResponse>(created);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
