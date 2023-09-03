using AutoMapper;
using Crud.API.src.Domain.Entities;
using Crud.API.src.Domain.Interfaces;
using Crud.API.src.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Crud.API.src.Services.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public PersonController( IPersonRepository personRepository,IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista todas as pessoas inseridas
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(ListDataPagination<Person>), 200)]
        public async Task<IActionResult> GetAll(
            [FromQuery] int page = 0,
            [FromQuery] int size = 15,
            [FromQuery] string? searchString = null,
            [FromQuery] string? registrationNumber = null,
            [FromQuery] string? email = null,
            [FromQuery] bool isDeleted = false,
            [FromQuery] string? orderBy = null)
        {
            try
            {
                ListDataPagination<Person> listData = await _personRepository.ListPerson(page, size, searchString, registrationNumber, email, isDeleted, orderBy);
                ListDataPagination<PersonDto> listDataDto = new ListDataPagination<PersonDto>
                {
                    TotalPages = listData.TotalPages,
                    Page = listData.Page,
                    TotalItems = listData.TotalItems,
                    Data = listData.Data.Select(c => _mapper.Map<PersonDto>(c)).ToList(),
                };

                return Ok(listDataDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna uma pessoa por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var person = await _personRepository.GetById(id);

                if (person == null)
                {
                    return NotFound();
                }

                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Insere uma nova pessoa
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person person)
        {
            try
            {
                await _personRepository.Create(person);
                await _personRepository.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza os dados de uma pessoa por ID.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Person updatedPerson)
        {
            try
            {
                var person = await _personRepository.GetById(id);
                if (person != null)
                {
                    person.PersonName = updatedPerson.PersonName;
                    person.Email = updatedPerson.Email;
                    person.BirthDate = updatedPerson.BirthDate;
                    person.RegistrationNumber = updatedPerson.RegistrationNumber;
                    person.PhoneNumber = updatedPerson.PhoneNumber;
                    person.IsDeleted = false;
                    if(updatedPerson.Address != null)
                    {
                        person.Address = updatedPerson.Address;
                    }

                    await _personRepository.Update(person);
                    await _personRepository.SaveChangesAsync();
                }
                else
                {
                    return NotFound(new { errors = "Pessoa não encontrada" });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui uma pessoa por ID
        /// </summary>
        /// <param name="id">ID da pessoa a ser excluída</param>
        /// <returns>ActionResult indicando o resultado da exclusão</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var person = await _personRepository.GetById(id);

                if (person != null)
                {
                    if (person.IsDeleted)
                    {
                        return NoContent();
                    }

                    person.IsDeleted = true;
                    await _personRepository.SaveChangesAsync();
                }
                else
                {
                    return NotFound(new { errors = "Pessoa não encontrada" });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}