using AutoMapper;
using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Services;
using GestFarmacy.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GestFarmacy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> Get()
        {
            var products = _service.GetAll();
            return Ok(_mapper.Map<IEnumerable<ProductResponse>>(products));
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponse> Get(Guid id)
        {
            var product = _service.GetById(id);
            return Ok(_mapper.Map<ProductResponse>(product));
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<ProductResponse>> Search([FromQuery] string name)
        {
            var products = _service.Search(name);
            return Ok(_mapper.Map<IEnumerable<ProductResponse>>(products));
        }

        [HttpPost]
        public ActionResult<ProductResponse> Post(ProductRequest request)
        {
            var product = new Product(Guid.NewGuid(), request.Name, request.Price, request.Stock);
            var created = _service.Create(product);
            var response = _mapper.Map<ProductResponse>(created);
            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, ProductRequest request)
        {
            var product = new Product(id, request.Name, request.Price, request.Stock);
            _service.Update(product);
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
