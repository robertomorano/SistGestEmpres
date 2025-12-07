using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prensenter.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasDepartamentoListController : ControllerBase
    {
        private readonly ICRUDPeopleUseCase _personaUseCase;
        private readonly ICRUDDepartamentoUseCase _departamentoUseCase;
        public PersonasDepartamentoListController(ICRUDPeopleUseCase personaUseCase, ICRUDDepartamentoUseCase departamentoUseCase)
        {
            _personaUseCase = personaUseCase;
            _departamentoUseCase = departamentoUseCase;
        }
        // GET: api/<PersonasDepartamentoListController>
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

        // GET api/<PersonasDepartamentoListController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IActionResult salida;
            PersonaDepartamentoListDto persona;

            try
            {

                persona = _personaUseCase.GetPersonaWithDepartamentos(id);



                salida = Ok(persona);

            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

            // POST api/<PersonasDepartamentoListController>
            [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PersonasDepartamentoListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonasDepartamentoListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
