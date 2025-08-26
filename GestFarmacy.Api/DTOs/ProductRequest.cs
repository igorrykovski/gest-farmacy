namespace GestFarmacy.Api.DTOs
{
    /// <summary>
    /// DTO used to create or update a product.
    /// </summary>
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
