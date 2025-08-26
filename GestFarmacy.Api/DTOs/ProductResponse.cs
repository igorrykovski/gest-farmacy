using System;

namespace GestFarmacy.Api.DTOs
{
    /// <summary>
    /// DTO returned when querying a product.
    /// </summary>
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
