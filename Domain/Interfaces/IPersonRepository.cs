using Crud.API.Domain.Entities;
using static Crud.API.Domain.Entities.ListaDataPagination;

namespace Crud.API.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task Create(Person person);
        Task Update(Person person);
        Task Delete(Person person);
        Task<Person> GetById(Guid id);
        Task<ListDataPagination<Person>> ListPerson(int page, int size, string searchString, string registrationNumber, string email, bool isDeleted, string orderBy);


        Task<int> SaveChanges();
    }
}
