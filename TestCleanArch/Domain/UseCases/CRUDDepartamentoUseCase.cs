using Domain.Entities;
using Domain.Interfaces;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class CRUDDepartamentoUseCase : ICRUDDepartamentoUseCase
    {
        private readonly ICRUDDepartamentoRepository _departamentoRepo;

        public CRUDDepartamentoUseCase(ICRUDDepartamentoRepository departamentoRepo)
        {
            _departamentoRepo = departamentoRepo;
        }

        public List<Departamento> GetDepartamentos()
        {
            return _departamentoRepo.GetDepartamentos();
        }

        public Departamento GetDepartamentoById(int id)
        {
            return _departamentoRepo.GetDepartamentoById(id);
        }

        public int CreateDepartamento(Departamento departamento)
        {
            return _departamentoRepo.CreateDepartamento(departamento);
        }

        public int DeleteDepartamento(int id)
        {
            // Validación de regla de negocio: no se puede borrar un departamento si tiene personas
            int personasEnDepartamento = _departamentoRepo.CheckPersonasInDepartamento(id);

            if (personasEnDepartamento <= 0)
            {
                // Retorna -1 para indicar que no se puede eliminar
                return -1;
            }

            return _departamentoRepo.DeleteDepartamento(id);
        }

        public int UpdateDepartamento(Departamento departamento)
        {
            return _departamentoRepo.UpdateDepartamento(departamento);
        }

        public int CheckPersonasInDepartamento(int idDepartamento)
        {
            return _departamentoRepo.CheckPersonasInDepartamento(idDepartamento);
        }
    }
}
