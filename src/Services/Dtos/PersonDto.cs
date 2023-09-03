namespace Crud.API.src.Services.Dtos
{
    public class PersonDto
    {
        public Guid Id { get; set; }
        public string PersonName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
        public bool IsDeleted { get; set; }

    }

}
