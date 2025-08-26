using AutoMapper;
using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Services;
using GestFarmacy.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestFarmacy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerResponse>> Get()
        {
            var customers = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<CustomerResponse>>(customers));
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerResponse> Get(Guid id)
        {
            var customer = _service.GetById(id);
            return Ok(_mapper.Map<CustomerResponse>(customer));
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<CustomerResponse>> Search([FromQuery] string name)
        {
            var customers = _service.Search(name);
            return Ok(_mapper.Map<IEnumerable<CustomerResponse>>(customers));
        }

        [HttpPost]
        public ActionResult<CustomerResponse> Post(CustomerRequest request)
        {
            var customer = new Customer(Guid.NewGuid(), request.Name, request.Email);
            var created = _service.Create(customer);
            var response = _mapper.Map<CustomerResponse>(created);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, CustomerRequest request)
        {
            var customer = new Customer(id, request.Name, request.Email);
            _service.Update(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
