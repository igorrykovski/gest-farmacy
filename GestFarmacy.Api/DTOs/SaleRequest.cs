using System;

namespace GestFarmacy.Api.DTOs
{
    /// <summary>
    /// DTO used to create a sale.
    /// </summary>
    public class SaleRequest
    {
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
