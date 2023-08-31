using Crud.API.Domain.Entities;

namespace Crud.API.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task Create(Person person);
        Task Update(Person person);
        Task Delete(Person person);
        Task<Person> GetById(Guid id);
        Task<IEnumerable<Person>> GetAll();

        Task<int> SaveChanges();
    }
}
