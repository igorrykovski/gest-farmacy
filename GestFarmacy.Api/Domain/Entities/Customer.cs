using System;
using System.Text.RegularExpressions;

namespace GestFarmacy.Api.Domain.Entities
{
    /// <summary>
    /// Represents a client of the pharmacy.
    /// </summary>
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Customer(Guid id, string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty", nameof(name));
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Email format is invalid", nameof(email));

            Id = id;
            Name = name;
            Email = email;
        }
    }
}
