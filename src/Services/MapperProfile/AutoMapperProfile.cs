using AutoMapper;
using Crud.API.src.Domain.Entities;
using Crud.API.src.Services.Dtos;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<Address, AddressDto>();
    }
}
