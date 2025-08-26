using System;

namespace GestFarmacy.Api.DTOs
{
    /// <summary>
    /// DTO returned when querying a sale.
    /// </summary>
    public class SaleResponse
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
