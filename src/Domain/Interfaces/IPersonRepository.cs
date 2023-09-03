using Crud.API.src.Domain.Entities;
namespace Crud.API.src.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task Create(Person person);
        Task Update(Person person);
        Task Delete(Person person);
        Task Delete(Guid id);
        Task<Person> GetById(Guid id);
        Task<ListDataPagination<Person>> ListPerson(int page, int size, string searchString, string registrationNumber, string email, bool isDeleted, string orderBy);
        Task SaveChangesAsync();
    }
}
