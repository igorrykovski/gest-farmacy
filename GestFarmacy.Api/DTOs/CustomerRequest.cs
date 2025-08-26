namespace GestFarmacy.Api.DTOs
{
    /// <summary>
    /// DTO used to create or update a customer.
    /// </summary>
    public class CustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
