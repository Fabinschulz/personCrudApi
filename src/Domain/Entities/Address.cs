using Crud.API.src.Domain.Enumerations;

namespace Crud.API.src.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string AddressName { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public UF UF { get; set; }

        public string District { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

    }
}
