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
        public IActionResult Get()
        {
            IActionResult salida;
            List<Person> listadoCompleto = new List<Person>();

            try
            {

                listadoCompleto = _personaUseCase.GetPeople();
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
        public IActionResult Get(int id)
        {
            IActionResult salida;
            Person persona;

            try
            {

                persona = _personaUseCase.GetPersonById(id);
                
                
                
                    salida = Ok(persona);
                
            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post(Person person)
        {
            IActionResult salida;
            int result;

            try
            {

                result = _personaUseCase.CreatePerson(person);



                salida = Ok(result);

            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Person person)
        {
            IActionResult salida;
            int result;

            try
            {

                result = _personaUseCase.UpdatePerson(person);



                salida = Ok(result);

            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
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
