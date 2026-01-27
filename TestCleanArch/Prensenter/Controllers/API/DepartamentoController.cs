using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prensenter.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
     
        private readonly ICRUDDepartamentoUseCase _departamentoUseCase;
        public DepartamentoController( ICRUDDepartamentoUseCase departamentoUseCase)
        {
     
            _departamentoUseCase = departamentoUseCase;
        }

        // GET: api/<DepartamentoController>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<Departamento> listadoCompleto = new List<Departamento>();

            try
            {

                listadoCompleto = _departamentoUseCase.GetDepartamentos();
                
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
            Departamento departamento;

            try
            {

                departamento = _departamentoUseCase.GetDepartamentoById(id);



                salida = Ok(departamento);

            }
            catch
            {
                salida = BadRequest();
            }
            return salida;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public IActionResult Post(Departamento departamento)
        {
            IActionResult salida;
            int result;

            try
            {

                result = _departamentoUseCase.CreateDepartamento(departamento);



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
        public IActionResult Put(int id, Departamento departamento)
        {
            IActionResult salida;
            int result;

            try
            {
                if (_departamentoUseCase.GetDepartamentoById(id) != null)
                {
                    result = _departamentoUseCase.UpdateDepartamento(departamento);
                }
                else
                {
                    result = _departamentoUseCase.CreateDepartamento(departamento);
                }



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

                numFilasAfectadas = _departamentoUseCase.DeleteDepartamento(id);
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
