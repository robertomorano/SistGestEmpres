using Domain.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using Domain.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Prensenter.Controllers
{
    public class PersonController : Controller
    {
        private readonly ICRUDPeopleUseCase _personaUseCase;
        private readonly ICRUDDepartamentoUseCase _departamentoUseCase;

        public PersonController(ICRUDPeopleUseCase personaUseCase, ICRUDDepartamentoUseCase departamentoUseCase)
        {
            _personaUseCase = personaUseCase;
            _departamentoUseCase = departamentoUseCase;
        }

        // GET: Personas
        public IActionResult Index()
        {
            List<PersonaDepartamentoDto> listaPersonas = _personaUseCase.GetPeopleList();
            return View(listaPersonas);
        }

        // GET: Personas/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            PersonaDepartamentoListDto personaDto = _personaUseCase.GetPersonaWithDepartamentos(id);

            if (personaDto == null)
            {
                return NotFound();
            }

            // Obtener el departamento para mostrar el nombre
            

            
            

            return View(personaDto);
        }

        // GET: Personas/Create
        public IActionResult Create()
        {
            List<Departamento> departamentos = _departamentoUseCase.GetDepartamentos();
            ViewBag.Departamentos = new SelectList(departamentos, "Id", "Name");

            return View();
        }

        // POST: Personas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person persona)
        {
            if (ModelState.IsValid)
            {
                int resultado = _personaUseCase.CreatePerson(persona);

                if (resultado > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al crear la persona");
                }
            }

            // Si hay error, recargar lista de departamentos
            /*List<Departamento> departamentos = _departamentoUseCase.GetDepartamentos();
            ViewBag.Departamentos = new SelectList(departamentos, "Id", "Name");*/

            return View(persona);
        }

        // GET: Personas/Edit/5
        public IActionResult Edit(int id)
        {
            

            Person persona = _personaUseCase.GetPersonById(id);

            if (persona == null)
            {
                return NotFound();
            }

            /*List<Departamento> departamentos = _departamentoUseCase.GetDepartamentos();
            ViewBag.Departamentos = new SelectList(departamentos, "Id", "Name", persona.Departamento);*/

            return View(persona);
        }

        // POST: Personas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Person persona)
        {
            

            if (ModelState.IsValid)
            {
                int resultado = _personaUseCase.UpdatePerson(persona);

                if (resultado > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar la persona");
                }
            }

            // Si hay error, recargar lista de departamentos
           /* List<Departamento> departamentos = _departamentoUseCase.GetDepartamentos();
            ViewBag.Departamentos = new SelectList(departamentos, "Id", "Name", persona.Departamento);*/

            return View(persona);
        }

        // GET: Personas/Delete/5
        public IActionResult Delete(int id)
        {
            

            Person persona = _personaUseCase.GetPersonById(id);

            if (persona == null)
            {
                return NotFound();
            }

            // Obtener el departamento para mostrar el nombre
            Departamento departamento = _departamentoUseCase.GetDepartamentoById(persona.Departamento);

            PersonaDepartamentoDto personaDto = new PersonaDepartamentoDto(persona, departamento);
            //personaDto.Persona = persona;
            //personaDto.DepartamentoNombre = departamento != null ? departamento.Name : "Sin departamento";

            return View(personaDto);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            int resultado = _personaUseCase.DeletePerson(id);

            if (resultado > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar la persona";
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }
    }
}
