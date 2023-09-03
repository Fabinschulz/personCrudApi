using Crud.API.src.Domain.Entities;
using Crud.API.src.Domain.Interfaces;
using Crud.API.src.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Crud.API.src.Infra.Repository
{
    public class PersonRepository : IPersonRepository
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

        public async Task Delete(Guid id)
        {
            _context.Persons.Remove(await GetById(id));
            await _context.SaveChangesAsync();
            return;
        }

        public async Task<Person> GetById(Guid id)
        {
            var person = await _context.Persons.Include(x => x.Address).FirstOrDefaultAsync(x => x.Id == id);
            return person;
        }

        public async Task<ListDataPagination<Person>> ListPerson(int page, int size, string searchString, string registrationNumber, string email, bool isDeleted, string orderBy)
        {
            var query = _context.Persons
                .Include(x => x.Address)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.PersonName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(registrationNumber))
            {
                query = query.Where(x => x.RegistrationNumber.Contains(registrationNumber));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.Contains(email));
            }

            if (isDeleted)
            {
                query = query.Where(x => x.IsDeleted == isDeleted);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "personName":
                        query = query.OrderBy(x => x.PersonName);
                        break;
                    case "email":
                        query = query.OrderBy(x => x.Email);
                        break;
                    case "registrationNumber":
                        query = query.OrderBy(x => x.RegistrationNumber);
                        break;
                    case "birthDate":
                        query = query.OrderBy(x => x.BirthDate);
                        break;
                    case "phoneNumber":
                        query = query.OrderBy(x => x.PhoneNumber);
                        break;
                    case "address":
                        query = query.OrderBy(x => x.Address);
                        break;
                    case "isDeleted":
                        query = query.OrderBy(x => x.IsDeleted);
                        break;
                    default:
                        query = query.OrderBy(x => x.PersonName);
                        break;
                }
            }

            var count = await query.CountAsync();
            var data = await query.Skip((page - 1) * size).Take(size).ToListAsync();

            return new ListDataPagination<Person>
            {
                Page = page,
                TotalPages = (int)Math.Ceiling(count / (double)size),
                TotalItems = count,
                Data = data
            };

        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
