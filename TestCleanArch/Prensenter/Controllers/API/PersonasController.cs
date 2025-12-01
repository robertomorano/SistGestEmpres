using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prensenter.Controllers.API
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly ICRUDPeopleUseCase _personaUseCase;
        private readonly ICRUDDepartamentoUseCase _departamentoUseCase;
        public PersonasController(ICRUDPeopleUseCase personaUseCase, ICRUDDepartamentoUseCase departamentoUseCase)
        {
            _personaUseCase = personaUseCase;
            _departamentoUseCase = departamentoUseCase;
        }
        // GET: api/<PersonasController>
        [HttpGet]
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaDepartamentoDto> listadoCompleto = new List<PersonaDepartamentoDto>();

            try
            {

                listadoCompleto = _personaUseCase.GetPeopleList();
                if (listadoCompleto.Count() == 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(listadoCompleto);
                }
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;

        }


        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return _personaUseCase.GetPersonById(id);
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post(Person person)
        {
            return Ok(_personaUseCase.CreatePerson(person));
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Person person)
        {
            return Ok(_personaUseCase.UpdatePerson(person));
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult salida;
            int numFilasAfectadas = 0;


            try
            {

                numFilasAfectadas = _personaUseCase.DeletePerson(id);
                if (numFilasAfectadas == 0)
                {
                    salida = NotFound();
                }
                else
                {
                    salida = Ok();
                }
            }
            catch (Exception e)
            {
                salida = BadRequest();
            }

            return salida;
        }
    }
}
