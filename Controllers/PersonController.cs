using Crud.API;
using Crud.API.Domain.Entities;
using Crud.API.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Crud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository) => _personRepository = personRepository;

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var people = await _personRepository.GetAll();
            return Ok(people);
        }

        [HttpGet("get/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _personRepository.GetById(id);
            return Ok(person);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(Person person)
        {
            await _personRepository.Create(person);
            return Ok();
        }

        [HttpPut("update/{id:guid}")]
        public async Task<IActionResult> Update(Guid id)
        {
            var person = await _personRepository.GetById(id);
            await _personRepository.Update(person);
            return Ok();
        }

        [HttpDelete("remove/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var person = await _personRepository.GetById(id);
            await _personRepository.Delete(person);
            return Ok();
        }
    }   
    
}