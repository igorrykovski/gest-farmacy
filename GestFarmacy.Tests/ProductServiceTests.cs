using GestFarmacy.Api.Domain.Entities;
using GestFarmacy.Api.Domain.Interfaces.Repositories;
using GestFarmacy.Api.Services;
using Moq;
using Xunit;

namespace GestFarmacy.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void GetById_ProductExists_ReturnsProduct()
        {
            // Arrange
            var id = Guid.NewGuid();
            var product = new Product(id, "Test", 5m, 1);
            var repoMock = new Mock<IProductRepository>();
            repoMock.Setup(r => r.GetById(id)).Returns(product);
            var service = new ProductService(repoMock.Object);

            // Act
            var result = service.GetById(id);

            // Assert
            Assert.Equal(product, result);
        }
    }
}
