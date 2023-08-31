using System.Net;

namespace Crud.API.Domain.Entities
{
    public class Person : BaseEntity
    {
        public string PersonName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int? RegistrationNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public Address? Address { get; set; }
    }
}
