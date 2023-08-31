using Crud.API.Domain.Entities;
using Crud.API.Domain.Interfaces;
using Crud.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.Infra.Repository
{
    public class PersonRepository: IPersonRepository
    {
        private readonly SystemContext _context;

        public PersonRepository(SystemContext context)
        {
            _context = context;
        }

        public async Task Create(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            
        }

        public async Task Update(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetById(Guid id)
        {
            return await _context.Persons
                .Include(x => x.Address)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _context.Persons
                .Include(x => x.Address)
                .ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }   

    }
}
