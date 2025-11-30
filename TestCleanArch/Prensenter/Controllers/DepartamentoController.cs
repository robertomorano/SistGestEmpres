using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Prensenter.Controllers
{
    public class DepartamentoController : Controller
    {
        
        private readonly ICRUDDepartamentoUseCase _departamentoUseCase;

        public DepartamentoController(ICRUDDepartamentoUseCase departamentoUseCase)
        {
            _departamentoUseCase = departamentoUseCase;
        }

        // GET: Departamentos
        public IActionResult Index()
        {
            List<Departamento> listaDepartamentos = _departamentoUseCase.GetDepartamentos();
            return View(listaDepartamentos);
        }

        // GET: Departamentos/Details/5
        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Departamento departamento = _departamentoUseCase.GetDepartamentoById(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // GET: Departamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                int resultado = _departamentoUseCase.CreateDepartamento(departamento);

                if (resultado > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al crear el departamento");
                }
            }

            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public IActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Departamento departamento = _departamentoUseCase.GetDepartamentoById(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int resultado = _departamentoUseCase.UpdateDepartamento(departamento);

                if (resultado > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar el departamento");
                }
            }

            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public IActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            Departamento departamento = _departamentoUseCase.GetDepartamentoById(id);

            if (departamento == null)
            {
                return NotFound();
            }

            // Verificar si hay personas en el departamento
            int personasEnDepartamento = _departamentoUseCase.CheckPersonasInDepartamento(id);

            if (personasEnDepartamento > 0)
            {
                ViewBag.TienePersonas = true;
                ViewBag.NumeroPersonas = personasEnDepartamento;
            }

            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            int resultado = _departamentoUseCase.DeleteDepartamento(id);

            if (resultado == -1)
            {
                // No se puede eliminar porque tiene personas asociadas
                TempData["ErrorMessage"] = "No se puede eliminar el departamento porque tiene personas asociadas.";
                return RedirectToAction(nameof(Delete), new { id = id });
            }
            else if (resultado > 0)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar el departamento";
                return RedirectToAction(nameof(Delete), new { id = id });
            }
        }
    }
}
