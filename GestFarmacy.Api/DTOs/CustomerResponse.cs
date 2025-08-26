using System;

namespace GestFarmacy.Api.DTOs
{
    /// <summary>
    /// DTO returned when querying a customer.
    /// </summary>
    public class CustomerResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
