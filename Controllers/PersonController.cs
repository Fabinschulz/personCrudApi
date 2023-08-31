using Crud.API;
using Crud.API.Domain.Entities;
using Crud.API.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static Crud.API.Domain.Entities.ListaDataPagination;

namespace Crud.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository) => _personRepository = personRepository;

        /// <summary>
        /// Lista todas as pessoas inseridas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ListDataPagination<Person>), 200)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 0, 
            [FromQuery] int size = 15,
            [FromQuery] string searchString = null,
            [FromQuery] string registrationNumber = null,
            [FromQuery] string email = null,  
            [FromQuery] bool isDeleted = false,
            [FromQuery] string orderBy = null)
        {   
            try
            {
                var people = await _personRepository.ListPerson(page, size, searchString, registrationNumber, email, isDeleted, orderBy);
                return Ok(people);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Lista uma pessoa por id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Person), 200)]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var person = await _personRepository.GetById(id);
                return Ok(person);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Insere uma nova pessoa
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Create(Person person)
        { 
            try
             {
                await _personRepository.Create(person);
                return Ok();
             }
             catch (Exception ex)
             {
                return BadRequest(ex.Message);
             }  
        }


        /// <summary>
        /// Atualiza os dados de uma pessoa
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                var person = await _personRepository.GetById(id);
                await _personRepository.Update(person);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }   
        }

        /// <summary>
        /// Exclui uma pessoa
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            
            try 
            {
                var person = await _personRepository.GetById(id);
                await _personRepository.Delete(person);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }   
    
}