using AutoMapper;
using GestFarmacy.Api.Controllers;
using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Services;
using GestFarmacy.Api.Mapping;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GestFarmacy.Tests
{
    public class ProductsControllerTests
    {
        private readonly IMapper _mapper;

        public ProductsControllerTests()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Get_ReturnsOk()
        {
            // Arrange
            var serviceMock = new Mock<IProductService>();
            serviceMock.Setup(s => s.GetAll()).Returns(new List<Product>());
            var controller = new ProductsController(serviceMock.Object, _mapper);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}
